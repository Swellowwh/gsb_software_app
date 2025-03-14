<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Accueil
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
        Me.lblBienvenue = New System.Windows.Forms.Label()
        Me.lblBonjour = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        ' lblBienvenue
        '
        Me.lblBienvenue.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBienvenue.Location = New System.Drawing.Point(12, 166)
        Me.lblBienvenue.Name = "lblBienvenue"
        Me.lblBienvenue.Size = New System.Drawing.Size(776, 45)
        Me.lblBienvenue.TabIndex = 0
        Me.lblBienvenue.Text = "Bienvenue sur notre application"
        Me.lblBienvenue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        ' lblBonjour
        '
        Me.lblBonjour.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBonjour.ForeColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(165, Byte), Integer))
        Me.lblBonjour.Location = New System.Drawing.Point(12, 95)
        Me.lblBonjour.Name = "lblBonjour"
        Me.lblBonjour.Size = New System.Drawing.Size(776, 71)
        Me.lblBonjour.TabIndex = 1
        Me.lblBonjour.Text = "Bonjour !"
        Me.lblBonjour.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        ' Accueil
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.lblBonjour)
        Me.Controls.Add(Me.lblBienvenue)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "Accueil"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Page d'Accueil"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblBienvenue As Label
    Friend WithEvents lblBonjour As Label
End Class