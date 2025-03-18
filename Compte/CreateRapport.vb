Imports System.Data.SqlClient

Public Class CreateRapport
    ' Connexion à la base de données
    Private connectionString As String = "Data Source=votre_serveur;Initial Catalog=votre_base;Integrated Security=True"
    Private connection As SqlConnection
    Private isNewRecord As Boolean = True
    Private currentRapportID As Integer = 0

    Private Sub CreateRapport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialiser la connexion
        connection = New SqlConnection(connectionString)

        ' Initialiser le formulaire
        InitializeForm()

        ' Charger les visites disponibles
        LoadVisites()

        ' Charger les rapports existants
        LoadRapports()
    End Sub

    Private Sub InitializeForm()
        ' Réinitialiser les champs
        txtID.Text = "AUTO"
        dtpDate.Value = DateTime.Now
        cboMotif.SelectedIndex = -1
        cboVisite.SelectedIndex = -1
        txtDescription.Clear()
        txtConclusion.Clear()

        ' Mettre à jour l'état des boutons
        btnEnregistrer.Enabled = True
        btnAnnuler.Enabled = True
        isNewRecord = True
        currentRapportID = 0
    End Sub

    Private Sub LoadVisites()
        Try
            ' Ouvrir la connexion
            connection.Open()

            ' Créer la commande SQL pour récupérer les visites
            Dim sql As String = "SELECT ID_VISITE, 'Visite #' + CAST(ID_VISITE AS VARCHAR) + ' - ' + CONVERT(VARCHAR, DATE_VISITE, 103) AS DESCRIPTION FROM VISITES ORDER BY DATE_VISITE DESC"
            Dim command As New SqlCommand(sql, connection)

            ' Exécuter la requête et remplir le ComboBox
            Dim adapter As New SqlDataAdapter(command)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            ' Configurer le ComboBox
            cboVisite.DataSource = dt
            cboVisite.DisplayMember = "DESCRIPTION"
            cboVisite.ValueMember = "ID_VISITE"
            cboVisite.SelectedIndex = -1

        Catch ex As Exception
            MessageBox.Show("Erreur lors du chargement des visites: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Fermer la connexion
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub

    Private Sub LoadRapports()
        Try
            ' Ouvrir la connexion
            connection.Open()

            ' Créer la commande SQL pour récupérer les rapports
            Dim sql As String = "SELECT R.ID_RAPPORT, R.DATE_RAPPORT, R.MOTIF_VISITE, R.ID_VISITE FROM RAPPORTS R ORDER BY R.DATE_RAPPORT DESC"
            Dim command As New SqlCommand(sql, connection)

            ' Exécuter la requête et remplir le DataGridView
            Dim adapter As New SqlDataAdapter(command)
            Dim dt As New DataTable()
            adapter.Fill(dt)

            ' Effacer et remplir le DataGridView
            dgvRapports.Rows.Clear()

            For Each row As DataRow In dt.Rows
                dgvRapports.Rows.Add(row("ID_RAPPORT"),
                                    Convert.ToDateTime(row("DATE_RAPPORT")).ToString("dd/MM/yyyy"),
                                    row("MOTIF_VISITE"),
                                    row("ID_VISITE"))
            Next

        Catch ex As Exception
            MessageBox.Show("Erreur lors du chargement des rapports: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Fermer la connexion
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub

    Private Sub btnEnregistrer_Click(sender As Object, e As EventArgs) Handles btnEnregistrer.Click
        ' Vérifier les champs obligatoires
        If cboMotif.SelectedIndex = -1 Then
            MessageBox.Show("Veuillez sélectionner un motif.", "Champ manquant", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboMotif.Focus()
            Return
        End If

        If cboVisite.SelectedIndex = -1 Then
            MessageBox.Show("Veuillez sélectionner une visite.", "Champ manquant", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboVisite.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txtDescription.Text) Then
            MessageBox.Show("Veuillez saisir une description.", "Champ manquant", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtDescription.Focus()
            Return
        End If

        Try
            ' Ouvrir la connexion
            connection.Open()

            Dim sql As String
            Dim command As SqlCommand

            If isNewRecord Then
                ' Créer un nouveau rapport
                sql = "INSERT INTO RAPPORTS (DATE_RAPPORT, MOTIF_VISITE, ID_VISITE, DESCRIPTION, CONCLUSION) " &
                      "VALUES (@DATE_RAPPORT, @MOTIF_VISITE, @ID_VISITE, @DESCRIPTION, @CONCLUSION); " &
                      "SELECT SCOPE_IDENTITY();"

                command = New SqlCommand(sql, connection)
                command.Parameters.AddWithValue("@DATE_RAPPORT", dtpDate.Value)
                command.Parameters.AddWithValue("@MOTIF_VISITE", cboMotif.Text)
                command.Parameters.AddWithValue("@ID_VISITE", cboVisite.SelectedValue)
                command.Parameters.AddWithValue("@DESCRIPTION", txtDescription.Text)
                command.Parameters.AddWithValue("@CONCLUSION", txtConclusion.Text)

                ' Exécuter la requête et récupérer l'ID généré
                Dim newID As Object = command.ExecuteScalar()
                If newID IsNot Nothing AndAlso Not DBNull.Value.Equals(newID) Then
                    currentRapportID = Convert.ToInt32(newID)
                    MessageBox.Show("Rapport créé avec succès. ID: " & currentRapportID, "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                ' Mettre à jour un rapport existant
                sql = "UPDATE RAPPORTS SET DATE_RAPPORT = @DATE_RAPPORT, MOTIF_VISITE = @MOTIF_VISITE, " &
                      "ID_VISITE = @ID_VISITE, DESCRIPTION = @DESCRIPTION, CONCLUSION = @CONCLUSION " &
                      "WHERE ID_RAPPORT = @ID_RAPPORT"

                command = New SqlCommand(sql, connection)
                command.Parameters.AddWithValue("@ID_RAPPORT", currentRapportID)
                command.Parameters.AddWithValue("@DATE_RAPPORT", dtpDate.Value)
                command.Parameters.AddWithValue("@MOTIF_VISITE", cboMotif.Text)
                command.Parameters.AddWithValue("@ID_VISITE", cboVisite.SelectedValue)
                command.Parameters.AddWithValue("@DESCRIPTION", txtDescription.Text)
                command.Parameters.AddWithValue("@CONCLUSION", txtConclusion.Text)

                ' Exécuter la requête
                Dim rowsAffected As Integer = command.ExecuteNonQuery()
                If rowsAffected > 0 Then
                    MessageBox.Show("Rapport mis à jour avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If

            ' Recharger les rapports
            LoadRapports()

            ' Réinitialiser le formulaire
            InitializeForm()

        Catch ex As Exception
            MessageBox.Show("Erreur lors de l'enregistrement du rapport: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Fermer la connexion
            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub

    Private Sub btnAnnuler_Click(sender As Object, e As EventArgs) Handles btnAnnuler.Click
        ' Réinitialiser le formulaire
        InitializeForm()
    End Sub

    Private Sub btnNouveau_Click(sender As Object, e As EventArgs) Handles btnNouveau.Click
        ' Réinitialiser le formulaire pour un nouveau rapport
        InitializeForm()
    End Sub

    Private Sub dgvRapports_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRapports.CellClick
        ' Vérifier que la cellule cliquée est valide
        If e.RowIndex >= 0 AndAlso e.RowIndex < dgvRapports.Rows.Count Then
            Try
                ' Récupérer l'ID du rapport sélectionné
                Dim rapportID As Integer = Convert.ToInt32(dgvRapports.Rows(e.RowIndex).Cells("ColID").Value)

                ' Ouvrir la connexion
                connection.Open()

                ' Créer la commande SQL pour récupérer les détails du rapport
                Dim sql As String = "SELECT * FROM RAPPORTS WHERE ID_RAPPORT = @ID_RAPPORT"
                Dim command As New SqlCommand(sql, connection)
                command.Parameters.AddWithValue("@ID_RAPPORT", rapportID)

                ' Exécuter la requête
                Dim reader As SqlDataReader = command.ExecuteReader()

                If reader.Read() Then
                    ' Remplir les champs avec les données du rapport
                    currentRapportID = rapportID
                    txtID.Text = rapportID.ToString()
                    dtpDate.Value = Convert.ToDateTime(reader("DATE_RAPPORT"))
                    cboMotif.Text = reader("MOTIF_VISITE").ToString()

                    ' Sélectionner la visite correspondante
                    For i As Integer = 0 To cboVisite.Items.Count - 1
                        Dim dr As DataRowView = DirectCast(cboVisite.Items(i), DataRowView)
                        If dr("ID_VISITE").ToString() = reader("ID_VISITE").ToString() Then
                            cboVisite.SelectedIndex = i
                            Exit For
                        End If
                    Next

                    txtDescription.Text = reader("DESCRIPTION").ToString()
                    txtConclusion.Text = reader("CONCLUSION").ToString()

                    ' Mettre à jour l'état
                    isNewRecord = False
                End If

                reader.Close()

            Catch ex As Exception
                MessageBox.Show("Erreur lors du chargement des détails du rapport: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                ' Fermer la connexion
                If connection.State = ConnectionState.Open Then
                    connection.Close()
                End If
            End Try
        End If
    End Sub

    Private Sub CreateRapport_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ' Fermer la connexion si nécessaire
        If connection IsNot Nothing AndAlso connection.State = ConnectionState.Open Then
            connection.Close()
        End If
    End Sub
End Class