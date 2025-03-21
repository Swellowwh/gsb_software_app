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

    ' Cette méthode s'exécute lorsque le formulaire est chargé
    ' IMPORTANT: Vérifiez que cet événement est correctement lié au formulaire
    Private Sub LesRapports_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Afficher les informations de l'utilisateur connecté
        AfficherInfosUtilisateur()

        ' Tester la connexion à la base de données
        TesterConnexion()

        ' Charger les rapports au démarrage
        ChargerRapports()
    End Sub

    ' Déclaration des contrôles supplémentaires pour le header utilisateur
    Friend WithEvents lblUserInfo As Label
    Friend WithEvents lblUserRole As Label
    Friend WithEvents pnlUserInfo As Panel

    ' Méthode pour afficher les informations de l'utilisateur connecté
    Private Sub AfficherInfosUtilisateur()
        Try
            ' Vérifier que les contrôles ont bien été initialisés
            If lblUserInfo Is Nothing Or lblUserRole Is Nothing Then
                Return
            End If

            ' Vérifier que les informations utilisateur sont disponibles
            If Not String.IsNullOrEmpty(UserName) Then
                ' Afficher le nom de l'utilisateur
                lblUserInfo.Text = "Utilisateur connecté: " & UserName

                ' Afficher le rôle de l'utilisateur
                If Not String.IsNullOrEmpty(UserRole) Then
                    lblUserRole.Text = "Rôle: " & UserRole
                End If
            End If

            ' Ajuster le layout pour tenir compte du nouveau panneau
            AjusterLayout()

        Catch ex As Exception
            MessageBox.Show("Erreur lors de l'affichage des informations utilisateur: " & ex.Message,
                           "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Méthode pour ajuster le layout après l'ajout du panneau utilisateur
    Private Sub AjusterLayout()
        Try
            ' Ajuster la position et la taille de la grille pour tenir compte du panneau utilisateur
            If dgvRapports IsNot Nothing And pnlUserInfo IsNot Nothing Then
                dgvRapports.Location = New Point(0, lblTitre.Height + pnlUserInfo.Height)
                dgvRapports.Height = Me.ClientSize.Height - lblTitre.Height - pnlUserInfo.Height - pnlActions.Height
            End If
        Catch ex As Exception
            Console.WriteLine("Erreur lors de l'ajustement du layout: " & ex.Message)
        End Try
    End Sub

    ' Méthode pour tester la connexion à la base de données
    Private Sub TesterConnexion()
        Try
            ' Créer une connexion temporaire pour tester
            Using conn As New OdbcConnection(connString)
                conn.Open()
                MessageBox.Show("Connexion réussie à la base de données!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Tester la requête pour vérifier qu'il y a des données
                ' IMPORTANT: Vérifiez que le nom de la table est correct (majuscules/minuscules)
                Using cmd As New OdbcCommand("SELECT COUNT(*) FROM RAPPORT_DE_VISITE", conn)
                    Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                    MessageBox.Show("Nombre de rapports dans la table: " & count, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Erreur de connexion: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

            ' Configurer la commande pour récupérer les rapports
            ' Option: Filtrer les rapports en fonction de l'utilisateur connecté si nécessaire
            Dim sqlQuery As String = "SELECT * FROM RAPPORT_DE_VISITE"

            ' Si l'utilisateur n'est pas administrateur, ne montrer que ses propres rapports
            If Not String.IsNullOrEmpty(UserID) AndAlso UserRole <> "ADMIN" Then
                sqlQuery &= " WHERE ID_VISITEUR = '" & UserID & "'"
            End If

            sqlQuery &= " ORDER BY DATE_VISITE DESC"

            myCommand.Connection = myConnection
            myCommand.CommandText = sqlQuery

            ' IMPORTANT: Créer un nouveau DataTable à chaque fois
            Dim table As New DataTable("RapportsVisite")

            ' Remplir le DataTable avec les données
            myAdapter.SelectCommand = myCommand
            myAdapter.Fill(table)

            ' Vérifier si des données ont été récupérées
            If table.Rows.Count > 0 Then
                ' Débogage: Afficher des informations sur les données récupérées
                Console.WriteLine("Nombre de lignes récupérées: " & table.Rows.Count)
                Console.WriteLine("Noms des colonnes: " & String.Join(", ", table.Columns.Cast(Of DataColumn)().Select(Function(c) c.ColumnName)))

                ' IMPORTANT: Afficher explicitement le nombre de lignes pour débogage
                MessageBox.Show("Nombre de lignes récupérées: " & table.Rows.Count, "Débogage", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            MessageBox.Show("Erreur lors du chargement des rapports: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Fermer la connexion
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
        End Try
    End Sub

    ' Méthode pour configurer l'apparence du DataGridView
    Private Sub ConfigurerDataGrid()
        ' IMPORTANT: Vérifier que la source de données est définie
        If dgvRapports.DataSource IsNot Nothing AndAlso dgvRapports.Columns.Count > 0 Then
            ' Débogage: Afficher les noms des colonnes
            Dim columnNames As String = String.Join(", ", dgvRapports.Columns.Cast(Of DataGridViewColumn)().Select(Function(c) c.Name))
            Console.WriteLine("Colonnes du DataGridView: " & columnNames)

            ' IMPORTANT: Configurer chaque colonne en fonction de son nom (insensible à la casse)
            For i As Integer = 0 To dgvRapports.Columns.Count - 1
                Dim colName As String = dgvRapports.Columns(i).Name.ToUpper()

                Select Case colName
                    Case "ID_VISITE"
                        dgvRapports.Columns(i).HeaderText = "N° de Visite"
                        dgvRapports.Columns(i).Width = 80
                    Case "ID_VISITEUR"
                        dgvRapports.Columns(i).HeaderText = "Visiteur"
                        dgvRapports.Columns(i).Width = 80
                    Case "DATE_VISITE"
                        dgvRapports.Columns(i).HeaderText = "Date de visite"
                        dgvRapports.Columns(i).DefaultCellStyle.Format = "dd/MM/yyyy"
                    Case "MOTIF_VISITE"
                        dgvRapports.Columns(i).HeaderText = "Motif de la visite"
                        dgvRapports.Columns(i).Width = 300
                End Select
            Next

            ' IMPORTANT: Ajouter la colonne de bouton uniquement si elle n'existe pas déjà
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
            ' Vérifier si le clic est sur le bouton de suppression et sur une ligne valide
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
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Erreur lors de la suppression: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
        frmCreateRapport.UserID = "1"  ' Forcer l'ID à 1 pour votre test
        frmCreateRapport.UserName = "Visiteur Test"
        frmCreateRapport.UserRole = "Visiteur"

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