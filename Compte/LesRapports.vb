Imports System.Data
Imports System.Data.Odbc

Public Class LesRapports
    ' Déclaration des variables de connexion
    Private myConnection As New Odbc.OdbcConnection
    Private myCommand As New Odbc.OdbcCommand
    Private myAdapter As New Odbc.OdbcDataAdapter
    Private myDataSet As New DataSet
    Private connString As String = "DSN=CnxOracleFermeD25;Uid=SLAM7;Pwd=slam7;"

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

    ' Méthode pour charger les rapports depuis la base de données
    Private Sub ChargerRapports()
        Try
            ' IMPORTANT: Assurez-vous que toute connexion précédente est fermée
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If

            ' Ouvrir la connexion
            myConnection.ConnectionString = connString
            myConnection.Open()

            ' Configurer la commande pour récupérer les rapports avec les noms des visiteurs
            ' Requête modifiée pour ne plus récupérer les informations de rôle
            Dim sqlQuery As String = "SELECT R.ID_RAPPORT, R.DATE_VISITE, R.MOTIF_VISITE, R.CONTENU_VISITE, " &
                       "R.ID_VISITEUR, U.NOM, U.PRENOM " &
                       "FROM RAPPORT_DE_VISITE R " &
                       "LEFT JOIN VISITEUR_MEDICAL VM ON R.ID_VISITEUR = VM.ID_VISITEUR " &
                       "LEFT JOIN UTILISATEUR U ON VM.ID_USER = U.ID_USER"

            ' Si l'utilisateur n'est pas administrateur, ne montrer que ses propres rapports
            If Not String.IsNullOrEmpty(UserID) AndAlso UserRole <> "Responsable secteur" Then
                sqlQuery &= " WHERE R.ID_VISITEUR = '" & UserID & "'"
            End If

            sqlQuery &= " ORDER BY R.DATE_VISITE DESC"

            myCommand.Connection = myConnection
            myCommand.CommandText = sqlQuery

            ' IMPORTANT: Créer un nouveau DataTable à chaque fois
            Dim table As New DataTable("RapportsVisite")

            ' Remplir le DataTable avec les données
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(table)

            ' Débogage: Afficher la requête SQL pour vérification
            Console.WriteLine("Requête SQL exécutée: " & sqlQuery)

            ' Vérifier si des données ont été récupérées
            If table.Rows.Count > 0 Then
                ' Débogage: Afficher des informations sur les données récupérées
                Console.WriteLine("Nombre de lignes récupérées: " & table.Rows.Count)
                Console.WriteLine("Noms des colonnes: " & String.Join(", ", table.Columns.Cast(Of DataColumn)().Select(Function(c) c.ColumnName)))

                ' Ajouter une colonne pour le nom complet du visiteur si elle n'existe pas déjà
                If Not table.Columns.Contains("NOM_COMPLET") Then
                    table.Columns.Add("NOM_COMPLET", GetType(String))
                End If

                ' Remplir la colonne NOM_COMPLET avec le NOM en majuscules
                For Each row As DataRow In table.Rows
                    ' Récupérer les valeurs en gérant les nulls de manière plus robuste
                    Dim nom As String = If(row.IsNull("NOM"), "", row("NOM").ToString().ToUpper())
                    Dim prenom As String = If(row.IsNull("PRENOM"), "", row("PRENOM").ToString())

                    ' Construire le nom complet sans le rôle
                    If Not String.IsNullOrEmpty(nom) Or Not String.IsNullOrEmpty(prenom) Then
                        row("NOM_COMPLET") = prenom & " " & nom
                    Else
                        ' Si on n'a pas les informations, essayer de récupérer au moins l'ID visiteur
                        row("NOM_COMPLET") = "Visiteur " & If(row.IsNull("ID_VISITEUR"), "inconnu", row("ID_VISITEUR").ToString())
                    End If
                Next
            Else
                MessageBox.Show("Aucune donnée récupérée de la base de données.", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            ' IMPORTANT: Définir explicitement le DataSource à null avant de l'affecter
            dgvRapports.DataSource = Nothing
            dgvRapports.DataSource = table

            ' Configurer l'apparence du DataGrid
            ConfigurerDataGrid()

            ' IMPORTANT: Forcer le rafraîchissement du DataGridView
            dgvRapports.Update()
            dgvRapports.Refresh()

        Catch ex As Exception
            MessageBox.Show("Erreur lors du chargement des rapports: " & ex.Message & Environment.NewLine &
                   "Trace de la pile: " & ex.StackTrace, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Fermer la connexion
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
        End Try
    End Sub

    Private Sub ConfigurerDataGrid()
        ' IMPORTANT: Vérifier que la source de données est définie
        If dgvRapports.DataSource IsNot Nothing AndAlso dgvRapports.Columns.Count > 0 Then
            ' Débogage: Afficher les noms des colonnes
            Dim columnNames As String = String.Join(", ", dgvRapports.Columns.Cast(Of DataGridViewColumn)().Select(Function(c) c.Name))
            Console.WriteLine("Colonnes du DataGridView: " & columnNames)

            ' Réorganiser l'ordre des colonnes
            Dim ordreColonnes As String() = {"DATE_VISITE", "MOTIF_VISITE", "CONTENU_VISITE", "NOM_COMPLET"}
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
                        col.Width = 200
                    Case "CONTENU_VISITE"
                        col.HeaderText = "Contenu de la visite"
                        col.Width = 200
                    Case "ID_VISITEUR"
                        col.Visible = False ' Cacher la colonne ID_VISITEUR
                    Case "NOM"
                        col.Visible = False ' Cacher la colonne NOM
                    Case "PRENOM"
                        col.Visible = False ' Cacher la colonne PRENOM
                    Case "NOM_COMPLET"
                        col.HeaderText = "Visiteur"
                        col.Width = 150
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
                    frmEditRapport.ContenuVisite = contenuVisite  ' Utiliser contenuVisite au lieu de bilanVisite

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
            ' IMPORTANT: Utiliser une connexion séparée pour éviter les conflits
            Using deleteConnection As New OdbcConnection(connString)
                deleteConnection.Open()

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
End Class