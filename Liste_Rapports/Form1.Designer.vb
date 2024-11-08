<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
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

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.account = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.validButton = New System.Windows.Forms.Button()
        Me.declinerButton = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.inputNomPatient = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gray
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.account)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(872, 53)
        Me.Panel1.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Impact", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label8.Location = New System.Drawing.Point(20, 4)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(79, 45)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "GSB"
        '
        'account
        '
        Me.account.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar
        Me.account.BackColor = System.Drawing.Color.White
        Me.account.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.account.Cursor = System.Windows.Forms.Cursors.Hand
        Me.account.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.account.FlatAppearance.BorderSize = 0
        Me.account.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.account.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.account.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.account.Font = New System.Drawing.Font("Segoe UI Variable Display", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.account.ForeColor = System.Drawing.Color.Black
        Me.account.Location = New System.Drawing.Point(764, 15)
        Me.account.Name = "account"
        Me.account.Size = New System.Drawing.Size(95, 23)
        Me.account.TabIndex = 0
        Me.account.Text = "Mon compte"
        Me.account.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Gray
        Me.Panel2.Controls.Add(Me.validButton)
        Me.Panel2.Controls.Add(Me.declinerButton)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Location = New System.Drawing.Point(12, 100)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(872, 214)
        Me.Panel2.TabIndex = 5
        '
        'validButton
        '
        Me.validButton.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar
        Me.validButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.validButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.validButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.validButton.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.validButton.FlatAppearance.BorderSize = 0
        Me.validButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.validButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.validButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.validButton.Font = New System.Drawing.Font("Segoe UI Variable Display", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.validButton.ForeColor = System.Drawing.Color.Black
        Me.validButton.Location = New System.Drawing.Point(10, 175)
        Me.validButton.Name = "validButton"
        Me.validButton.Size = New System.Drawing.Size(111, 23)
        Me.validButton.TabIndex = 14
        Me.validButton.Text = "Valider"
        Me.validButton.UseVisualStyleBackColor = False
        '
        'declinerButton
        '
        Me.declinerButton.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar
        Me.declinerButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.declinerButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.declinerButton.Cursor = System.Windows.Forms.Cursors.Hand
        Me.declinerButton.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.declinerButton.FlatAppearance.BorderSize = 0
        Me.declinerButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.declinerButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.declinerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.declinerButton.Font = New System.Drawing.Font("Segoe UI Variable Display", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.declinerButton.ForeColor = System.Drawing.Color.Black
        Me.declinerButton.Location = New System.Drawing.Point(133, 175)
        Me.declinerButton.Name = "declinerButton"
        Me.declinerButton.Size = New System.Drawing.Size(111, 23)
        Me.declinerButton.TabIndex = 9
        Me.declinerButton.Text = "Décliner"
        Me.declinerButton.UseVisualStyleBackColor = False
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.Controls.Add(Me.inputNomPatient)
        Me.Panel4.Location = New System.Drawing.Point(8, 56)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(305, 27)
        Me.Panel4.TabIndex = 5
        '
        'inputNomPatient
        '
        Me.inputNomPatient.BackColor = System.Drawing.SystemColors.Window
        Me.inputNomPatient.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.inputNomPatient.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.inputNomPatient.Location = New System.Drawing.Point(2, 3)
        Me.inputNomPatient.Name = "inputNomPatient"
        Me.inputNomPatient.Size = New System.Drawing.Size(298, 19)
        Me.inputNomPatient.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Showcard Gothic", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(6, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(269, 30)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Liste des rapports"
        '
        'Button1
        '
        Me.Button1.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Segoe UI Variable Display", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.Black
        Me.Button1.Location = New System.Drawing.Point(252, 15)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(111, 23)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Liste des rapports"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar
        Me.Button3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Segoe UI Variable Display", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.Black
        Me.Button3.Location = New System.Drawing.Point(121, 15)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(123, 23)
        Me.Button3.TabIndex = 9
        Me.Button3.Text = "Création d'un rapport"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(896, 861)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents account As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents validButton As Button
    Friend WithEvents declinerButton As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents inputNomPatient As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button3 As Button
End Class
