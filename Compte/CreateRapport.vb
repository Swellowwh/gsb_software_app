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

        ' Ajout du nouveau champ pour le contenu du rapport
        AjouterChampContenu()
    End Sub

    Private Sub AjouterChampContenu()
        ' Ajuster la taille du formulaire pour accueillir le nouveau champ
        Me.Height = 380

        ' Créer le label pour le contenu
        Dim lblContenu As New Label()
        lblContenu.AutoSize = True
        lblContenu.Location = New Point(16, 255)
        lblContenu.Name = "lblContenu"
        lblContenu.Size = New System.Drawing.Size(69, 13)
        lblContenu.Text = "Contenu :"
        Me.Controls.Add(lblContenu)

        ' Créer le TextBox pour le contenu
        Dim txtContenu As New TextBox()
        txtContenu.Location = New Point(89, 255)
        txtContenu.Multiline = True
        txtContenu.Name = "txtContenu"
        txtContenu.ScrollBars = ScrollBars.Vertical
        txtContenu.Size = New Size(447, 80)
        Me.Controls.Add(txtContenu)

        ' Repositionner les boutons existants
        btnEnregistrer.Location = New Point(btnEnregistrer.Location.X, 350)
        btnAnnuler.Location = New Point(btnAnnuler.Location.X, 350)
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

            If String.IsNullOrWhiteSpace(txtMedecin.Text) Then
                MessageBox.Show("Veuillez saisir le nom du médecin.", "Champ manquant", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtMedecin.Focus()
                Return
            End If

            ' Récupérer le contenu du rapport
            Dim contenuRapport As String = ""

            For Each control As Control In Me.Controls
                If control.Name = "txtContenu" Then
                    contenuRapport = DirectCast(control, TextBox).Text
                    Exit For
                End If
            Next

            ' Préparer la connexion
            myConnection.ConnectionString = connString
            myConnection.Open()

            ' Créer la requête SQL pour insérer un nouveau rapport
            myCommand.Connection = myConnection
            myCommand.CommandText = "INSERT INTO RAPPORT_DE_VISITE (DATE_VISITE, MOTIF_VISITE, CONTENU_VISITE, NOM_MEDECIN) " &
                                   "VALUES (?, ?, ?, ?)"

            ' Ajouter les paramètres
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("DATE_VISITE", dtpDate.Value)
            myCommand.Parameters.AddWithValue("MOTIF_VISITE", txtDescription.Text)
            myCommand.Parameters.AddWithValue("CONTENU_VISITE", contenuRapport)
            myCommand.Parameters.AddWithValue("NOM_MEDECIN", txtMedecin.Text)

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