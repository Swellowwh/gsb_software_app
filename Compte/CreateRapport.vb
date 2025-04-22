Imports System.Data
Imports System.Data.Odbc

Public Class CreateRapport
    ' MODIFIÉ : Suppression des variables de connexion globales
    ' Supprimé : Private myConnection As New Odbc.OdbcConnection
    ' Supprimé : Private connString As String = "DSN=CnxOracleFermeD25;Uid=SLAM7;Pwd=slam7;"

    ' Variables globales restantes
    Private myCommand As New Odbc.OdbcCommand
    Private myReader As Odbc.OdbcDataReader

    ' Structure pour stocker les produits sélectionnés
    Private Structure ProduitSelectionne
        Public ID As Integer
        Public Libelle As String
        Public Quantite As Integer
        Public Commentaire As String

        Public Overrides Function ToString() As String
            Return Libelle & " - Qté: " & Quantite & If(Not String.IsNullOrEmpty(Commentaire), " - " & Commentaire, "")
        End Function
    End Structure

    ' Liste des produits disponibles
    Private produits As New Dictionary(Of Integer, String)

    ' Liste des produits sélectionnés pour ce rapport
    Private produitsSelectionnes As New List(Of ProduitSelectionne)

    ' Propriétés utilisateur
    Public Property UserID As String = "1"  ' Sera récupéré du formulaire parent
    Public Property UserName As String = "Visiteur Test"
    Public Property UserRole As String = "Visiteur"

    Private Sub CreateRapport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Remplir automatiquement les champs avec des valeurs par défaut
        RemplirChampsParDefaut()

        ' Charger la liste des produits disponibles
        ChargerProduits()
    End Sub

    Private Sub RemplirChampsParDefaut()
        ' Définir la date du jour
        dtpDate.Value = DateTime.Now

        ' Ajouter des valeurs par défaut dans les champs texte
        txtDescription.Text = "Visite effectuée le " & DateTime.Now.ToString("dd/MM/yyyy")
    End Sub

    ' Méthode pour charger les produits depuis la base de données
    Private Sub ChargerProduits()
        Try
            ' MODIFIÉ : Utilisation de ConnectionOracle.GetConnection()
            Dim myConnection = ConnectionOracle.GetConnection()

            ' Requête pour récupérer tous les produits
            myCommand.Connection = myConnection
            myCommand.CommandText = "SELECT PRODUIT_ID, LIBELLE FROM PRODUIT ORDER BY LIBELLE"

            ' Exécuter la requête et lire les résultats
            myReader = myCommand.ExecuteReader()

            ' Vider les collections existantes
            produits.Clear()
            cmbProduits.Items.Clear()

            ' Parcourir les résultats et ajouter les produits à la liste
            While myReader.Read()
                Dim produitID As Integer = Convert.ToInt32(myReader("PRODUIT_ID"))
                Dim libelle As String = myReader("LIBELLE").ToString()

                ' Ajouter au Dictionary
                produits.Add(produitID, libelle)

                ' Ajouter au ComboBox
                cmbProduits.Items.Add(libelle)
            End While

            ' Sélectionner le premier produit s'il y en a
            If cmbProduits.Items.Count > 0 Then
                cmbProduits.SelectedIndex = 0
            End If

        Catch ex As Exception
            MessageBox.Show("Erreur lors du chargement des produits: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' MODIFIÉ : Simplifié la fermeture des ressources
            If myReader IsNot Nothing AndAlso Not myReader.IsClosed Then
                myReader.Close()
            End If
            ' SUPPRIMÉ : Plus besoin de fermer la connexion ici
            ' La connexion est gérée par ConnectionOracle
        End Try
    End Sub

    Private Sub btnAjouterProduit_Click(sender As Object, e As EventArgs) Handles btnAjouterProduit.Click
        Try
            ' Vérifier qu'un produit est sélectionné
            If cmbProduits.SelectedIndex < 0 Then
                MessageBox.Show("Veuillez sélectionner un produit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            ' Récupérer le produit sélectionné
            Dim libelleProduit As String = cmbProduits.SelectedItem.ToString()
            Dim produitID As Integer = -1

            ' Trouver l'ID du produit à partir de son libellé
            For Each kvp As KeyValuePair(Of Integer, String) In produits
                If kvp.Value = libelleProduit Then
                    produitID = kvp.Key
                    Exit For
                End If
            Next

            ' Vérifier que l'ID a été trouvé
            If produitID = -1 Then
                MessageBox.Show("Impossible de trouver l'ID du produit sélectionné.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Créer une nouvelle structure ProduitSelectionne
            Dim nouveauProduit As New ProduitSelectionne With {
                .ID = produitID,
                .Libelle = libelleProduit,
                .Quantite = Convert.ToInt32(nudQuantite.Value),
                .Commentaire = txtCommentaire.Text
            }

            ' Ajouter le produit à la liste
            produitsSelectionnes.Add(nouveauProduit)

            ' Mettre à jour la liste visuelle
            MettreAJourListeProduits()

            ' Réinitialiser les contrôles
            nudQuantite.Value = 1
            txtCommentaire.Text = ""

        Catch ex As Exception
            MessageBox.Show("Erreur lors de l'ajout du produit: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSupprimerProduit_Click(sender As Object, e As EventArgs) Handles btnSupprimerProduit.Click
        Try
            ' Vérifier qu'un produit est sélectionné
            If lstProduits.SelectedIndex < 0 Then
                MessageBox.Show("Veuillez sélectionner un produit à supprimer.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            ' Supprimer le produit sélectionné
            produitsSelectionnes.RemoveAt(lstProduits.SelectedIndex)

            ' Mettre à jour la liste visuelle
            MettreAJourListeProduits()

        Catch ex As Exception
            MessageBox.Show("Erreur lors de la suppression du produit: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Méthode pour mettre à jour la liste visuelle des produits
    Private Sub MettreAJourListeProduits()
        lstProduits.Items.Clear()

        For Each produit As ProduitSelectionne In produitsSelectionnes
            lstProduits.Items.Add(produit.ToString())
        Next
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

            ' MODIFIÉ : Utilisation de ConnectionOracle.GetConnection()
            Dim myConnection = ConnectionOracle.GetConnection()

            ' Commencer une transaction
            Dim transaction As OdbcTransaction = myConnection.BeginTransaction()

            Try
                ' Créer la requête SQL pour insérer un nouveau rapport
                myCommand.Connection = myConnection
                myCommand.Transaction = transaction
                myCommand.CommandText = "INSERT INTO RAPPORT_DE_VISITE (DATE_VISITE, MOTIF_VISITE, CONTENU_VISITE, NOM_MEDECIN) " &
                                       "VALUES (?, ?, ?, ?)"

                ' Ajouter les paramètres
                myCommand.Parameters.Clear()
                myCommand.Parameters.AddWithValue("DATE_VISITE", dtpDate.Value)
                myCommand.Parameters.AddWithValue("MOTIF_VISITE", txtDescription.Text)
                myCommand.Parameters.AddWithValue("CONTENU_VISITE", txtContenu.Text)
                myCommand.Parameters.AddWithValue("NOM_MEDECIN", txtMedecin.Text)

                ' Exécuter la requête
                Dim nbLignes As Integer = myCommand.ExecuteNonQuery()

                ' Récupérer l'ID du rapport inséré
                Dim rapportID As Integer = -1
                myCommand.CommandText = "SELECT MAX(ID_RAPPORT) FROM RAPPORT_DE_VISITE"
                rapportID = Convert.ToInt32(myCommand.ExecuteScalar())

                ' Insérer les produits associés à ce rapport
                If produitsSelectionnes.Count > 0 Then
                    For Each produit As ProduitSelectionne In produitsSelectionnes
                        ' MODIFIÉ : Correction du nombre de paramètres (3 au lieu de 4)
                        myCommand.CommandText = "INSERT INTO RAPPORT_PRODUIT (ID_RAPPORT, PRODUIT_ID, QUANTITE) " &
                                               "VALUES (?, ?, ?)"

                        myCommand.Parameters.Clear()
                        myCommand.Parameters.AddWithValue("ID_RAPPORT", rapportID)
                        myCommand.Parameters.AddWithValue("PRODUIT_ID", produit.ID)
                        myCommand.Parameters.AddWithValue("QUANTITE", produit.Quantite)

                        myCommand.ExecuteNonQuery()
                    Next
                End If

                ' Valider la transaction
                transaction.Commit()

                MessageBox.Show("Rapport enregistré avec succès!", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.DialogResult = DialogResult.OK
                Me.Close()  ' Fermer le formulaire après enregistrement

            Catch ex As Exception
                ' En cas d'erreur, annuler la transaction
                transaction.Rollback()
                Throw ' Relancer l'exception pour qu'elle soit attrapée par le bloc catch externe
            End Try

        Catch ex As Exception
            MessageBox.Show("Erreur lors de l'enregistrement du rapport: " & ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' SUPPRIMÉ : Plus besoin de fermer la connexion ici
            ' La connexion est gérée par ConnectionOracle
        End Try
    End Sub

    Private Sub btnAnnuler_Click(sender As Object, e As EventArgs) Handles btnAnnuler.Click
        ' Fermer le formulaire sans enregistrer
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub txtDescription_TextChanged(sender As Object, e As EventArgs) Handles txtDescription.TextChanged

    End Sub
End Class