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
        Me.PnlHeader = New System.Windows.Forms.Panel()
        Me.LblTitre = New System.Windows.Forms.Label()
        Me.PnlMessage = New System.Windows.Forms.Panel()
        Me.LblMessage = New System.Windows.Forms.Label()
        Me.BtnFermer = New System.Windows.Forms.Button()
        Me.PnlHeader.SuspendLayout()
        Me.PnlMessage.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnlHeader
        '
        Me.PnlHeader.BackColor = System.Drawing.Color.SteelBlue
        Me.PnlHeader.Controls.Add(Me.LblTitre)
        Me.PnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.PnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.PnlHeader.Name = "PnlHeader"
        Me.PnlHeader.Size = New System.Drawing.Size(584, 60)
        Me.PnlHeader.TabIndex = 0
        '
        'LblTitre
        '
        Me.LblTitre.AutoSize = True
        Me.LblTitre.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTitre.ForeColor = System.Drawing.Color.White
        Me.LblTitre.Location = New System.Drawing.Point(12, 18)
        Me.LblTitre.Name = "LblTitre"
        Me.LblTitre.Size = New System.Drawing.Size(291, 25)
        Me.LblTitre.TabIndex = 0
        Me.LblTitre.Text = "Espace Praticien - Médecin"
        '
        'PnlMessage
        '
        Me.PnlMessage.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PnlMessage.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PnlMessage.Controls.Add(Me.LblMessage)
        Me.PnlMessage.Location = New System.Drawing.Point(40, 100)
        Me.PnlMessage.Name = "PnlMessage"
        Me.PnlMessage.Size = New System.Drawing.Size(504, 150)
        Me.PnlMessage.TabIndex = 1
        '
        'LblMessage
        '
        Me.LblMessage.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LblMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMessage.Location = New System.Drawing.Point(16, 15)
        Me.LblMessage.Name = "LblMessage"
        Me.LblMessage.Size = New System.Drawing.Size(472, 120)
        Me.LblMessage.TabIndex = 0
        Me.LblMessage.Text = "Vous êtes connecté en tant que praticien." & Global.Microsoft.VisualBasic.Constants.vbCrLf & Global.Microsoft.VisualBasic.Constants.vbCrLf & "Pour l'instant, aucune fonctionnalité " &
    "n'est disponible dans cette section." & Global.Microsoft.VisualBasic.Constants.vbCrLf & Global.Microsoft.VisualBasic.Constants.vbCrLf & "Merci de votre compréhension."
        Me.LblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnFermer
        '
        Me.BtnFermer.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.BtnFermer.BackColor = System.Drawing.Color.LightSteelBlue
        Me.BtnFermer.Location = New System.Drawing.Point(242, 283)
        Me.BtnFermer.Name = "BtnFermer"
        Me.BtnFermer.Size = New System.Drawing.Size(100, 35)
        Me.BtnFermer.TabIndex = 2
        Me.BtnFermer.Text = "Fermer"
        Me.BtnFermer.UseVisualStyleBackColor = False
        '
        'Praticien
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(584, 341)
        Me.Controls.Add(Me.BtnFermer)
        Me.Controls.Add(Me.PnlMessage)
        Me.Controls.Add(Me.PnlHeader)
        Me.MinimumSize = New System.Drawing.Size(400, 300)
        Me.Name = "Praticien"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Espace Praticien"
        Me.PnlHeader.ResumeLayout(False)
        Me.PnlHeader.PerformLayout()
        Me.PnlMessage.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PnlHeader As Panel
    Friend WithEvents LblTitre As Label
    Friend WithEvents PnlMessage As Panel
    Friend WithEvents LblMessage As Label
    Friend WithEvents BtnFermer As Button
End Class