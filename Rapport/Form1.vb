Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Ajout des éléments à la ListBox
        MedicSelect.Items.AddRange(New String() {
        "Ibuprofène",
        "Paracétamol",
        "Amoxicilline",
        "Azithromycine",
        "Cétirizine",
        "Loratadine",
        "Oméprazole",
        "Pantoprazole",
        "Métoprolol",
        "Atorvastatine",
        "Simvastatine",
        "Losartan",
        "Amlodipine",
        "Prednisone",
        "Clarithromycine"
    })
    End Sub

    Private Sub CheckedListBox1_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles MedicSelect.ItemCheck
        ' Déclarer une liste temporaire pour stocker les éléments cochés
        Dim selectedItems As New List(Of String)

        ' Ajouter tous les éléments actuellement cochés à la liste
        For Each item In MedicSelect.CheckedItems
            selectedItems.Add(item.ToString())
        Next

        ' Vérifier si l'élément sélectionné est en cours de coche ou de décoche
        If e.NewValue = CheckState.Checked Then
            ' Si l'élément est en cours de coche, on l'ajoute à la liste temporaire
            selectedItems.Add(MedicSelect.Items(e.Index).ToString())
        ElseIf e.NewValue = CheckState.Unchecked Then
            ' Si l'élément est en cours de décoche, on le retire de la liste temporaire
            selectedItems.Remove(MedicSelect.Items(e.Index).ToString())
        End If
    End Sub

    Private Sub logout_Click(sender As Object, e As EventArgs) Handles logout.Click
        MessageBox.Show("Vous avez été deconnecté !")
    End Sub
End Class
