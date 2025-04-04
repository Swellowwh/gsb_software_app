<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CreateRapport
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lblTitre = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.btnEnregistrer = New System.Windows.Forms.Button()
        Me.btnAnnuler = New System.Windows.Forms.Button()
        Me.lblMedecin = New System.Windows.Forms.Label()
        Me.txtMedecin = New System.Windows.Forms.TextBox()
        Me.lblContenu = New System.Windows.Forms.Label()
        Me.txtContenu = New System.Windows.Forms.TextBox()
        Me.lblProduits = New System.Windows.Forms.Label()
        Me.cmbProduits = New System.Windows.Forms.ComboBox()
        Me.btnAjouterProduit = New System.Windows.Forms.Button()
        Me.lstProduits = New System.Windows.Forms.ListBox()
        Me.nudQuantite = New System.Windows.Forms.NumericUpDown()
        Me.lblQuantite = New System.Windows.Forms.Label()
        Me.btnSupprimerProduit = New System.Windows.Forms.Button()
        Me.lblCommentaire = New System.Windows.Forms.Label()
        Me.txtCommentaire = New System.Windows.Forms.TextBox()
        Me.pnlProduits = New System.Windows.Forms.Panel()
        CType(Me.nudQuantite, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlProduits.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitre
        '
        Me.lblTitre.AutoSize = True
        Me.lblTitre.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitre.Location = New System.Drawing.Point(12, 9)
        Me.lblTitre.Name = "lblTitre"
        Me.lblTitre.Size = New System.Drawing.Size(201, 24)
        Me.lblTitre.TabIndex = 0
        Me.lblTitre.Text = "Création de Rapports"
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Location = New System.Drawing.Point(16, 55)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(36, 13)
        Me.lblDate.TabIndex = 3
        Me.lblDate.Text = "Date :"
        '
        'dtpDate
        '
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDate.Location = New System.Drawing.Point(89, 52)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(100, 20)
        Me.dtpDate.TabIndex = 4
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Location = New System.Drawing.Point(16, 85)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(69, 13)
        Me.lblDescription.TabIndex = 9
        Me.lblDescription.Text = "Motif du rapport :"
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(89, 85)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescription.Size = New System.Drawing.Size(447, 80)
        Me.txtDescription.TabIndex = 10
        '
        'lblMedecin
        '
        Me.lblMedecin.AutoSize = True
        Me.lblMedecin.Location = New System.Drawing.Point(16, 180)
        Me.lblMedecin.Name = "lblMedecin"
        Me.lblMedecin.Size = New System.Drawing.Size(54, 13)
        Me.lblMedecin.TabIndex = 11
        Me.lblMedecin.Text = "Médecin :"
        '
        'txtMedecin
        '
        Me.txtMedecin.Location = New System.Drawing.Point(89, 180)
        Me.txtMedecin.Name = "txtMedecin"
        Me.txtMedecin.Size = New System.Drawing.Size(200, 20)
        Me.txtMedecin.TabIndex = 12
        '
        'lblContenu
        '
        Me.lblContenu.AutoSize = True
        Me.lblContenu.Location = New System.Drawing.Point(16, 215)
        Me.lblContenu.Name = "lblContenu"
        Me.lblContenu.Size = New System.Drawing.Size(54, 13)
        Me.lblContenu.TabIndex = 13
        Me.lblContenu.Text = "Contenu :"
        '
        'txtContenu
        '
        Me.txtContenu.Location = New System.Drawing.Point(89, 215)
        Me.txtContenu.Multiline = True
        Me.txtContenu.Name = "txtContenu"
        Me.txtContenu.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtContenu.Size = New System.Drawing.Size(447, 80)
        Me.txtContenu.TabIndex = 14
        '
        'lblProduits
        '
        Me.lblProduits.AutoSize = True
        Me.lblProduits.Location = New System.Drawing.Point(3, 10)
        Me.lblProduits.Name = "lblProduits"
        Me.lblProduits.Size = New System.Drawing.Size(46, 13)
        Me.lblProduits.TabIndex = 15
        Me.lblProduits.Text = "Produit :"
        '
        'cmbProduits
        '
        Me.cmbProduits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProduits.FormattingEnabled = True
        Me.cmbProduits.Location = New System.Drawing.Point(86, 7)
        Me.cmbProduits.Name = "cmbProduits"
        Me.cmbProduits.Size = New System.Drawing.Size(200, 21)
        Me.cmbProduits.TabIndex = 16
        '
        'btnAjouterProduit
        '
        Me.btnAjouterProduit.Location = New System.Drawing.Point(86, 90)
        Me.btnAjouterProduit.Name = "btnAjouterProduit"
        Me.btnAjouterProduit.Size = New System.Drawing.Size(125, 23)
        Me.btnAjouterProduit.TabIndex = 17
        Me.btnAjouterProduit.Text = "Ajouter le produit"
        Me.btnAjouterProduit.UseVisualStyleBackColor = True
        '
        'lstProduits
        '
        Me.lstProduits.FormattingEnabled = True
        Me.lstProduits.Location = New System.Drawing.Point(6, 125)
        Me.lstProduits.Name = "lstProduits"
        Me.lstProduits.Size = New System.Drawing.Size(447, 95)
        Me.lstProduits.TabIndex = 18
        '
        'nudQuantite
        '
        Me.nudQuantite.Location = New System.Drawing.Point(86, 37)
        Me.nudQuantite.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudQuantite.Name = "nudQuantite"
        Me.nudQuantite.Size = New System.Drawing.Size(73, 20)
        Me.nudQuantite.TabIndex = 19
        Me.nudQuantite.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblQuantite
        '
        Me.lblQuantite.AutoSize = True
        Me.lblQuantite.Location = New System.Drawing.Point(3, 39)
        Me.lblQuantite.Name = "lblQuantite"
        Me.lblQuantite.Size = New System.Drawing.Size(56, 13)
        Me.lblQuantite.TabIndex = 20
        Me.lblQuantite.Text = "Quantité :"
        '
        'btnSupprimerProduit
        '
        Me.btnSupprimerProduit.Location = New System.Drawing.Point(217, 90)
        Me.btnSupprimerProduit.Name = "btnSupprimerProduit"
        Me.btnSupprimerProduit.Size = New System.Drawing.Size(125, 23)
        Me.btnSupprimerProduit.TabIndex = 21
        Me.btnSupprimerProduit.Text = "Supprimer le produit"
        Me.btnSupprimerProduit.UseVisualStyleBackColor = True
        '
        'pnlProduits
        '
        Me.pnlProduits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlProduits.Controls.Add(Me.lblProduits)
        Me.pnlProduits.Controls.Add(Me.txtCommentaire)
        Me.pnlProduits.Controls.Add(Me.cmbProduits)
        Me.pnlProduits.Controls.Add(Me.lblCommentaire)
        Me.pnlProduits.Controls.Add(Me.btnAjouterProduit)
        Me.pnlProduits.Controls.Add(Me.btnSupprimerProduit)
        Me.pnlProduits.Controls.Add(Me.lstProduits)
        Me.pnlProduits.Controls.Add(Me.lblQuantite)
        Me.pnlProduits.Controls.Add(Me.nudQuantite)
        Me.pnlProduits.Location = New System.Drawing.Point(19, 310)
        Me.pnlProduits.Name = "pnlProduits"
        Me.pnlProduits.Size = New System.Drawing.Size(517, 230)
        Me.pnlProduits.TabIndex = 24
        '
        'btnEnregistrer
        '
        Me.btnEnregistrer.Location = New System.Drawing.Point(89, 555)
        Me.btnEnregistrer.Name = "btnEnregistrer"
        Me.btnEnregistrer.Size = New System.Drawing.Size(100, 25)
        Me.btnEnregistrer.TabIndex = 25
        Me.btnEnregistrer.Text = "Enregistrer"
        Me.btnEnregistrer.UseVisualStyleBackColor = True
        '
        'btnAnnuler
        '
        Me.btnAnnuler.Location = New System.Drawing.Point(195, 555)
        Me.btnAnnuler.Name = "btnAnnuler"
        Me.btnAnnuler.Size = New System.Drawing.Size(100, 25)
        Me.btnAnnuler.TabIndex = 26
        Me.btnAnnuler.Text = "Annuler"
        Me.btnAnnuler.UseVisualStyleBackColor = True
        '
        'CreateRapport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(554, 592)
        Me.Controls.Add(Me.btnAnnuler)
        Me.Controls.Add(Me.btnEnregistrer)
        Me.Controls.Add(Me.pnlProduits)
        Me.Controls.Add(Me.txtContenu)
        Me.Controls.Add(Me.lblContenu)
        Me.Controls.Add(Me.txtMedecin)
        Me.Controls.Add(Me.lblMedecin)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.dtpDate)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.lblTitre)
        Me.Name = "CreateRapport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Création de Rapports"
        CType(Me.nudQuantite, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlProduits.ResumeLayout(False)
        Me.pnlProduits.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub

    Friend WithEvents lblTitre As Label
    Friend WithEvents lblDate As Label
    Friend WithEvents dtpDate As DateTimePicker
    Friend WithEvents lblDescription As Label
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents lblMedecin As Label
    Friend WithEvents txtMedecin As TextBox
    Friend WithEvents lblContenu As Label
    Friend WithEvents txtContenu As TextBox
    Friend WithEvents lblProduits As Label
    Friend WithEvents cmbProduits As ComboBox
    Friend WithEvents btnAjouterProduit As Button
    Friend WithEvents lstProduits As ListBox
    Friend WithEvents nudQuantite As NumericUpDown
    Friend WithEvents lblQuantite As Label
    Friend WithEvents btnSupprimerProduit As Button
    Friend WithEvents lblCommentaire As Label
    Friend WithEvents txtCommentaire As TextBox
    Friend WithEvents pnlProduits As Panel
    Friend WithEvents btnEnregistrer As Button
    Friend WithEvents btnAnnuler As Button
End Class