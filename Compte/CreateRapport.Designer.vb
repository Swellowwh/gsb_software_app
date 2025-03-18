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
        Me.lblID = New System.Windows.Forms.Label()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.lblMotif = New System.Windows.Forms.Label()
        Me.cboMotif = New System.Windows.Forms.ComboBox()
        Me.lblVisite = New System.Windows.Forms.Label()
        Me.cboVisite = New System.Windows.Forms.ComboBox()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.grpDetails = New System.Windows.Forms.GroupBox()
        Me.lblConclusion = New System.Windows.Forms.Label()
        Me.txtConclusion = New System.Windows.Forms.TextBox()
        Me.btnEnregistrer = New System.Windows.Forms.Button()
        Me.btnAnnuler = New System.Windows.Forms.Button()
        Me.btnNouveau = New System.Windows.Forms.Button()
        Me.dgvRapports = New System.Windows.Forms.DataGridView()
        Me.ColID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColMotif = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColVisite = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grpDetails.SuspendLayout()
        CType(Me.dgvRapports, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'lblID
        '
        Me.lblID.AutoSize = True
        Me.lblID.Location = New System.Drawing.Point(16, 55)
        Me.lblID.Name = "lblID"
        Me.lblID.Size = New System.Drawing.Size(67, 13)
        Me.lblID.TabIndex = 1
        Me.lblID.Text = "ID Rapport :"
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(89, 52)
        Me.txtID.Name = "txtID"
        Me.txtID.ReadOnly = True
        Me.txtID.Size = New System.Drawing.Size(100, 20)
        Me.txtID.TabIndex = 2
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Location = New System.Drawing.Point(16, 85)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(36, 13)
        Me.lblDate.TabIndex = 3
        Me.lblDate.Text = "Date :"
        '
        'dtpDate
        '
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDate.Location = New System.Drawing.Point(89, 82)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(100, 20)
        Me.dtpDate.TabIndex = 4
        '
        'lblMotif
        '
        Me.lblMotif.AutoSize = True
        Me.lblMotif.Location = New System.Drawing.Point(16, 115)
        Me.lblMotif.Name = "lblMotif"
        Me.lblMotif.Size = New System.Drawing.Size(39, 13)
        Me.lblMotif.TabIndex = 5
        Me.lblMotif.Text = "Motif :"
        '
        'cboMotif
        '
        Me.cboMotif.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMotif.FormattingEnabled = True
        Me.cboMotif.Items.AddRange(New Object() {"Routine", "Suivi", "Urgence", "Contrôle", "Autre"})
        Me.cboMotif.Location = New System.Drawing.Point(89, 112)
        Me.cboMotif.Name = "cboMotif"
        Me.cboMotif.Size = New System.Drawing.Size(150, 21)
        Me.cboMotif.TabIndex = 6
        '
        'lblVisite
        '
        Me.lblVisite.AutoSize = True
        Me.lblVisite.Location = New System.Drawing.Point(16, 145)
        Me.lblVisite.Name = "lblVisite"
        Me.lblVisite.Size = New System.Drawing.Size(56, 13)
        Me.lblVisite.TabIndex = 7
        Me.lblVisite.Text = "ID Visite :"
        '
        'cboVisite
        '
        Me.cboVisite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVisite.FormattingEnabled = True
        Me.cboVisite.Location = New System.Drawing.Point(89, 142)
        Me.cboVisite.Name = "cboVisite"
        Me.cboVisite.Size = New System.Drawing.Size(150, 21)
        Me.cboVisite.TabIndex = 8
        '
        'lblDescription
        '
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Location = New System.Drawing.Point(18, 30)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(69, 13)
        Me.lblDescription.TabIndex = 9
        Me.lblDescription.Text = "Description :"
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(21, 46)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescription.Size = New System.Drawing.Size(510, 80)
        Me.txtDescription.TabIndex = 10
        '
        'grpDetails
        '
        Me.grpDetails.Controls.Add(Me.lblConclusion)
        Me.grpDetails.Controls.Add(Me.txtConclusion)
        Me.grpDetails.Controls.Add(Me.lblDescription)
        Me.grpDetails.Controls.Add(Me.txtDescription)
        Me.grpDetails.Location = New System.Drawing.Point(245, 52)
        Me.grpDetails.Name = "grpDetails"
        Me.grpDetails.Size = New System.Drawing.Size(550, 211)
        Me.grpDetails.TabIndex = 11
        Me.grpDetails.TabStop = False
        Me.grpDetails.Text = "Détails du rapport"
        '
        'lblConclusion
        '
        Me.lblConclusion.AutoSize = True
        Me.lblConclusion.Location = New System.Drawing.Point(18, 135)
        Me.lblConclusion.Name = "lblConclusion"
        Me.lblConclusion.Size = New System.Drawing.Size(65, 13)
        Me.lblConclusion.TabIndex = 11
        Me.lblConclusion.Text = "Conclusion :"
        '
        'txtConclusion
        '
        Me.txtConclusion.Location = New System.Drawing.Point(21, 151)
        Me.txtConclusion.Multiline = True
        Me.txtConclusion.Name = "txtConclusion"
        Me.txtConclusion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtConclusion.Size = New System.Drawing.Size(510, 45)
        Me.txtConclusion.TabIndex = 12
        '
        'btnEnregistrer
        '
        Me.btnEnregistrer.Location = New System.Drawing.Point(19, 178)
        Me.btnEnregistrer.Name = "btnEnregistrer"
        Me.btnEnregistrer.Size = New System.Drawing.Size(100, 25)
        Me.btnEnregistrer.TabIndex = 12
        Me.btnEnregistrer.Text = "Enregistrer"
        Me.btnEnregistrer.UseVisualStyleBackColor = True
        '
        'btnAnnuler
        '
        Me.btnAnnuler.Location = New System.Drawing.Point(125, 178)
        Me.btnAnnuler.Name = "btnAnnuler"
        Me.btnAnnuler.Size = New System.Drawing.Size(100, 25)
        Me.btnAnnuler.TabIndex = 13
        Me.btnAnnuler.Text = "Annuler"
        Me.btnAnnuler.UseVisualStyleBackColor = True
        '
        'btnNouveau
        '
        Me.btnNouveau.Location = New System.Drawing.Point(19, 209)
        Me.btnNouveau.Name = "btnNouveau"
        Me.btnNouveau.Size = New System.Drawing.Size(100, 25)
        Me.btnNouveau.TabIndex = 14
        Me.btnNouveau.Text = "Nouveau"
        Me.btnNouveau.UseVisualStyleBackColor = True
        '
        'dgvRapports
        '
        Me.dgvRapports.AllowUserToAddRows = False
        Me.dgvRapports.AllowUserToDeleteRows = False
        Me.dgvRapports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRapports.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColID, Me.ColDate, Me.ColMotif, Me.ColVisite})
        Me.dgvRapports.Location = New System.Drawing.Point(19, 269)
        Me.dgvRapports.Name = "dgvRapports"
        Me.dgvRapports.ReadOnly = True
        Me.dgvRapports.Size = New System.Drawing.Size(776, 174)
        Me.dgvRapports.TabIndex = 15
        '
        'ColID
        '
        Me.ColID.HeaderText = "ID Rapport"
        Me.ColID.Name = "ColID"
        Me.ColID.ReadOnly = True
        Me.ColID.Width = 80
        '
        'ColDate
        '
        Me.ColDate.HeaderText = "Date"
        Me.ColDate.Name = "ColDate"
        Me.ColDate.ReadOnly = True
        Me.ColDate.Width = 120
        '
        'ColMotif
        '
        Me.ColMotif.HeaderText = "Motif"
        Me.ColMotif.Name = "ColMotif"
        Me.ColMotif.ReadOnly = True
        Me.ColMotif.Width = 150
        '
        'ColVisite
        '
        Me.ColVisite.HeaderText = "ID Visite"
        Me.ColVisite.Name = "ColVisite"
        Me.ColVisite.ReadOnly = True
        Me.ColVisite.Width = 80
        '
        'CreateRapport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(814, 461)
        Me.Controls.Add(Me.dgvRapports)
        Me.Controls.Add(Me.btnNouveau)
        Me.Controls.Add(Me.btnAnnuler)
        Me.Controls.Add(Me.btnEnregistrer)
        Me.Controls.Add(Me.grpDetails)
        Me.Controls.Add(Me.cboVisite)
        Me.Controls.Add(Me.lblVisite)
        Me.Controls.Add(Me.cboMotif)
        Me.Controls.Add(Me.lblMotif)
        Me.Controls.Add(Me.dtpDate)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.txtID)
        Me.Controls.Add(Me.lblID)
        Me.Controls.Add(Me.lblTitre)
        Me.Name = "CreateRapport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Création de Rapports"
        Me.grpDetails.ResumeLayout(False)
        Me.grpDetails.PerformLayout()
        CType(Me.dgvRapports, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTitre As Label
    Friend WithEvents lblID As Label
    Friend WithEvents txtID As TextBox
    Friend WithEvents lblDate As Label
    Friend WithEvents dtpDate As DateTimePicker
    Friend WithEvents lblMotif As Label
    Friend WithEvents cboMotif As ComboBox
    Friend WithEvents lblVisite As Label
    Friend WithEvents cboVisite As ComboBox
    Friend WithEvents lblDescription As Label
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents grpDetails As GroupBox
    Friend WithEvents lblConclusion As Label
    Friend WithEvents txtConclusion As TextBox
    Friend WithEvents btnEnregistrer As Button
    Friend WithEvents btnAnnuler As Button
    Friend WithEvents btnNouveau As Button
    Friend WithEvents dgvRapports As DataGridView
    Friend WithEvents ColID As DataGridViewTextBoxColumn
    Friend WithEvents ColDate As DataGridViewTextBoxColumn
    Friend WithEvents ColMotif As DataGridViewTextBoxColumn
    Friend WithEvents ColVisite As DataGridViewTextBoxColumn
End Class