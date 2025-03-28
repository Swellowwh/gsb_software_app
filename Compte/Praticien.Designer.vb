<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Praticien
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
        Me.LblTitre = New System.Windows.Forms.Label()
        Me.PnlTitre = New System.Windows.Forms.Panel()
        Me.GrpInfos = New System.Windows.Forms.GroupBox()
        Me.LblNom = New System.Windows.Forms.Label()
        Me.TxtNom = New System.Windows.Forms.TextBox()
        Me.LblPrenom = New System.Windows.Forms.Label()
        Me.TxtPrenom = New System.Windows.Forms.TextBox()
        Me.LblSpecialite = New System.Windows.Forms.Label()
        Me.CmbSpecialite = New System.Windows.Forms.ComboBox()
        Me.LblAdresse = New System.Windows.Forms.Label()
        Me.TxtAdresse = New System.Windows.Forms.TextBox()
        Me.LblTel = New System.Windows.Forms.Label()
        Me.TxtTel = New System.Windows.Forms.TextBox()
        Me.LblEmail = New System.Windows.Forms.Label()
        Me.TxtEmail = New System.Windows.Forms.TextBox()
        Me.GrpActions = New System.Windows.Forms.GroupBox()
        Me.BtnNouveau = New System.Windows.Forms.Button()
        Me.BtnEnregistrer = New System.Windows.Forms.Button()
        Me.BtnModifier = New System.Windows.Forms.Button()
        Me.BtnSupprimer = New System.Windows.Forms.Button()
        Me.DgvPraticiens = New System.Windows.Forms.DataGridView()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.LblStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.PnlTitre.SuspendLayout()
        Me.GrpInfos.SuspendLayout()
        Me.GrpActions.SuspendLayout()
        CType(Me.DgvPraticiens, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblTitre
        '
        Me.LblTitre.AutoSize = True
        Me.LblTitre.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitre.ForeColor = System.Drawing.Color.White
        Me.LblTitre.Location = New System.Drawing.Point(12, 15)
        Me.LblTitre.Name = "LblTitre"
        Me.LblTitre.Size = New System.Drawing.Size(257, 25)
        Me.LblTitre.TabIndex = 0
        Me.LblTitre.Text = "Gestion des Praticiens"
        '
        'PnlTitre
        '
        Me.PnlTitre.BackColor = System.Drawing.Color.SteelBlue
        Me.PnlTitre.Controls.Add(Me.LblTitre)
        Me.PnlTitre.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlTitre.Location = New System.Drawing.Point(0, 0)
        Me.PnlTitre.Name = "PnlTitre"
        Me.PnlTitre.Size = New System.Drawing.Size(800, 55)
        Me.PnlTitre.TabIndex = 0
        '
        'GrpInfos
        '
        Me.GrpInfos.Controls.Add(Me.LblNom)
        Me.GrpInfos.Controls.Add(Me.TxtNom)
        Me.GrpInfos.Controls.Add(Me.LblPrenom)
        Me.GrpInfos.Controls.Add(Me.TxtPrenom)
        Me.GrpInfos.Controls.Add(Me.LblSpecialite)
        Me.GrpInfos.Controls.Add(Me.CmbSpecialite)
        Me.GrpInfos.Controls.Add(Me.LblAdresse)
        Me.GrpInfos.Controls.Add(Me.TxtAdresse)
        Me.GrpInfos.Controls.Add(Me.LblTel)
        Me.GrpInfos.Controls.Add(Me.TxtTel)
        Me.GrpInfos.Controls.Add(Me.LblEmail)
        Me.GrpInfos.Controls.Add(Me.TxtEmail)
        Me.GrpInfos.Location = New System.Drawing.Point(12, 70)
        Me.GrpInfos.Name = "GrpInfos"
        Me.GrpInfos.Size = New System.Drawing.Size(365, 250)
        Me.GrpInfos.TabIndex = 1
        Me.GrpInfos.TabStop = False
        Me.GrpInfos.Text = "Informations du praticien"
        '
        'LblNom
        '
        Me.LblNom.AutoSize = True
        Me.LblNom.Location = New System.Drawing.Point(15, 30)
        Me.LblNom.Name = "LblNom"
        Me.LblNom.Size = New System.Drawing.Size(35, 13)
        Me.LblNom.TabIndex = 0
        Me.LblNom.Text = "Nom :"
        '
        'TxtNom
        '
        Me.TxtNom.Location = New System.Drawing.Point(120, 27)
        Me.TxtNom.Name = "TxtNom"
        Me.TxtNom.Size = New System.Drawing.Size(220, 20)
        Me.TxtNom.TabIndex = 1
        '
        'LblPrenom
        '
        Me.LblPrenom.AutoSize = True
        Me.LblPrenom.Location = New System.Drawing.Point(15, 60)
        Me.LblPrenom.Name = "LblPrenom"
        Me.LblPrenom.Size = New System.Drawing.Size(49, 13)
        Me.LblPrenom.TabIndex = 2
        Me.LblPrenom.Text = "Prénom :"
        '
        'TxtPrenom
        '
        Me.TxtPrenom.Location = New System.Drawing.Point(120, 57)
        Me.TxtPrenom.Name = "TxtPrenom"
        Me.TxtPrenom.Size = New System.Drawing.Size(220, 20)
        Me.TxtPrenom.TabIndex = 3
        '
        'LblSpecialite
        '
        Me.LblSpecialite.AutoSize = True
        Me.LblSpecialite.Location = New System.Drawing.Point(15, 90)
        Me.LblSpecialite.Name = "LblSpecialite"
        Me.LblSpecialite.Size = New System.Drawing.Size(62, 13)
        Me.LblSpecialite.TabIndex = 4
        Me.LblSpecialite.Text = "Spécialité :"
        '
        'CmbSpecialite
        '
        Me.CmbSpecialite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbSpecialite.FormattingEnabled = True
        Me.CmbSpecialite.Items.AddRange(New Object() {"Médecin généraliste", "Cardiologue", "Dermatologue", "Ophtalmologue", "ORL", "Pédiatre", "Psychiatre", "Radiologue", "Autre"})
        Me.CmbSpecialite.Location = New System.Drawing.Point(120, 87)
        Me.CmbSpecialite.Name = "CmbSpecialite"
        Me.CmbSpecialite.Size = New System.Drawing.Size(220, 21)
        Me.CmbSpecialite.TabIndex = 5
        '
        'LblAdresse
        '
        Me.LblAdresse.AutoSize = True
        Me.LblAdresse.Location = New System.Drawing.Point(15, 120)
        Me.LblAdresse.Name = "LblAdresse"
        Me.LblAdresse.Size = New System.Drawing.Size(51, 13)
        Me.LblAdresse.TabIndex = 6
        Me.LblAdresse.Text = "Adresse :"
        '
        'TxtAdresse
        '
        Me.TxtAdresse.Location = New System.Drawing.Point(120, 117)
        Me.TxtAdresse.Multiline = True
        Me.TxtAdresse.Name = "TxtAdresse"
        Me.TxtAdresse.Size = New System.Drawing.Size(220, 40)
        Me.TxtAdresse.TabIndex = 7
        '
        'LblTel
        '
        Me.LblTel.AutoSize = True
        Me.LblTel.Location = New System.Drawing.Point(15, 170)
        Me.LblTel.Name = "LblTel"
        Me.LblTel.Size = New System.Drawing.Size(64, 13)
        Me.LblTel.TabIndex = 8
        Me.LblTel.Text = "Téléphone :"
        '
        'TxtTel
        '
        Me.TxtTel.Location = New System.Drawing.Point(120, 167)
        Me.TxtTel.Name = "TxtTel"
        Me.TxtTel.Size = New System.Drawing.Size(220, 20)
        Me.TxtTel.TabIndex = 9
        '
        'LblEmail
        '
        Me.LblEmail.AutoSize = True
        Me.LblEmail.Location = New System.Drawing.Point(15, 200)
        Me.LblEmail.Name = "LblEmail"
        Me.LblEmail.Size = New System.Drawing.Size(38, 13)
        Me.LblEmail.TabIndex = 10
        Me.LblEmail.Text = "Email :"
        '
        'TxtEmail
        '
        Me.TxtEmail.Location = New System.Drawing.Point(120, 197)
        Me.TxtEmail.Name = "TxtEmail"
        Me.TxtEmail.Size = New System.Drawing.Size(220, 20)
        Me.TxtEmail.TabIndex = 11
        '
        'GrpActions
        '
        Me.GrpActions.Controls.Add(Me.BtnNouveau)
        Me.GrpActions.Controls.Add(Me.BtnEnregistrer)
        Me.GrpActions.Controls.Add(Me.BtnModifier)
        Me.GrpActions.Controls.Add(Me.BtnSupprimer)
        Me.GrpActions.Location = New System.Drawing.Point(12, 330)
        Me.GrpActions.Name = "GrpActions"
        Me.GrpActions.Size = New System.Drawing.Size(365, 75)
        Me.GrpActions.TabIndex = 2
        Me.GrpActions.TabStop = False
        Me.GrpActions.Text = "Actions"
        '
        'BtnNouveau
        '
        Me.BtnNouveau.BackColor = System.Drawing.Color.LightSteelBlue
        Me.BtnNouveau.Location = New System.Drawing.Point(15, 30)
        Me.BtnNouveau.Name = "BtnNouveau"
        Me.BtnNouveau.Size = New System.Drawing.Size(75, 30)
        Me.BtnNouveau.TabIndex = 0
        Me.BtnNouveau.Text = "Nouveau"
        Me.BtnNouveau.UseVisualStyleBackColor = False
        '
        'BtnEnregistrer
        '
        Me.BtnEnregistrer.BackColor = System.Drawing.Color.LightGreen
        Me.BtnEnregistrer.Location = New System.Drawing.Point(96, 30)
        Me.BtnEnregistrer.Name = "BtnEnregistrer"
        Me.BtnEnregistrer.Size = New System.Drawing.Size(85, 30)
        Me.BtnEnregistrer.TabIndex = 1
        Me.BtnEnregistrer.Text = "Enregistrer"
        Me.BtnEnregistrer.UseVisualStyleBackColor = False
        '
        'BtnModifier
        '
        Me.BtnModifier.BackColor = System.Drawing.Color.Khaki
        Me.BtnModifier.Location = New System.Drawing.Point(187, 30)
        Me.BtnModifier.Name = "BtnModifier"
        Me.BtnModifier.Size = New System.Drawing.Size(75, 30)
        Me.BtnModifier.TabIndex = 2
        Me.BtnModifier.Text = "Modifier"
        Me.BtnModifier.UseVisualStyleBackColor = False
        '
        'BtnSupprimer
        '
        Me.BtnSupprimer.BackColor = System.Drawing.Color.LightCoral
        Me.BtnSupprimer.Location = New System.Drawing.Point(268, 30)
        Me.BtnSupprimer.Name = "BtnSupprimer"
        Me.BtnSupprimer.Size = New System.Drawing.Size(75, 30)
        Me.BtnSupprimer.TabIndex = 3
        Me.BtnSupprimer.Text = "Supprimer"
        Me.BtnSupprimer.UseVisualStyleBackColor = False
        '
        'DgvPraticiens
        '
        Me.DgvPraticiens.AllowUserToAddRows = False
        Me.DgvPraticiens.AllowUserToDeleteRows = False
        Me.DgvPraticiens.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DgvPraticiens.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DgvPraticiens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvPraticiens.Location = New System.Drawing.Point(390, 70)
        Me.DgvPraticiens.MultiSelect = False
        Me.DgvPraticiens.Name = "DgvPraticiens"
        Me.DgvPraticiens.ReadOnly = True
        Me.DgvPraticiens.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgvPraticiens.Size = New System.Drawing.Size(398, 335)
        Me.DgvPraticiens.TabIndex = 3
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LblStatus})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 428)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(800, 22)
        Me.StatusStrip.TabIndex = 4
        Me.StatusStrip.Text = "StatusStrip1"
        '
        'LblStatus
        '
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(29, 17)
        Me.LblStatus.Text = "Prêt"
        '
        'Praticien
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.DgvPraticiens)
        Me.Controls.Add(Me.GrpActions)
        Me.Controls.Add(Me.GrpInfos)
        Me.Controls.Add(Me.PnlTitre)
        Me.Name = "Praticien"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gestion des Praticiens"
        Me.PnlTitre.ResumeLayout(False)
        Me.PnlTitre.PerformLayout()
        Me.GrpInfos.ResumeLayout(False)
        Me.GrpInfos.PerformLayout()
        Me.GrpActions.ResumeLayout(False)
        CType(Me.DgvPraticiens, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LblTitre As Label
    Friend WithEvents PnlTitre As Panel
    Friend WithEvents GrpInfos As GroupBox
    Friend WithEvents LblNom As Label
    Friend WithEvents TxtNom As TextBox
    Friend WithEvents LblPrenom As Label
    Friend WithEvents TxtPrenom As TextBox
    Friend WithEvents LblSpecialite As Label
    Friend WithEvents CmbSpecialite As ComboBox
    Friend WithEvents LblAdresse As Label
    Friend WithEvents TxtAdresse As TextBox
    Friend WithEvents LblTel As Label
    Friend WithEvents TxtTel As TextBox
    Friend WithEvents LblEmail As Label
    Friend WithEvents TxtEmail As TextBox
    Friend WithEvents GrpActions As GroupBox
    Friend WithEvents BtnNouveau As Button
    Friend WithEvents BtnEnregistrer As Button
    Friend WithEvents BtnModifier As Button
    Friend WithEvents BtnSupprimer As Button
    Friend WithEvents DgvPraticiens As DataGridView
    Friend WithEvents StatusStrip As StatusStrip
    Friend WithEvents LblStatus As ToolStripStatusLabel
End Class