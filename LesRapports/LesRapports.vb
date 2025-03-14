Imports System.Data
Imports System.Data.Odbc

Public Class LesRapports
    ' Déclaration des variables de connexion
    Dim myConnection As New Odbc.OdbcConnection
    Dim myCommand As New Odbc.OdbcCommand
    Dim myAdapter As New Odbc.OdbcDataAdapter
    Dim myDataSet As New DataSet
    Dim connString As String = "DSN=CnxOracleFermeD25;Uid=SLAM7;Pwd=slam7;"

    Public Sub loadRapport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Charger les rapports au démarrage
        ChargerRapports()
    End Sub

    Private Sub ChargerRapports()
        Try
            ' Ouvrir la connexion
            myConnection.ConnectionString = connString
            myConnection.Open()

            ' Configurer la commande pour récupérer les rapports
            myCommand.Connection = myConnection
            myCommand.CommandText = "SELECT ID_VISITE, ID_VISITEUR, DATE_VISITE, MOTIF_VISITE " &
                       "FROM RapportDeVisite " &
                       "ORDER BY DATE_VISITE DESC"

            ' Remplir le DataSet
            myAdapter.SelectCommand = myCommand
            myDataSet.Clear()
            myAdapter.Fill(myDataSet, "RapportsVisite")

            ' Lier le DataGrid aux données
            dgvRapports.DataSource = myDataSet.Tables("RapportsVisite")

            ' Configurer l'apparence du DataGrid
            ConfigurerDataGrid()

        Catch ex As Exception
            MessageBox.Show("Erreur lors du chargement des rapports: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Fermer la connexion
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
        End Try
    End Sub

    Private Sub ConfigurerDataGrid()
        ' Configurer les colonnes du DataGridView
        With dgvRapports
            ' Renommer les en-têtes des colonnes
            If .Columns.Count > 0 Then
                .Columns(0).HeaderText = "ID Visite"
                .Columns(0).Width = 80
                .Columns(1).HeaderText = "ID Visiteur"
                .Columns(1).Width = 80
                .Columns(2).HeaderText = "Date de visite"
                .Columns(2).DefaultCellStyle.Format = "dd/MM/yyyy"
                .Columns(3).HeaderText = "Motif de la visite"
                .Columns(3).Width = 300

                ' Ajouter une colonne pour le bouton de suppression
                Dim btnColumn As New DataGridViewButtonColumn()
                btnColumn.HeaderText = "Action"
                btnColumn.Text = "Supprimer"
                btnColumn.Name = "btnSupprimer"
                btnColumn.UseColumnTextForButtonValue = True
                btnColumn.Width = 80
                .Columns.Add(btnColumn)
            End If
        End With
    End Sub

    Private Sub dgvRapports_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRapports.CellClick
        ' Vérifier si le clic est sur un bouton de suppression
        If e.ColumnIndex = dgvRapports.Columns("btnSupprimer").Index AndAlso e.RowIndex >= 0 Then
            ' Demander confirmation
            Dim idVisite As Integer = Convert.ToInt32(dgvRapports.Rows(e.RowIndex).Cells(0).Value)
            Dim motif As String = dgvRapports.Rows(e.RowIndex).Cells(3).Value.ToString()

            Dim result As DialogResult = MessageBox.Show(
                "Voulez-vous vraiment supprimer le rapport de visite '" & motif & "' ?",
                "Confirmation de suppression",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)

            If result = DialogResult.Yes Then
                SupprimerRapport(idVisite)
            End If
        End If
    End Sub

    Private Sub SupprimerRapport(ByVal idVisite As Integer)
        Try
            ' Ouvrir la connexion
            myConnection.ConnectionString = connString
            myConnection.Open()

            ' Configurer la commande pour supprimer le rapport
            myCommand.Connection = myConnection
            myCommand.CommandText = "DELETE FROM RapportDeVisite WHERE ID_VISITE = ?"
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("@ID", idVisite)

            ' Exécuter la requête
            Dim nbRows As Integer = myCommand.ExecuteNonQuery()

            If nbRows > 0 Then
                MessageBox.Show("Rapport supprimé avec succès.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ' Recharger les données
                ChargerRapports()
            Else
                MessageBox.Show("Aucun rapport n'a été supprimé.", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            MessageBox.Show("Erreur lors de la suppression: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Fermer la connexion
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
        End Try
    End Sub

    Private Sub btnFermer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFermer.Click
        ' Fermer le formulaire et retourner au formulaire précédent
        Me.Close()
    End Sub
End Class