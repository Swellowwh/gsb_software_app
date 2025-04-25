Public Class Praticien
    ' Propriétés utilisateur
    Public Property UserID As String
    Public Property UserName As String
    Public Property UserRole As String

    ' Cette méthode s'exécute lorsque le formulaire est chargé
    Private Sub Praticien_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Personnaliser le message si un nom d'utilisateur est disponible
        If Not String.IsNullOrEmpty(UserName) Then
            LblMessage.Text = $"Bonjour Dr. {UserName}," & vbCrLf & vbCrLf &
                            "Vous êtes connecté en tant que praticien."

            ' Mettre à jour le titre avec le nom du praticien
            LblTitre.Text = $"Espace Praticien - Dr. {UserName}"
        End If
    End Sub

    ' Méthode pour gérer le clic sur le bouton Fermer
    Private Sub BtnFermer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFermer.Click
        ' Fermer le formulaire
        Me.Close()
    End Sub

    Private Sub LblMessage_Click(sender As Object, e As EventArgs) Handles LblMessage.Click

    End Sub
End Class