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
            ' Modifier la requête pour récupérer également le nom du rôle avec une jointure
            myCommand.Connection = myConnection
            myCommand.CommandText = "SELECT U.ID_USER, U.NOM, U.PRENOM, U.ID_ROLE, R.NOM_ROLE " &
                                   "FROM UTILISATEUR U " &
                                   "JOIN ROLE R ON U.ID_ROLE = R.ID_ROLE " &
                                   "WHERE U.EMAIL = ? AND U.MOT_DE_PASSE = ?"

            ' Utiliser des paramètres pour éviter les injections SQL
            myCommand.Parameters.Clear()
            myCommand.Parameters.AddWithValue("?", txtEmail.Text)
            myCommand.Parameters.AddWithValue("?", txtPassword.Text)

            myReader = myCommand.ExecuteReader()

            If myReader.Read() Then
                ' Utilisateur trouvé
                Dim userID As Integer = myReader.GetInt32(0)
                Dim userNom As String = myReader.GetString(1)
                Dim userPrenom As String = myReader.GetString(2)
                Dim userRoleID As Integer = myReader.GetInt32(3)
                Dim userRoleName As String = myReader.GetString(4) ' Récupérer le nom du rôle

                ' Récupérer l'ID du visiteur si l'utilisateur est un visiteur médical
                Dim visitorID As String = String.Empty
                myReader.Close() ' Fermer le reader actuel

                ' Rechercher l'ID_VISITEUR correspondant à cet utilisateur
                myCommand.CommandText = "SELECT ID_VISITEUR FROM VISITEUR_MEDICAL WHERE ID_USER = ?"
                myCommand.Parameters.Clear()
                myCommand.Parameters.AddWithValue("?", userID)
                myReader = myCommand.ExecuteReader()

                If myReader.Read() Then
                    visitorID = myReader.GetString(0) ' Récupérer l'ID du visiteur
                End If

                ' Fermer le reader et la connexion avant de passer au formulaire suivant
                myReader.Close()
                myConnection.Close()

                ' Message de bienvenue
                MessageBox.Show("Bienvenue " & userNom & " " & userPrenom & " (" & userRoleName & ")",
                               "Connexion réussie !", MessageBoxButtons.OK, MessageBoxIcon.Information)

                ' Vérifier si l'utilisateur a le rôle "praticien" et rediriger vers le formulaire approprié
                If userRoleName.ToLower() = "praticien" Then
                    ' Rediriger vers le formulaire Praticien si l'utilisateur est un praticien
                    Dim praticienForm As New Praticien()

                    ' Vous pouvez également passer des informations utilisateur au formulaire Praticien si nécessaire
                    ' Exemple: praticienForm.UserID = userID
                    ' Exemple: praticienForm.UserName = userNom & " " & userPrenom

                    Me.Hide()
                    praticienForm.Show()
                Else
                    ' Rediriger vers le formulaire LesRapports pour les autres rôles
                    Dim mainForm As New LesRapports()

                    ' Définir les propriétés de l'utilisateur
                    mainForm.UserID = visitorID ' Utiliser l'ID du visiteur si trouvé
                    mainForm.UserName = userNom & " " & userPrenom
                    mainForm.UserRole = userRoleName ' Utiliser le nom du rôle au lieu de l'ID

                    Me.Hide()
                    mainForm.Show()
                End If
            Else
                ' Utilisateur non trouvé
                MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect !",
                               "Erreur d'authentification", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPassword.Text = ""
                txtPassword.Focus()
            End If
        Catch ex As Exception
            ' Erreur de connexion à la base de données
            MessageBox.Show("Erreur de connexion: " & ex.Message,
                           "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub lblPassword_Click(sender As Object, e As EventArgs) Handles lblPassword.Click
        ' Ce gestionnaire d'événements est vide et peut être supprimé s'il n'est pas utilisé
    End Sub
End Class