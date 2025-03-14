Public Class LoginForm
    Dim myConnection As New Odbc.OdbcConnection
    Dim myCommand As New Odbc.OdbcCommand
    Dim myReader As Odbc.OdbcDataReader
    Dim connString As String

    Private Sub LoginForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Centrer le formulaire sur l'écran
        Me.CenterToScreen()
    End Sub

    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
        ' Vérifier si les champs sont remplis
        If txtEmail.Text = "" Then
            MessageBox.Show("Veuillez entrer un nom d'utilisateur !", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtEmail.Focus()
            Return
        End If

        If txtPassword.Text = "" Then
            MessageBox.Show("Veuillez entrer un mot de passe !", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Focus()
            Return
        End If

        ' Tentative de connexion à la base de données
        Try
            ' Configurer la chaîne de connexion avec les identifiants fixés
            connString = "DSN=CnxOracleFermeD25;Uid=SLAM7;Pwd=slam7;"
            myConnection.ConnectionString = connString
            myConnection.Open()

            ' Vérifier si l'utilisateur existe dans la base de données
            myCommand.Connection = myConnection
            myCommand.CommandText = "SELECT ID_USER, NOM, PRENOM, ID_ROLE FROM UTILISATEUR WHERE EMAIL = '" & txtEmail.Text & "'"
            myReader = myCommand.ExecuteReader()

            If myReader.Read() Then
                ' Utilisateur trouvé
                Dim userID As Integer = myReader.GetInt32(0)
                Dim userNom As String = myReader.GetString(1)
                Dim userPrenom As String = myReader.GetString(2)
                Dim userRole As Integer = myReader.GetInt32(3)

                ' Fermer le reader et la connexion avant de passer au formulaire suivant
                myReader.Close()
                myConnection.Close()

                ' Créer une instance du formulaire HomeRapport
                Dim mainForm As New LesRapports()

                ' Vérifier si les propriétés existent dans la classe HomeRapport et les définir
                ' Décommentez ces lignes et assurez-vous que ces propriétés existent dans la classe LesRapports
                mainForm.UserID = userID
                mainForm.UserName = userNom & " " & userPrenom
                mainForm.UserRole = userRole

                MessageBox.Show("Bienvenue " & userNom & " " & userPrenom, "Connexion réussie", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Cacher le formulaire de connexion et afficher le formulaire principal
                Me.Hide()
                mainForm.Show()
            Else
                ' Utilisateur non trouvé
                MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect", "Erreur d'authentification", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPassword.Text = ""
                txtPassword.Focus()
            End If
        Catch ex As Exception
            ' Erreur de connexion à la base de données
            MessageBox.Show("Erreur de connexion: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' S'assurer que les ressources sont libérées
            If myReader IsNot Nothing AndAlso Not myReader.IsClosed Then
                myReader.Close()
            End If

            If myConnection.State = ConnectionState.Open Then
                myConnection.Close()
            End If
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        ' Fermer l'application
        Application.Exit()
    End Sub
End Class
