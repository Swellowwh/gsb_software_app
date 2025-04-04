<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LesRapports
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
        Me.dgvRapports = New System.Windows.Forms.DataGridView()
        Me.pnlActions = New System.Windows.Forms.Panel()
        Me.btnAjouter = New System.Windows.Forms.Button()
        Me.btnFermer = New System.Windows.Forms.Button()
        Me.lblTitre = New System.Windows.Forms.Label()
        Me.pnlUserInfo = New System.Windows.Forms.Panel()
        Me.lblUserInfo = New System.Windows.Forms.Label()
        Me.lblUserRole = New System.Windows.Forms.Label()
        CType(Me.dgvRapports, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlActions.SuspendLayout()
        Me.pnlUserInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvRapports
        '
        Me.dgvRapports.AllowUserToAddRows = False
        Me.dgvRapports.AllowUserToDeleteRows = False
        Me.dgvRapports.AllowUserToResizeRows = False
        Me.dgvRapports.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvRapports.BackgroundColor = System.Drawing.Color.White
        Me.dgvRapports.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvRapports.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvRapports.Location = New System.Drawing.Point(0, 80)
        Me.dgvRapports.MultiSelect = False
        Me.dgvRapports.Name = "dgvRapports"
        Me.dgvRapports.ReadOnly = True
        Me.dgvRapports.RowHeadersVisible = False
        Me.dgvRapports.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRapports.Size = New System.Drawing.Size(900, 460)
        Me.dgvRapports.TabIndex = 0
        '
        'pnlActions
        '
        Me.pnlActions.BackColor = System.Drawing.Color.LightGray
        Me.pnlActions.Controls.Add(Me.btnAjouter)
        Me.pnlActions.Controls.Add(Me.btnFermer)
        Me.pnlActions.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlActions.Location = New System.Drawing.Point(0, 540)
        Me.pnlActions.Name = "pnlActions"
        Me.pnlActions.Padding = New System.Windows.Forms.Padding(10)
        Me.pnlActions.Size = New System.Drawing.Size(900, 60)
        Me.pnlActions.TabIndex = 2
        '
        'btnAjouter
        '
        Me.btnAjouter.Location = New System.Drawing.Point(20, 15)
        Me.btnAjouter.Name = "btnAjouter"
        Me.btnAjouter.Size = New System.Drawing.Size(140, 30)
        Me.btnAjouter.TabIndex = 4
        Me.btnAjouter.Text = "Ajouter un rapport"
        Me.btnAjouter.UseVisualStyleBackColor = True
        '
        'btnFermer
        '
        Me.btnFermer.Location = New System.Drawing.Point(780, 15)
        Me.btnFermer.Name = "btnFermer"
        Me.btnFermer.Size = New System.Drawing.Size(100, 30)
        Me.btnFermer.TabIndex = 3
        Me.btnFermer.Text = "Fermer"
        Me.btnFermer.UseVisualStyleBackColor = True
        '
        'lblTitre
        '
        Me.lblTitre.BackColor = System.Drawing.Color.LightGray
        Me.lblTitre.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTitre.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitre.Location = New System.Drawing.Point(0, 0)
        Me.lblTitre.Name = "lblTitre"
        Me.lblTitre.Padding = New System.Windows.Forms.Padding(10)
        Me.lblTitre.Size = New System.Drawing.Size(900, 50)
        Me.lblTitre.TabIndex = 3
        Me.lblTitre.Text = "Synthèse des visites de"
        Me.lblTitre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlUserInfo
        '
        Me.pnlUserInfo.BackColor = System.Drawing.Color.LightBlue
        Me.pnlUserInfo.Controls.Add(Me.lblUserInfo)
        Me.pnlUserInfo.Controls.Add(Me.lblUserRole)
        Me.pnlUserInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlUserInfo.Location = New System.Drawing.Point(0, 50)
        Me.pnlUserInfo.Name = "pnlUserInfo"
        Me.pnlUserInfo.Padding = New System.Windows.Forms.Padding(10, 5, 10, 5)
        Me.pnlUserInfo.Size = New System.Drawing.Size(900, 30)
        Me.pnlUserInfo.TabIndex = 4
        '
        'lblUserInfo
        '
        Me.lblUserInfo.AutoSize = True
        Me.lblUserInfo.Location = New System.Drawing.Point(13, 8)
        Me.lblUserInfo.Name = "lblUserInfo"
        Me.lblUserInfo.Size = New System.Drawing.Size(107, 13)
        Me.lblUserInfo.TabIndex = 0
        Me.lblUserInfo.Text = "Utilisateur connecté: "
        '
        'lblUserRole
        '
        Me.lblUserRole.AutoSize = True
        Me.lblUserRole.Location = New System.Drawing.Point(250, 8)
        Me.lblUserRole.Name = "lblUserRole"
        Me.lblUserRole.Size = New System.Drawing.Size(32, 13)
        Me.lblUserRole.TabIndex = 1
        Me.lblUserRole.Text = "Rôle: "
        '
        'LesRapports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1200, 600)
        Me.Controls.Add(Me.dgvRapports)
        Me.Controls.Add(Me.pnlUserInfo)
        Me.Controls.Add(Me.lblTitre)
        Me.Controls.Add(Me.pnlActions)
        Me.Name = "LesRapports"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consultation des rapports de visite"
        CType(Me.dgvRapports, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlActions.ResumeLayout(False)
        Me.pnlUserInfo.ResumeLayout(False)
        Me.pnlUserInfo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvRapports As DataGridView
    Friend WithEvents pnlActions As Panel
    Friend WithEvents btnFermer As Button
    Friend WithEvents lblTitre As Label
    Friend WithEvents btnAjouter As Button
    Friend WithEvents pnlUserInfo As Panel
    Friend WithEvents lblUserInfo As Label
    Friend WithEvents lblUserRole As Label
End Class