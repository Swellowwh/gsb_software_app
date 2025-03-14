Public Class HomeRapport
    ' Déclaration des variables de connexion
    Dim myConnection As New Odbc.OdbcConnection
    Dim myCommand As New Odbc.OdbcCommand
    Dim myAdapter As New Odbc.OdbcDataAdapter
    Dim myDataTable As New DataTable
    Dim connString As String

    ' Variables pour stocker les informations de l'utilisateur connecté
    Public UserID As Integer
    Public UserName As String
    Public UserRole As Integer

    Private Sub logout_Click(sender As Object, e As EventArgs) Handles account.Click
        ' Déconnexion et retour à la page de connexion
        If MessageBox.Show("Voulez-vous vraiment vous déconnecter ?", "Déconnexion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            ' Fermer la connexion à la base de données
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If

            MessageBox.Show("Vous avez été déconnecté !")

            ' Ouvrir le formulaire de connexion et fermer celui-ci
            ' Dim loginForm As New LoginForm()
            ' loginForm.Show()
            Me.Close()
        End If
    End Sub

    Private Sub HomeRapport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Connexion à la base de données lors du chargement
        ConnectToDatabase()

        ' Charger la liste des rapports
        LoadRapports()

        ' Afficher le nom de l'utilisateur connecté si disponible
        If Not String.IsNullOrEmpty(UserName) Then
            account.Text = UserName
        End If
    End Sub

    Private Sub ConnectToDatabase()
        Try
            ' Configurer la chaîne de connexion
            connString = "DSN=CnxOracleFermeD25;Uid=SLAM7;Pwd=slam7;"
            myConnection.ConnectionString = connString

            ' Ouvrir la connexion
            If myConnection.State <> ConnectionState.Open Then
                myConnection.Open()
            End If
        Catch ex As Exception
            MessageBox.Show("Erreur de connexion à la base de données: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub LoadRapports()
        Try
            ' Créer une DataGridView dynamiquement pour afficher les rapports
            Dim dgvRapports As New DataGridView()

            ' Configurer la DataGridView
            dgvRapports.Name = "dgvRapports"
            dgvRapports.Location = New Point(10, 100)
            dgvRapports.Size = New Size(850, 300)
            dgvRapports.AllowUserToAddRows = False
            dgvRapports.AllowUserToDeleteRows = False
            dgvRapports.ReadOnly = True
            dgvRapports.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgvRapports.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgvRapports.BackgroundColor = Color.White

            ' Ajouter la DataGridView au Panel2
            Panel2.Controls.Add(dgvRapports)

            ' Requête SQL pour récupérer les rapports
            Dim query As String = "SELECT R.ID_RAPPORT, R.ID_VISITE, V.DATE_VISITE, P.NOM, P.PRENOM, V.MOTIF_VISITE " &
                                 "FROM RAPPORT R " &
                                 "JOIN VISITE V ON R.ID_VISITE = V.ID_VISITE " &
                                 "JOIN PRATICIEN P ON V.ID_VISITEUR = P.ID_PRATICIEN " &
                                 "ORDER BY V.DATE_VISITE DESC"

            ' Exécuter la requête et remplir la DataGridView
            myCommand.Connection = myConnection
            myCommand.CommandText = query

            ' Adapter et DataTable
            myAdapter = New Odbc.OdbcDataAdapter(myCommand)
            myDataTable = New DataTable()
            myAdapter.Fill(myDataTable)

            ' Lier la DataTable à la DataGridView
            dgvRapports.DataSource = myDataTable

            ' Renommer les colonnes pour une meilleure présentation
            dgvRapports.Columns("ID_RAPPORT").HeaderText = "ID"
            dgvRapports.Columns("ID_VISITE").HeaderText = "ID Visite"
            dgvRapports.Columns("DATE_VISITE").HeaderText = "Date"
            dgvRapports.Columns("NOM").HeaderText = "Nom"
            dgvRapports.Columns("PRENOM").HeaderText = "Prénom"
            dgvRapports.Columns("MOTIF_VISITE").HeaderText = "Motif"

            ' Ajouter un événement pour la sélection de ligne
            AddHandler dgvRapports.SelectionChanged, AddressOf dgvRapports_SelectionChanged

        Catch ex As Exception
            MessageBox.Show("Erreur lors du chargement des rapports: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvRapports_SelectionChanged(sender As Object, e As EventArgs)
        ' Récupérer la DataGridView
        Dim dgv As DataGridView = DirectCast(sender, DataGridView)

        ' Vérifier si une ligne est sélectionnée
        If dgv.SelectedRows.Count > 0 Then
            ' Récupérer l'ID du rapport sélectionné
            Dim idRapport As Integer = Convert.ToInt32(dgv.SelectedRows(0).Cells("ID_RAPPORT").Value)

            ' Récupérer les détails du rapport
            LoadRapportDetails(idRapport)
        End If
    End Sub

    Private Sub LoadRapportDetails(idRapport As Integer)
        Try
            ' Requête pour obtenir les détails du rapport
            Dim query As String = "SELECT B.DESCRIPTION " &
                                  "FROM BILAN B " &
                                  "WHERE B.ID_RAPPORT = " & idRapport

            myCommand.CommandText = query
            Dim description As String = ""

            Using reader As Odbc.OdbcDataReader = myCommand.ExecuteReader()
                If reader.Read() Then
                    description = reader("DESCRIPTION").ToString()
                End If
            End Using

            ' Afficher la description dans le TextBox
            inputNomPatient.Text = description

        Catch ex As Exception
            MessageBox.Show("Erreur lors du chargement des détails du rapport: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub validButton_Click(sender As Object, e As EventArgs) Handles validButton.Click
        ' Code pour valider un rapport
        If inputNomPatient.Text = "" Then
            MessageBox.Show("Veuillez sélectionner un rapport d'abord.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        MessageBox.Show("Rapport validé avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub declinerButton_Click(sender As Object, e As EventArgs) Handles declinerButton.Click
        ' Code pour décliner un rapport
        If inputNomPatient.Text = "" Then
            MessageBox.Show("Veuillez sélectionner un rapport d'abord.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        MessageBox.Show("Rapport décliné.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Navigation vers la page de création de rapport
        MessageBox.Show("Redirection vers la page de création de rapport", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ' Code pour ouvrir le formulaire de création de rapport
        ' Dim createRapportForm As New CreateRapportForm()
        ' createRapportForm.Show()
        ' Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Actualiser la liste des rapports
        LoadRapports()
        MessageBox.Show("Liste des rapports actualisée", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint
        ' Gestion du design du Panel2
    End Sub
End Class