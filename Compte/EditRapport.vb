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
    Public Property BilanVisite As String

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

                    ' Bilan de visite (si cette colonne existe dans la base de données)
                    Try
                        Dim bilanOrdinal As Integer = reader.GetOrdinal("BILAN")
                        If Not reader.IsDBNull(bilanOrdinal) Then
                            BilanVisite = reader.GetString(bilanOrdinal)
                            txtBilan.Text = BilanVisite
                        End If
                    Catch ex As Exception
                        ' La colonne BILAN n'existe peut-être pas
                        Console.WriteLine("Info: La colonne BILAN n'existe peut-être pas: " & ex.Message)
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

            ' Déterminer si nous devons inclure le bilan dans la mise à jour
            Dim includeBilan As Boolean = False
            Try
                ' Vérifier si la colonne BILAN existe dans la table
                Using checkCmd As New OdbcCommand("SELECT COUNT(*) FROM USER_TAB_COLUMNS WHERE TABLE_NAME = 'RAPPORT_DE_VISITE' AND COLUMN_NAME = 'BILAN'", myConnection)
                    Dim count As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())
                    includeBilan = (count > 0)
                End Using
            Catch ex As Exception
                ' En cas d'erreur, nous supposons que la colonne n'existe pas
                includeBilan = False
                Console.WriteLine("Impossible de vérifier l'existence de la colonne BILAN: " & ex.Message)
            End Try

            ' Créer la commande SQL pour mettre à jour le rapport
            Dim sqlQuery As String
            If includeBilan Then
                sqlQuery = "UPDATE RAPPORT_DE_VISITE SET DATE_VISITE = ?, MOTIF_VISITE = ?, BILAN = ? WHERE ID_RAPPORT = ?"
            Else
                sqlQuery = "UPDATE RAPPORT_DE_VISITE SET DATE_VISITE = ?, MOTIF_VISITE = ? WHERE ID_RAPPORT = ?"
            End If

            myCommand.Connection = myConnection
            myCommand.CommandText = sqlQuery
            myCommand.Parameters.Clear()

            ' Ajouter les paramètres
            myCommand.Parameters.AddWithValue("?", dtpDateVisite.Value.Date)
            myCommand.Parameters.AddWithValue("?", txtMotif.Text.Trim())

            If includeBilan Then
                myCommand.Parameters.AddWithValue("?", txtBilan.Text.Trim())
                myCommand.Parameters.AddWithValue("?", RapportID)
            Else
                myCommand.Parameters.AddWithValue("?", RapportID)
            End If

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