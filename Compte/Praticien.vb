Public Class Praticien
    ' Variables pour garder trace de l'état du formulaire
    Private currentPraticienId As Integer = -1
    Private isNewRecord As Boolean = True
    Private isModified As Boolean = False

    ' Structure pour stocker les données d'un praticien (simulé sans BDD)
    Private Structure PraticienData
        Public Id As Integer
        Public Nom As String
        Public Prenom As String
        Public Specialite As String
        Public Adresse As String
        Public Telephone As String
        Public Email As String
    End Structure

    ' Liste simulée pour stocker les praticiens (remplace une BDD)
    Private praticiens As New List(Of PraticienData)

    Private Sub Praticien_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Initialisation des contrôles et de l'interface
        InitialiserInterface()

        ' Chargement des données de test
        ChargerDonneesTest()

        ' Rafraîchir la liste des praticiens
        RafraichirListePraticiens()
    End Sub

    Private Sub InitialiserInterface()
        ' Initialisation des contrôles à leur état par défaut
        ViderChamps()

        ' Désactiver les boutons qui ne sont pas pertinents au démarrage
        BtnModifier.Enabled = False
        BtnSupprimer.Enabled = False

        ' Sélectionner la première spécialité dans la liste
        If CmbSpecialite.Items.Count > 0 Then
            CmbSpecialite.SelectedIndex = 0
        End If

        ' Mise à jour de la barre de statut
        LblStatus.Text = "Prêt"
    End Sub

    Private Sub ChargerDonneesTest()
        ' Ajouter quelques données de test pour démonstration
        Dim praticien1 As New PraticienData
        praticien1.Id = 1
        praticien1.Nom = "Dupont"
        praticien1.Prenom = "Jean"
        praticien1.Specialite = "Médecin généraliste"
        praticien1.Adresse = "15 rue de la Santé, 75000 Paris"
        praticien1.Telephone = "01 23 45 67 89"
        praticien1.Email = "jean.dupont@medecin.fr"
        praticiens.Add(praticien1)

        Dim praticien2 As New PraticienData
        praticien2.Id = 2
        praticien2.Nom = "Martin"
        praticien2.Prenom = "Sophie"
        praticien2.Specialite = "Cardiologue"
        praticien2.Adresse = "25 avenue des Soins, 69000 Lyon"
        praticien2.Telephone = "04 56 78 90 12"
        praticien2.Email = "sophie.martin@cardiologie.fr"
        praticiens.Add(praticien2)

        Dim praticien3 As New PraticienData
        praticien3.Id = 3
        praticien3.Nom = "Petit"
        praticien3.Prenom = "Pierre"
        praticien3.Specialite = "Dermatologue"
        praticien3.Adresse = "8 boulevard du Soin, 33000 Bordeaux"
        praticien3.Telephone = "05 67 89 01 23"
        praticien3.Email = "pierre.petit@dermatologie.fr"
        praticiens.Add(praticien3)
    End Sub

    Private Sub RafraichirListePraticiens()
        ' Préparer les données pour le DataGridView
        Dim dataTable As New DataTable()
        dataTable.Columns.Add("Id", GetType(Integer))
        dataTable.Columns.Add("Nom", GetType(String))
        dataTable.Columns.Add("Prénom", GetType(String))
        dataTable.Columns.Add("Spécialité", GetType(String))
        dataTable.Columns.Add("Téléphone", GetType(String))

        ' Ajouter les praticiens à la table
        For Each praticien In praticiens
            dataTable.Rows.Add(praticien.Id, praticien.Nom, praticien.Prenom, praticien.Specialite, praticien.Telephone)
        Next

        ' Affecter la source de données au DataGridView
        DgvPraticiens.DataSource = dataTable

        ' Masquer la colonne ID (optionnel)
        ' DgvPraticiens.Columns("Id").Visible = False

        ' Mise à jour de la barre de statut
        LblStatus.Text = $"{praticiens.Count} praticien(s) trouvé(s)"
    End Sub

    Private Sub ViderChamps()
        ' Réinitialiser tous les champs de saisie
        TxtNom.Text = String.Empty
        TxtPrenom.Text = String.Empty
        If CmbSpecialite.Items.Count > 0 Then
            CmbSpecialite.SelectedIndex = 0
        End If
        TxtAdresse.Text = String.Empty
        TxtTel.Text = String.Empty
        TxtEmail.Text = String.Empty

        ' Réinitialiser les variables d'état
        currentPraticienId = -1
        isNewRecord = True
        isModified = False
    End Sub

    Private Sub AfficherPraticien(id As Integer)
        ' Rechercher le praticien par son ID
        Dim praticien = praticiens.Find(Function(p) p.Id = id)

        ' Si trouvé, afficher ses données dans les champs
        If praticien.Id > 0 Then
            currentPraticienId = praticien.Id

            TxtNom.Text = praticien.Nom
            TxtPrenom.Text = praticien.Prenom

            ' Trouver l'index de la spécialité dans la liste déroulante
            Dim specialiteIndex = CmbSpecialite.Items.IndexOf(praticien.Specialite)
            If specialiteIndex >= 0 Then
                CmbSpecialite.SelectedIndex = specialiteIndex
            End If

            TxtAdresse.Text = praticien.Adresse
            TxtTel.Text = praticien.Telephone
            TxtEmail.Text = praticien.Email

            ' Mettre à jour l'état
            isNewRecord = False
            isModified = False

            ' Mettre à jour les boutons
            BtnModifier.Enabled = True
            BtnSupprimer.Enabled = True

            ' Mise à jour de la barre de statut
            LblStatus.Text = $"Praticien #{praticien.Id} sélectionné"
        End If
    End Sub

    Private Function ValiderSaisie() As Boolean
        ' Validation du nom
        If String.IsNullOrWhiteSpace(TxtNom.Text) Then
            MessageBox.Show("Le nom du praticien est obligatoire.", "Erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TxtNom.Focus()
            Return False
        End If

        ' Validation du prénom
        If String.IsNullOrWhiteSpace(TxtPrenom.Text) Then
            MessageBox.Show("Le prénom du praticien est obligatoire.", "Erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TxtPrenom.Focus()
            Return False
        End If

        ' Validation du téléphone (format simplifié)
        If Not String.IsNullOrWhiteSpace(TxtTel.Text) Then
            Dim telRegex As New System.Text.RegularExpressions.Regex("^[0-9 .-]{10,15}$")
            If Not telRegex.IsMatch(TxtTel.Text) Then
                MessageBox.Show("Le numéro de téléphone n'est pas valide.", "Erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TxtTel.Focus()
                Return False
            End If
        End If

        ' Validation de l'email (format simplifié)
        If Not String.IsNullOrWhiteSpace(TxtEmail.Text) Then
            Dim emailRegex As New System.Text.RegularExpressions.Regex("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")
            If Not emailRegex.IsMatch(TxtEmail.Text) Then
                MessageBox.Show("L'adresse email n'est pas valide.", "Erreur de validation", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TxtEmail.Focus()
                Return False
            End If
        End If

        ' Si tout est valide
        Return True
    End Function

    Private Sub EnregistrerPraticien()
        ' Valider d'abord les données
        If Not ValiderSaisie() Then
            Return
        End If

        ' Préparer les données du praticien
        Dim praticien As New PraticienData()

        If isNewRecord Then
            ' Générer un nouvel ID (dans une vraie application, ce serait géré par la BDD)
            praticien.Id = If(praticiens.Count > 0, praticiens.Max(Function(p) p.Id) + 1, 1)
        Else
            praticien.Id = currentPraticienId

            ' Supprimer l'ancien enregistrement pour le mettre à jour
            praticiens.RemoveAll(Function(p) p.Id = currentPraticienId)
        End If

        ' Assigner les valeurs depuis les contrôles
        praticien.Nom = TxtNom.Text.Trim()
        praticien.Prenom = TxtPrenom.Text.Trim()
        praticien.Specialite = CmbSpecialite.SelectedItem.ToString()
        praticien.Adresse = TxtAdresse.Text.Trim()
        praticien.Telephone = TxtTel.Text.Trim()
        praticien.Email = TxtEmail.Text.Trim()

        ' Ajouter à la liste
        praticiens.Add(praticien)

        ' Trier la liste par nom (optionnel)
        praticiens = praticiens.OrderBy(Function(p) p.Nom).ThenBy(Function(p) p.Prenom).ToList()

        ' Mettre à jour l'interface
        ViderChamps()
        RafraichirListePraticiens()

        ' Message de confirmation
        Dim message As String = If(isNewRecord,
                                "Le praticien a été ajouté avec succès.",
                                "Le praticien a été mis à jour avec succès.")
        MessageBox.Show(message, "Opération réussie", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' Gestionnaires d'événements pour les boutons
    Private Sub BtnNouveau_Click(sender As Object, e As EventArgs) Handles BtnNouveau.Click
        ' Vider les champs pour un nouvel enregistrement
        ViderChamps()
        TxtNom.Focus()

        ' Mise à jour de la barre de statut
        LblStatus.Text = "Création d'un nouveau praticien..."
    End Sub

    Private Sub BtnEnregistrer_Click(sender As Object, e As EventArgs) Handles BtnEnregistrer.Click
        ' Enregistrer le praticien
        EnregistrerPraticien()
    End Sub

    Private Sub BtnModifier_Click(sender As Object, e As EventArgs) Handles BtnModifier.Click
        ' Vérifier qu'un praticien est bien sélectionné
        If currentPraticienId = -1 Then
            MessageBox.Show("Veuillez d'abord sélectionner un praticien.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Activer le mode modification
        isModified = True

        ' Mise à jour de la barre de statut
        LblStatus.Text = $"Modification du praticien #{currentPraticienId}..."

        ' Donner le focus au premier champ
        TxtNom.Focus()
    End Sub

    Private Sub BtnSupprimer_Click(sender As Object, e As EventArgs) Handles BtnSupprimer.Click
        ' Vérifier qu'un praticien est bien sélectionné
        If currentPraticienId = -1 Then
            MessageBox.Show("Veuillez d'abord sélectionner un praticien.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Demander confirmation avant de supprimer
        Dim result = MessageBox.Show(
            $"Êtes-vous sûr de vouloir supprimer le praticien {TxtNom.Text} {TxtPrenom.Text} ?",
            "Confirmation de suppression",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question,
            MessageBoxDefaultButton.Button2)

        If result = DialogResult.Yes Then
            ' Supprimer le praticien
            praticiens.RemoveAll(Function(p) p.Id = currentPraticienId)

            ' Mettre à jour l'interface
            ViderChamps()
            RafraichirListePraticiens()

            ' Message de confirmation
            MessageBox.Show("Le praticien a été supprimé avec succès.", "Opération réussie", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Mise à jour de la barre de statut
            LblStatus.Text = "Praticien supprimé"
        End If
    End Sub

    ' Gestionnaire d'événement pour la sélection dans le DataGridView
    Private Sub DgvPraticiens_SelectionChanged(sender As Object, e As EventArgs) Handles DgvPraticiens.SelectionChanged
        ' Vérifier qu'une ligne est sélectionnée
        If DgvPraticiens.SelectedRows.Count > 0 Then
            ' Récupérer l'ID du praticien sélectionné
            Dim id As Integer = Convert.ToInt32(DgvPraticiens.SelectedRows(0).Cells("Id").Value)

            ' Afficher les détails du praticien
            AfficherPraticien(id)
        End If
    End Sub

    ' Gestionnaire d'événement pour le clic sur une cellule du DataGridView (alternative à SelectionChanged)
    Private Sub DgvPraticiens_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DgvPraticiens.CellClick
        ' Vérifier que le clic n'est pas sur l'en-tête
        If e.RowIndex >= 0 Then
            ' Récupérer l'ID du praticien
            Dim id As Integer = Convert.ToInt32(DgvPraticiens.Rows(e.RowIndex).Cells("Id").Value)

            ' Afficher les détails du praticien
            AfficherPraticien(id)
        End If
    End Sub

    ' Gestionnaire d'événement pour les modifications des champs
    Private Sub TextBox_TextChanged(sender As Object, e As EventArgs) Handles TxtNom.TextChanged, TxtPrenom.TextChanged, TxtAdresse.TextChanged, TxtTel.TextChanged, TxtEmail.TextChanged
        ' Marquer comme modifié seulement si on est sur un enregistrement existant
        If Not isNewRecord Then
            isModified = True
        End If
    End Sub

    Private Sub ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbSpecialite.SelectedIndexChanged
        ' Marquer comme modifié seulement si on est sur un enregistrement existant
        If Not isNewRecord Then
            isModified = True
        End If
    End Sub

    ' Gestionnaire d'événement pour la fermeture du formulaire
    Private Sub Praticien_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        ' Vérifier s'il y a des modifications non enregistrées
        If isModified Then
            Dim result = MessageBox.Show(
                "Des modifications n'ont pas été enregistrées. Voulez-vous les enregistrer avant de quitter ?",
                "Modifications non enregistrées",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1)

            If result = DialogResult.Yes Then
                ' Enregistrer les modifications
                EnregistrerPraticien()
            ElseIf result = DialogResult.Cancel Then
                ' Annuler la fermeture
                e.Cancel = True
            End If
        End If
    End Sub
End Class