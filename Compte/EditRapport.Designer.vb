<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EditRapport
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
        Me.pnlContent = New System.Windows.Forms.Panel()
        Me.txtMedecin = New System.Windows.Forms.TextBox()
        Me.lblMedecin = New System.Windows.Forms.Label()
        Me.lblRapportId = New System.Windows.Forms.Label()
        Me.txtBilan = New System.Windows.Forms.TextBox()
        Me.lblBilan = New System.Windows.Forms.Label()
        Me.dtpDateVisite = New System.Windows.Forms.DateTimePicker()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.txtMotif = New System.Windows.Forms.TextBox()
        Me.lblMotif = New System.Windows.Forms.Label()
        Me.pnlActions = New System.Windows.Forms.Panel()
        Me.btnAnnuler = New System.Windows.Forms.Button()
        Me.btnEnregistrer = New System.Windows.Forms.Button()
        Me.pnlUserInfo = New System.Windows.Forms.Panel()
        Me.lblUserInfo = New System.Windows.Forms.Label()
        Me.pnlContent.SuspendLayout()
        Me.pnlActions.SuspendLayout()
        Me.pnlUserInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTitre
        '
        Me.lblTitre.BackColor = System.Drawing.Color.LightGray
        Me.lblTitre.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitre.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitre.Location = New System.Drawing.Point(0, 0)
        Me.lblTitre.Name = "lblTitre"
        Me.lblTitre.Padding = New System.Windows.Forms.Padding(10)
        Me.lblTitre.Size = New System.Drawing.Size(600, 50)
        Me.lblTitre.TabIndex = 0
        Me.lblTitre.Text = "Modification d'un rapport de visite"
        Me.lblTitre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlContent
        '
        Me.pnlContent.Controls.Add(Me.txtMedecin)
        Me.pnlContent.Controls.Add(Me.lblMedecin)
        Me.pnlContent.Controls.Add(Me.lblRapportId)
        Me.pnlContent.Controls.Add(Me.txtBilan)
        Me.pnlContent.Controls.Add(Me.lblBilan)
        Me.pnlContent.Controls.Add(Me.dtpDateVisite)
        Me.pnlContent.Controls.Add(Me.lblDate)
        Me.pnlContent.Controls.Add(Me.txtMotif)
        Me.pnlContent.Controls.Add(Me.lblMotif)
        Me.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContent.Location = New System.Drawing.Point(0, 90)
        Me.pnlContent.Name = "pnlContent"
        Me.pnlContent.Padding = New System.Windows.Forms.Padding(20)
        Me.pnlContent.Size = New System.Drawing.Size(600, 360)
        Me.pnlContent.TabIndex = 1
        '
        'txtMedecin
        '
        Me.txtMedecin.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMedecin.Location = New System.Drawing.Point(180, 95)
        Me.txtMedecin.Name = "txtMedecin"
        Me.txtMedecin.Size = New System.Drawing.Size(380, 20)
        Me.txtMedecin.TabIndex = 8
        '
        'lblMedecin
        '
        Me.lblMedecin.AutoSize = True
        Me.lblMedecin.Location = New System.Drawing.Point(20, 95)
        Me.lblMedecin.Name = "lblMedecin"
        Me.lblMedecin.Size = New System.Drawing.Size(92, 13)
        Me.lblMedecin.TabIndex = 7
        Me.lblMedecin.Text = "Nom du médecin:"
        '
        'lblRapportId
        '
        Me.lblRapportId.AutoSize = True
        Me.lblRapportId.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRapportId.Location = New System.Drawing.Point(410, 25)
        Me.lblRapportId.Name = "lblRapportId"
        Me.lblRapportId.Size = New System.Drawing.Size(56, 13)
        Me.lblRapportId.TabIndex = 6
        Me.lblRapportId.Text = "ID: #123"
        '
        'txtBilan
        '
        Me.txtBilan.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtBilan.Location = New System.Drawing.Point(180, 130)
        Me.txtBilan.Multiline = True
        Me.txtBilan.Name = "txtBilan"
        Me.txtBilan.Size = New System.Drawing.Size(380, 210)
        Me.txtBilan.TabIndex = 5
        '
        'lblBilan
        '
        Me.lblBilan.AutoSize = True
        Me.lblBilan.Location = New System.Drawing.Point(20, 130)
        Me.lblBilan.Name = "lblBilan"
        Me.lblBilan.Size = New System.Drawing.Size(85, 13)
        Me.lblBilan.TabIndex = 4
        Me.lblBilan.Text = "Bilan de la visite:"
        '
        'dtpDateVisite
        '
        Me.dtpDateVisite.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpDateVisite.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateVisite.Location = New System.Drawing.Point(180, 20)
        Me.dtpDateVisite.Name = "dtpDateVisite"
        Me.dtpDateVisite.Size = New System.Drawing.Size(200, 20)
        Me.dtpDateVisite.TabIndex = 1
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Location = New System.Drawing.Point(20, 25)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(83, 13)
        Me.lblDate.TabIndex = 0
        Me.lblDate.Text = "Date de la visite:"
        '
        'txtMotif
        '
        Me.txtMotif.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtMotif.Location = New System.Drawing.Point(180, 60)
        Me.txtMotif.Multiline = True
        Me.txtMotif.Name = "txtMotif"
        Me.txtMotif.Size = New System.Drawing.Size(380, 20)
        Me.txtMotif.TabIndex = 3
        '
        'lblMotif
        '
        Me.lblMotif.AutoSize = True
        Me.lblMotif.Location = New System.Drawing.Point(20, 60)
        Me.lblMotif.Name = "lblMotif"
        Me.lblMotif.Size = New System.Drawing.Size(83, 13)
        Me.lblMotif.TabIndex = 2
        Me.lblMotif.Text = "Motif de la visite:"
        '
        'pnlActions
        '
        Me.pnlActions.BackColor = System.Drawing.Color.LightGray
        Me.pnlActions.Controls.Add(Me.btnAnnuler)
        Me.pnlActions.Controls.Add(Me.btnEnregistrer)
        Me.pnlActions.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlActions.Location = New System.Drawing.Point(0, 450)
        Me.pnlActions.Name = "pnlActions"
        Me.pnlActions.Padding = New System.Windows.Forms.Padding(10)
        Me.pnlActions.Size = New System.Drawing.Size(600, 60)
        Me.pnlActions.TabIndex = 2
        '
        'btnAnnuler
        '
        Me.btnAnnuler.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAnnuler.Location = New System.Drawing.Point(480, 15)
        Me.btnAnnuler.Name = "btnAnnuler"
        Me.btnAnnuler.Size = New System.Drawing.Size(100, 30)
        Me.btnAnnuler.TabIndex = 1
        Me.btnAnnuler.Text = "Annuler"
        Me.btnAnnuler.UseVisualStyleBackColor = True
        '
        'btnEnregistrer
        '
        Me.btnEnregistrer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEnregistrer.Location = New System.Drawing.Point(360, 15)
        Me.btnEnregistrer.Name = "btnEnregistrer"
        Me.btnEnregistrer.Size = New System.Drawing.Size(100, 30)
        Me.btnEnregistrer.TabIndex = 0
        Me.btnEnregistrer.Text = "Enregistrer"
        Me.btnEnregistrer.UseVisualStyleBackColor = True
        '
        'pnlUserInfo
        '
        Me.pnlUserInfo.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pnlUserInfo.Controls.Add(Me.lblUserInfo)
        Me.pnlUserInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlUserInfo.Location = New System.Drawing.Point(0, 50)
        Me.pnlUserInfo.Name = "pnlUserInfo"
        Me.pnlUserInfo.Size = New System.Drawing.Size(600, 40)
        Me.pnlUserInfo.TabIndex = 3
        '
        'lblUserInfo
        '
        Me.lblUserInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblUserInfo.Location = New System.Drawing.Point(0, 0)
        Me.lblUserInfo.Name = "lblUserInfo"
        Me.lblUserInfo.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.lblUserInfo.Size = New System.Drawing.Size(600, 40)
        Me.lblUserInfo.TabIndex = 0
        Me.lblUserInfo.Text = "Utilisateur connecté: "
        Me.lblUserInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'EditRapport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 510)
        Me.Controls.Add(Me.pnlContent)
        Me.Controls.Add(Me.pnlActions)
        Me.Controls.Add(Me.pnlUserInfo)
        Me.Controls.Add(Me.lblTitre)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "EditRapport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Modification d'un rapport de visite"
        Me.pnlContent.ResumeLayout(False)
        Me.pnlContent.PerformLayout()
        Me.pnlActions.ResumeLayout(False)
        Me.pnlUserInfo.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblTitre As Label
    Friend WithEvents pnlContent As Panel
    Friend WithEvents dtpDateVisite As DateTimePicker
    Friend WithEvents lblDate As Label
    Friend WithEvents txtMotif As TextBox
    Friend WithEvents lblMotif As Label
    Friend WithEvents pnlActions As Panel
    Friend WithEvents btnAnnuler As Button
    Friend WithEvents btnEnregistrer As Button
    Friend WithEvents pnlUserInfo As Panel
    Friend WithEvents lblUserInfo As Label
    Friend WithEvents txtBilan As TextBox
    Friend WithEvents lblBilan As Label
    Friend WithEvents lblRapportId As Label
    Friend WithEvents txtMedecin As TextBox
    Friend WithEvents lblMedecin As Label
End Class