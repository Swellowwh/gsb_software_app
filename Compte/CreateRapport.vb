Imports System.Data
Imports System.Data.Odbc

Public Class CreateRapport
    ' Déclaration des variables de connexion
    Private myConnection As New Odbc.OdbcConnection
    Private myCommand As New Odbc.OdbcCommand
    Private myReader As Odbc.OdbcDataReader
    Private connString As String = "DSN=CnxOracleFermeD25;Uid=SLAM7;Pwd=slam7;"

    ' Propriétés utilisateur
    Public Property UserID As String = "1"  ' Sera récupéré du formulaire parent
    Public Property UserName As String = "Visiteur Test"
    Public Property UserRole As String = "Visiteur"

    Private Sub CreateRapport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Remplir automatiquement les champs avec des valeurs par défaut
        RemplirChampsParDefaut()
    End Sub

    Private Sub RemplirChampsParDefaut()
        ' Définir la date du jour
        dtpDate.Value = DateTime.Now

        ' Ajouter des valeurs par défaut dans les champs texte
        txtDescription.Text = "Visite effectuée le " & DateTime.Now.ToString("dd/MM/yyyy")
    End Sub

    Private Sub btnEnregistrer_Click(sender As Object, e As EventArgs) Handles btnEnregistrer.Click
        Try
            ' Vérifier les champs obligatoires
            If String.IsNullOrWhiteSpace(txtDescription.Text) Then
                MessageBox.Show("Veuillez saisir une description.", "Champ manquant", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtDescription.Focus()
                Return
            End If

            ' Préparer la connexion
            myConnection.ConnectionString = connString
            myConnection.Open()

            ' Créer la requête SQL pour insérer un nouveau rapport
            myCommand.Connection = myConnection
            myCommand.CommandText = "INSERT INTO RAPPORT_DE_VISITE (DATE_VISITE, MOTIF_VISITE, ID_VISITEUR) " &
                                   "VALUES (?, ?, ?)"

            ' Ajouter les paramètres
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("DATE_VISITE", dtpDate.Value)
            myCommand.Parameters.AddWithValue("MOTIF_VISITE", txtDescription.Text)
            myCommand.Parameters.AddWithValue("ID_VISITEUR", UserID)

            ' Exécuter la requête
            Dim nbLignes As Integer = myCommand.ExecuteNonQuery()

            If nbLignes > 0 Then
                MessageBox.Show("Rapport enregistré avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Close()  ' Fermer le formulaire après enregistrement
            Else
                MessageBox.Show("Aucun rapport n'a été enregistré.", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            MessageBox.Show("Erreur lors de l'enregistrement du rapport: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Fermer la connexion
            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
        End Try
    End Sub

    Private Sub btnAnnuler_Click(sender As Object, e As EventArgs) Handles btnAnnuler.Click
        ' Fermer le formulaire sans enregistrer
        Me.Close()
    End Sub
End Class