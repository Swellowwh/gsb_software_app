Imports System.Data.Odbc

Public Class EditRapport
    ' Variables de connexion à la base de données
    Private myConnection As New Odbc.OdbcConnection
    Private myCommand As New Odbc.OdbcCommand
    Private myAdapter As New Odbc.OdbcDataAdapter
    Private connString As String = "DSN=CnxOracleFermeD25;Uid=SLAM7;Pwd=slam7;"

    ' Propriétés utilisateur
    Public Property UserID As String
    Public Property UserName As String
    Public Property UserRole As String

    ' Propriétés du rapport à modifier
    Public Property RapportID As Integer
    Public Property DateVisite As DateTime
    Public Property MotifVisite As String
    Public Property ContenuVisite As String ' Renommé de BilanVisite à ContenuVisite

    ' Cette méthode s'exécute lorsque le formulaire est chargé
    Private Sub EditRapport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Afficher les informations de l'utilisateur connecté
        lblUserInfo.Text = "Utilisateur connecté: " & UserName

        ' Afficher l'ID du rapport
        lblRapportId.Text = "ID: #" & RapportID.ToString()

        ' Charger les détails du rapport
        ChargerDetailsRapport()
    End Sub

    ' Méthode pour charger les détails complets du rapport depuis la base de données
    Private Sub ChargerDetailsRapport()
        Try
            ' Ouvrir une connexion à la base de données
            myConnection.ConnectionString = connString
            myConnection.Open()

            ' Créer la commande SQL pour récupérer les détails du rapport
            Dim sqlQuery As String = "SELECT * FROM RAPPORT_DE_VISITE WHERE ID_RAPPORT = ?"
            myCommand.Connection = myConnection
            myCommand.CommandText = sqlQuery
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?", RapportID)

            ' Exécuter la requête et récupérer les données
            Using reader As OdbcDataReader = myCommand.ExecuteReader()
                If reader.Read() Then
                    ' Récupérer les valeurs des colonnes et remplir les contrôles

                    ' Date de visite
                    If Not reader.IsDBNull(reader.GetOrdinal("DATE_VISITE")) Then
                        DateVisite = reader.GetDateTime(reader.GetOrdinal("DATE_VISITE"))
                        dtpDateVisite.Value = DateVisite
                    End If

                    ' Motif de visite
                    If Not reader.IsDBNull(reader.GetOrdinal("MOTIF_VISITE")) Then
                        MotifVisite = reader.GetString(reader.GetOrdinal("MOTIF_VISITE"))
                        txtMotif.Text = MotifVisite
                    End If

                    ' Contenu de visite (anciennement Bilan)
                    Try
                        Dim contenuOrdinal As Integer = reader.GetOrdinal("CONTENU_VISITE")
                        If Not reader.IsDBNull(contenuOrdinal) Then
                            ContenuVisite = reader.GetString(contenuOrdinal)
                            txtBilan.Text = ContenuVisite ' Utilise txtBilan comme contrôle mais pour le contenu
                        End If
                    Catch ex As Exception
                        ' La colonne CONTENU_VISITE n'existe peut-être pas
                        Console.WriteLine("Info: La colonne CONTENU_VISITE n'existe peut-être pas: " & ex.Message)
                    End Try
                Else
                    MessageBox.Show("Aucun rapport trouvé avec l'ID " & RapportID, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.DialogResult = DialogResult.Cancel
                    Me.Close()
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Erreur lors du chargement des détails du rapport: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Fermer la connexion
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
        End Try
    End Sub

    ' Méthode pour enregistrer les modifications
    Private Sub btnEnregistrer_Click(sender As Object, e As EventArgs) Handles btnEnregistrer.Click
        Try
            ' Vérifier que les champs obligatoires sont remplis
            If String.IsNullOrEmpty(txtMotif.Text.Trim()) Then
                MessageBox.Show("Veuillez remplir le motif de la visite.", "Champ obligatoire", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtMotif.Focus()
                Return
            End If

            ' Ouvrir une connexion à la base de données
            myConnection.ConnectionString = connString
            myConnection.Open()

            ' Créer la commande SQL pour mettre à jour le rapport
            ' On inclut toujours le contenu de la visite
            Dim sqlQuery As String = "UPDATE RAPPORT_DE_VISITE SET DATE_VISITE = ?, MOTIF_VISITE = ?, CONTENU_VISITE = ? WHERE ID_RAPPORT = ?"

            myCommand.Connection = myConnection
            myCommand.CommandText = sqlQuery
            myCommand.Parameters.Clear()

            ' Ajouter les paramètres
            myCommand.Parameters.AddWithValue("?", dtpDateVisite.Value.Date)
            myCommand.Parameters.AddWithValue("?", txtMotif.Text.Trim())
            myCommand.Parameters.AddWithValue("?", txtBilan.Text.Trim()) ' Utilise txtBilan pour le contenu
            myCommand.Parameters.AddWithValue("?", RapportID)

            ' Exécuter la mise à jour
            Dim rowsAffected As Integer = myCommand.ExecuteNonQuery()

            If rowsAffected > 0 Then
                MessageBox.Show("Rapport mis à jour avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Définir le résultat du dialogue sur OK pour indiquer une modification réussie
                Me.DialogResult = DialogResult.OK
                Me.Close()
            Else
                MessageBox.Show("Aucune modification n'a été effectuée.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Erreur lors de la mise à jour du rapport: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Fermer la connexion
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
        End Try
    End Sub

    ' Méthode pour annuler et fermer le formulaire
    Private Sub btnAnnuler_Click(sender As Object, e As EventArgs) Handles btnAnnuler.Click
        ' Définir le résultat du dialogue sur Cancel pour indiquer qu'aucune modification n'a été effectuée
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class