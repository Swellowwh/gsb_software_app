Imports System.Data
Imports System.Data.Odbc

Public Class LesRapports
    ' MODIFIÉ : Suppression des variables de connexion globales
    ' Supprimé : Private myConnection As New Odbc.OdbcConnection
    ' Supprimé : Private connString As String = "DSN=CnxOracleFermeD25;Uid=SLAM7;Pwd=slam7;"

    ' Variables restantes
    Private myCommand As New Odbc.OdbcCommand
    Private myAdapter As New Odbc.OdbcDataAdapter
    Private myDataSet As New DataSet

    ' Propriétés utilisateur
    Public Property UserID As String
    Public Property UserName As String
    Public Property UserRole As String

    ' Constructeur par défaut
    Public Sub New()
        ' Appel requis par le concepteur
        InitializeComponent()
    End Sub

    ' Constructeur avec paramètres pour l'utilisateur
    Public Sub New(ByVal userId As String, ByVal userName As String, ByVal userRole As String)
        ' Appel requis par le concepteur
        InitializeComponent()

        ' Initialiser les propriétés utilisateur
        Me.UserID = userId
        Me.UserName = userName
        Me.UserRole = userRole
    End Sub

    ' Cette méthode s'exécute lorsque le formulaire est chargé
    Private Sub LesRapports_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Afficher les informations de l'utilisateur connecté
        AfficherInfosUtilisateur()

        ' Charger les rapports au démarrage
        ChargerRapports()
    End Sub

    ' Méthode pour afficher les informations de l'utilisateur connecté
    Private Sub AfficherInfosUtilisateur()
        Try
            ' Vérifier que les informations utilisateur sont disponibles
            If Not String.IsNullOrEmpty(UserName) Then
                ' Afficher le nom de l'utilisateur
                lblUserInfo.Text = "Utilisateur connecté: " & UserName

                ' Afficher le rôle de l'utilisateur
                If Not String.IsNullOrEmpty(UserRole) Then
                    lblUserRole.Text = "Rôle: " & UserRole
                End If

                ' Mettre à jour le titre avec le nom de l'utilisateur
                lblTitre.Text = "Synthèse des visites de : " & UserName
            End If

            ' Ajuster le layout
            AjusterLayout()

        Catch ex As Exception
            MessageBox.Show("Erreur lors de l'affichage des informations utilisateur: " & ex.Message,
                           "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Méthode pour ajuster le layout
    Private Sub AjusterLayout()
        Try
            ' Ajuster la position et la taille de la grille
            dgvRapports.Location = New Point(0, lblTitre.Height + pnlUserInfo.Height)
            dgvRapports.Height = Me.ClientSize.Height - lblTitre.Height - pnlUserInfo.Height - pnlActions.Height
        Catch ex As Exception
            Console.WriteLine("Erreur lors de l'ajustement du layout: " & ex.Message)
        End Try
    End Sub

    ' Méthode pour charger les rapports depuis la base de données avec les produits présentés
    Private Sub ChargerRapports()
        Try
            ' MODIFIÉ : Utilisation de ConnectionOracle.GetConnection()
            Dim myConnection = ConnectionOracle.GetConnection()

            ' Configurer la commande pour récupérer les rapports avec les produits associés
            Dim sqlQuery As String = "SELECT rv.ID_RAPPORT, rv.DATE_VISITE, rv.MOTIF_VISITE, rv.CONTENU_VISITE, rv.NOM_MEDECIN "
            sqlQuery &= "FROM RAPPORT_DE_VISITE rv "
            sqlQuery &= "ORDER BY rv.DATE_VISITE DESC"

            ' Afficher la requête SQL pour débogage
            Console.WriteLine("Requête SQL à exécuter: " & sqlQuery)

            myCommand.Connection = myConnection
            myCommand.CommandText = sqlQuery

            ' IMPORTANT: Créer un nouveau DataTable à chaque fois
            Dim table As New DataTable("RapportsVisite")

            ' Débogage: Vérifier l'état de la connexion avant de remplir la table
            Console.WriteLine("État de la connexion avant Fill: " & myConnection.State.ToString())

            ' Remplir le DataTable avec les données
            myAdapter.SelectCommand = myCommand

            ' Débogage immédiat avant de remplir la table
            Try
                myAdapter.Fill(table)
                Console.WriteLine("Nombre immédiat de lignes après Fill: " & table.Rows.Count)
            Catch fillEx As Exception
                Console.WriteLine("Erreur lors du remplissage de la table: " & fillEx.Message)
                MessageBox.Show("Erreur lors du remplissage de la table: " & fillEx.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            ' Vérifier si des données ont été récupérées
            Console.WriteLine("Vérification du nombre de lignes: " & table.Rows.Count)

            If table.Rows.Count > 0 Then
                ' Débogage: Afficher des informations sur les données récupérées
                Console.WriteLine("Nombre de lignes récupérées: " & table.Rows.Count)
                Console.WriteLine("Noms des colonnes: " & String.Join(", ", table.Columns.Cast(Of DataColumn)().Select(Function(c) c.ColumnName)))

                ' Ajouter une colonne pour les produits présentés
                If Not table.Columns.Contains("PRODUITS_PRESENTES") Then
                    table.Columns.Add("PRODUITS_PRESENTES", GetType(String))
                End If

                ' Pour chaque rapport, récupérer les produits associés
                For Each row As DataRow In table.Rows
                    Dim idRapport As Integer = Convert.ToInt32(row("ID_RAPPORT"))
                    row("PRODUITS_PRESENTES") = RecupererProduitsRapport(idRapport)
                Next

            Else
                Console.WriteLine("Aucune ligne récupérée dans la table.")
                MessageBox.Show("Aucune donnée récupérée de la base de données.", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            ' IMPORTANT: Définir explicitement le DataSource à null avant de l'affecter
            dgvRapports.DataSource = Nothing
            dgvRapports.DataSource = table

            ' Débogage après affectation du DataSource
            Console.WriteLine("Nombre de lignes dans le DataGridView après affectation: " & dgvRapports.Rows.Count)

            ' Configurer l'apparence du DataGrid
            ConfigurerDataGrid()

            ' IMPORTANT: Forcer le rafraîchissement du DataGridView
            dgvRapports.Update()
            dgvRapports.Refresh()

        Catch ex As Exception
            MessageBox.Show("Erreur lors du chargement des rapports: " & ex.Message & Environment.NewLine &
                   "Trace de la pile: " & ex.StackTrace, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' SUPPRIMÉ : Plus besoin de fermer la connexion ici
            ' La connexion est gérée par ConnectionOracle
        End Try
    End Sub

    ' Nouvelle méthode pour récupérer les produits associés à un rapport
    Private Function RecupererProduitsRapport(ByVal idRapport As Integer) As String
        Dim listeProduits As String = ""

        Try
            ' MODIFIÉ : Utilisation de ConnectionOracle.GetConnection()
            Using conn = ConnectionOracle.GetConnection()
                ' Requête pour récupérer les produits associés au rapport avec leur quantité
                Dim query As String = "SELECT p.LIBELLE, rp.QUANTITE FROM RAPPORT_PRODUIT rp " &
                                 "JOIN PRODUIT p ON rp.PRODUIT_ID = p.PRODUIT_ID " &
                                 "WHERE rp.ID_RAPPORT = ? " &
                                 "ORDER BY p.LIBELLE"

                Using cmd As New OdbcCommand(query, conn)
                    cmd.Parameters.AddWithValue("?", idRapport)

                    Using reader As OdbcDataReader = cmd.ExecuteReader()
                        Dim produits As New List(Of String)

                        While reader.Read()
                            Dim libelle As String = reader("LIBELLE").ToString()
                            Dim quantite As Integer = Convert.ToInt32(reader("QUANTITE"))

                            ' Format: "XQtés NomProduit"
                            produits.Add(quantite & "x " & libelle & ",")
                        End While

                        ' Concaténer les produits avec virgule et espace
                        If produits.Count > 0 Then
                            listeProduits = String.Join(", ", produits)
                        End If
                    End Using
                End Using
            End Using

        Catch ex As Exception
            Console.WriteLine("Erreur lors de la récupération des produits: " & ex.Message)
            listeProduits = "Erreur: " & ex.Message
        End Try

        Return listeProduits
    End Function

    Private Sub ConfigurerDataGrid()
        ' IMPORTANT: Vérifier que la source de données est définie
        If dgvRapports.DataSource IsNot Nothing AndAlso dgvRapports.Columns.Count > 0 Then
            ' Débogage: Afficher les noms des colonnes
            Dim columnNames As String = String.Join(", ", dgvRapports.Columns.Cast(Of DataGridViewColumn)().Select(Function(c) c.Name))
            Console.WriteLine("Colonnes du DataGridView: " & columnNames)

            ' Réorganiser l'ordre des colonnes
            Dim ordreColonnes As String() = {"DATE_VISITE", "MOTIF_VISITE", "CONTENU_VISITE", "NOM_MEDECIN", "PRODUITS_PRESENTES"}
            For i As Integer = 0 To ordreColonnes.Length - 1
                If dgvRapports.Columns.Contains(ordreColonnes(i)) Then
                    dgvRapports.Columns(ordreColonnes(i)).DisplayIndex = i
                End If
            Next

            ' Configurer les colonnes
            For Each col As DataGridViewColumn In dgvRapports.Columns
                Select Case col.Name.ToUpper()
                    Case "ID_RAPPORT"
                        col.Visible = False ' Cacher le numéro de rapport
                    Case "DATE_VISITE"
                        col.HeaderText = "Date de visite"
                        col.DefaultCellStyle.Format = "dd/MM/yyyy"
                        col.Width = 100
                    Case "MOTIF_VISITE"
                        col.HeaderText = "Motif de la visite"
                        col.Width = 150
                    Case "CONTENU_VISITE"
                        col.HeaderText = "Contenu de la visite"
                        col.Width = 150
                    Case "NOM_MEDECIN"
                        col.HeaderText = "Médecin"
                        col.Width = 100
                    Case "PRODUITS_PRESENTES"
                        col.HeaderText = "Produits présentés"
                        col.Width = 200
                        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                End Select
            Next

            ' Ajouter la colonne "Modifier" si elle n'existe pas
            If Not dgvRapports.Columns.Cast(Of DataGridViewColumn)().Any(Function(c) c.Name = "btnModifier") Then
                Dim btnModifierColumn As New DataGridViewButtonColumn()
                btnModifierColumn.HeaderText = "Modifier"
                btnModifierColumn.Text = "Modifier"
                btnModifierColumn.Name = "btnModifier"
                btnModifierColumn.UseColumnTextForButtonValue = True
                btnModifierColumn.Width = 80
                dgvRapports.Columns.Add(btnModifierColumn)
            End If

            ' Ajouter la colonne "Supprimer" si elle n'existe pas
            If Not dgvRapports.Columns.Cast(Of DataGridViewColumn)().Any(Function(c) c.Name = "btnSupprimer") Then
                Dim btnColumn As New DataGridViewButtonColumn()
                btnColumn.HeaderText = "Action"
                btnColumn.Text = "Supprimer"
                btnColumn.Name = "btnSupprimer"
                btnColumn.UseColumnTextForButtonValue = True
                btnColumn.Width = 80
                dgvRapports.Columns.Add(btnColumn)
            End If
        Else
            MessageBox.Show("Aucune colonne trouvée dans le DataGridView. Vérifiez que des données ont bien été récupérées.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub dgvRapports_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRapports.CellClick
        Try
            ' Vérifier si le clic est sur une ligne valide et sur une colonne de bouton
            If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
                ' Vérifier si la colonne cliquée est la colonne "Supprimer"
                If dgvRapports.Columns(e.ColumnIndex).Name = "btnSupprimer" Then
                    ' Récupérer l'ID de la visite à supprimer
                    Dim idVisite As Integer

                    ' Essayer de trouver la colonne ID_RAPPORT
                    Dim idColumnIndex As Integer = -1
                    For i As Integer = 0 To dgvRapports.Columns.Count - 1
                        If dgvRapports.Columns(i).Name.ToUpper() = "ID_RAPPORT" Then
                            idColumnIndex = i
                            Exit For
                        End If
                    Next

                    ' Vérifier qu'on a trouvé la colonne ID_RAPPORT
                    If idColumnIndex = -1 Then
                        MessageBox.Show("Impossible de trouver la colonne ID_RAPPORT.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If

                    ' Vérifier que la cellule contient une valeur
                    If dgvRapports.Rows(e.RowIndex).Cells(idColumnIndex).Value Is Nothing Then
                        MessageBox.Show("La cellule ID_RAPPORT ne contient pas de valeur.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If

                    ' Récupérer et convertir la valeur
                    Dim idValue As String = dgvRapports.Rows(e.RowIndex).Cells(idColumnIndex).Value.ToString()
                    If Not Integer.TryParse(idValue, idVisite) Then
                        MessageBox.Show("La valeur '" & idValue & "' n'est pas un identifiant valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If

                    ' Récupérer le motif pour l'afficher dans le message de confirmation
                    Dim motifColumnIndex As Integer = -1
                    For i As Integer = 0 To dgvRapports.Columns.Count - 1
                        If dgvRapports.Columns(i).Name.ToUpper() = "MOTIF_VISITE" Then
                            motifColumnIndex = i
                            Exit For
                        End If
                    Next

                    Dim motif As String = "inconnu"
                    If motifColumnIndex >= 0 AndAlso dgvRapports.Rows(e.RowIndex).Cells(motifColumnIndex).Value IsNot Nothing Then
                        motif = dgvRapports.Rows(e.RowIndex).Cells(motifColumnIndex).Value.ToString()
                    End If

                    ' Demander confirmation avant suppression
                    Dim result As DialogResult = MessageBox.Show(
                "Voulez-vous vraiment supprimer le rapport de visite '" & motif & "' ?",
                "Confirmation de suppression",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)

                    If result = DialogResult.Yes Then
                        ' Supprimer le rapport
                        SupprimerRapport(idVisite)
                    End If

                    ' Vérifier si la colonne cliquée est la colonne "Modifier"
                ElseIf dgvRapports.Columns(e.ColumnIndex).Name = "btnModifier" Then
                    ' Récupérer l'ID du rapport à modifier
                    Dim idRapport As Integer

                    ' Trouver la colonne ID_RAPPORT
                    Dim idColumnIndex As Integer = -1
                    For i As Integer = 0 To dgvRapports.Columns.Count - 1
                        If dgvRapports.Columns(i).Name.ToUpper() = "ID_RAPPORT" Then
                            idColumnIndex = i
                            Exit For
                        End If
                    Next

                    ' Vérifier qu'on a trouvé la colonne ID_RAPPORT
                    If idColumnIndex = -1 Then
                        MessageBox.Show("Impossible de trouver la colonne ID_RAPPORT.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If

                    ' Vérifier que la cellule contient une valeur
                    If dgvRapports.Rows(e.RowIndex).Cells(idColumnIndex).Value Is Nothing Then
                        MessageBox.Show("La cellule ID_RAPPORT ne contient pas de valeur.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If

                    ' Récupérer et convertir la valeur
                    Dim idValue As String = dgvRapports.Rows(e.RowIndex).Cells(idColumnIndex).Value.ToString()
                    If Not Integer.TryParse(idValue, idRapport) Then
                        MessageBox.Show("La valeur '" & idValue & "' n'est pas un identifiant valide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If

                    ' Récupérer la date, le motif et le contenu de la visite pour les passer au formulaire de modification
                    Dim dateVisite As DateTime = DateTime.Now
                    Dim motifVisite As String = String.Empty
                    Dim contenuVisite As String = String.Empty

                    ' Trouver les indices des colonnes nécessaires
                    Dim dateColumnIndex As Integer = -1
                    Dim motifColumnIndex As Integer = -1
                    Dim contenuColumnIndex As Integer = -1

                    For i As Integer = 0 To dgvRapports.Columns.Count - 1
                        Select Case dgvRapports.Columns(i).Name.ToUpper()
                            Case "DATE_VISITE"
                                dateColumnIndex = i
                            Case "MOTIF_VISITE"
                                motifColumnIndex = i
                            Case "CONTENU_VISITE"
                                contenuColumnIndex = i
                        End Select
                    Next

                    ' Récupérer les valeurs si les colonnes existent
                    If dateColumnIndex >= 0 AndAlso dgvRapports.Rows(e.RowIndex).Cells(dateColumnIndex).Value IsNot Nothing Then
                        Try
                            dateVisite = Convert.ToDateTime(dgvRapports.Rows(e.RowIndex).Cells(dateColumnIndex).Value)
                        Catch ex As Exception
                            ' Utiliser la date du jour si la conversion échoue
                            Console.WriteLine("Erreur de conversion de date: " & ex.Message)
                        End Try
                    End If

                    If motifColumnIndex >= 0 AndAlso dgvRapports.Rows(e.RowIndex).Cells(motifColumnIndex).Value IsNot Nothing Then
                        motifVisite = dgvRapports.Rows(e.RowIndex).Cells(motifColumnIndex).Value.ToString()
                    End If

                    If contenuColumnIndex >= 0 AndAlso dgvRapports.Rows(e.RowIndex).Cells(contenuColumnIndex).Value IsNot Nothing Then
                        contenuVisite = dgvRapports.Rows(e.RowIndex).Cells(contenuColumnIndex).Value.ToString()
                    End If

                    ' Créer une nouvelle instance du formulaire EditRapport
                    Dim frmEditRapport As New EditRapport()

                    ' Passer les informations de l'utilisateur connecté
                    frmEditRapport.UserID = Me.UserID
                    frmEditRapport.UserName = Me.UserName
                    frmEditRapport.UserRole = Me.UserRole

                    ' Passer les informations du rapport à modifier
                    frmEditRapport.RapportID = idRapport
                    frmEditRapport.DateVisite = dateVisite
                    frmEditRapport.MotifVisite = motifVisite
                    frmEditRapport.ContenuVisite = contenuVisite

                    ' Afficher le formulaire en tant que dialogue modal
                    Dim result As DialogResult = frmEditRapport.ShowDialog()

                    ' Si le dialogue est fermé avec OK (modification effectuée), recharger les rapports
                    If result = DialogResult.OK Then
                        ChargerRapports()
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Erreur lors de la gestion du clic: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Méthode pour supprimer un rapport
    Private Sub SupprimerRapport(ByVal idVisite As Integer)
        Try
            ' MODIFIÉ : Utilisation de ConnectionOracle.GetConnection()
            Using deleteConnection = ConnectionOracle.GetConnection()
                ' Supprimer d'abord les associations avec les produits
                Using deleteProductsCommand As New OdbcCommand("DELETE FROM RAPPORT_PRODUIT WHERE ID_RAPPORT = ?", deleteConnection)
                    deleteProductsCommand.Parameters.AddWithValue("?", idVisite)
                    deleteProductsCommand.ExecuteNonQuery()
                End Using

                ' Configurer la commande pour supprimer le rapport
                ' IMPORTANT: Utiliser un paramètre pour éviter les injections SQL
                Using deleteCommand As New OdbcCommand("DELETE FROM RAPPORT_DE_VISITE WHERE ID_RAPPORT = ?", deleteConnection)
                    ' Pour ODBC, il faut juste ajouter le paramètre sans le nommer
                    deleteCommand.Parameters.AddWithValue("?", idVisite)

                    ' Exécuter la requête
                    Dim nbRows As Integer = deleteCommand.ExecuteNonQuery()

                    If nbRows > 0 Then
                        MessageBox.Show("Rapport supprimé avec succès.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        ' IMPORTANT: Recharger les données après la suppression
                        ChargerRapports()
                    Else
                        MessageBox.Show("Aucun rapport n'a été supprimé.", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Erreur lors de la suppression: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Méthode pour gérer le clic sur le bouton Fermer
    Private Sub btnFermer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFermer.Click
        ' Fermer le formulaire et retourner au formulaire précédent
        Me.Close()
    End Sub

    Private Sub btnAjouter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAjouter.Click
        ' Créer une nouvelle instance du formulaire CreateRapport
        Dim frmCreateRapport As New CreateRapport()

        ' Passer les informations de l'utilisateur connecté
        frmCreateRapport.UserID = Me.UserID
        frmCreateRapport.UserName = Me.UserName
        frmCreateRapport.UserRole = Me.UserRole

        ' Afficher le formulaire en tant que dialogue modal
        frmCreateRapport.ShowDialog()

        ' Après la fermeture du formulaire, recharger les rapports
        ChargerRapports()
    End Sub

    ' Redimensionne les contrôles lorsque la fenêtre est redimensionnée
    Private Sub LesRapports_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        AjusterLayout()
    End Sub

    Private Sub dgvRapports_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRapports.CellContentClick

    End Sub
End Class