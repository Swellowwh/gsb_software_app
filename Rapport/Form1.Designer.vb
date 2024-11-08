<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.validButton = New System.Windows.Forms.Button()
        Me.declinerButton = New System.Windows.Forms.Button()
        Me.MedicSelect = New System.Windows.Forms.CheckedListBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.inputObservations = New System.Windows.Forms.TextBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.ReportDate = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.inputNomPatient = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.account = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Gray
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.account)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(872, 53)
        Me.Panel1.TabIndex = 0
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
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "images.jpg")
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Gray
        Me.Panel2.Controls.Add(Me.validButton)
        Me.Panel2.Controls.Add(Me.declinerButton)
        Me.Panel2.Controls.Add(Me.MedicSelect)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.Panel7)
        Me.Panel2.Controls.Add(Me.Panel6)
        Me.Panel2.Controls.Add(Me.Panel5)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Location = New System.Drawing.Point(12, 97)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(872, 463)
        Me.Panel2.TabIndex = 1
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
        Me.validButton.Location = New System.Drawing.Point(12, 421)
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
        Me.declinerButton.Location = New System.Drawing.Point(133, 421)
        Me.declinerButton.Name = "declinerButton"
        Me.declinerButton.Size = New System.Drawing.Size(111, 23)
        Me.declinerButton.TabIndex = 9
        Me.declinerButton.Text = "Décliner"
        Me.declinerButton.UseVisualStyleBackColor = False
        '
        'MedicSelect
        '
        Me.MedicSelect.FormattingEnabled = True
        Me.MedicSelect.Location = New System.Drawing.Point(10, 292)
        Me.MedicSelect.Name = "MedicSelect"
        Me.MedicSelect.Size = New System.Drawing.Size(303, 94)
        Me.MedicSelect.TabIndex = 13
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("SimSun", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(8, 270)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(215, 16)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Médicamment sélectionné  :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("SimSun", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(8, 197)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(119, 16)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Observations :"
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.White
        Me.Panel7.Controls.Add(Me.inputObservations)
        Me.Panel7.Location = New System.Drawing.Point(9, 219)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(305, 27)
        Me.Panel7.TabIndex = 8
        '
        'inputObservations
        '
        Me.inputObservations.BackColor = System.Drawing.SystemColors.Window
        Me.inputObservations.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.inputObservations.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.inputObservations.Location = New System.Drawing.Point(3, 4)
        Me.inputObservations.Name = "inputObservations"
        Me.inputObservations.Size = New System.Drawing.Size(298, 19)
        Me.inputObservations.TabIndex = 7
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.White
        Me.Panel6.Location = New System.Drawing.Point(554, 34)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(305, 27)
        Me.Panel6.TabIndex = 7
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.White
        Me.Panel5.Controls.Add(Me.ReportDate)
        Me.Panel5.Location = New System.Drawing.Point(8, 144)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(305, 27)
        Me.Panel5.TabIndex = 6
        '
        'ReportDate
        '
        Me.ReportDate.CalendarMonthBackground = System.Drawing.Color.White
        Me.ReportDate.CalendarTitleBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ReportDate.Location = New System.Drawing.Point(4, 4)
        Me.ReportDate.Name = "ReportDate"
        Me.ReportDate.Size = New System.Drawing.Size(298, 20)
        Me.ReportDate.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("SimSun", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(8, 122)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 16)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Date :"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.Controls.Add(Me.inputNomPatient)
        Me.Panel4.Location = New System.Drawing.Point(8, 78)
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
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("SimSun", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(7, 55)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(135, 16)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Nom du patient :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Showcard Gothic", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(6, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(343, 30)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Rédaction d'un rapport"
        '
        'ImageList2
        '
        Me.ImageList2.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList2.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        '
        'Button1
        '
        Me.Button1.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
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
        Me.Button1.TabIndex = 13
        Me.Button1.Text = "Liste des rapports"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar
        Me.Button3.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
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
        Me.Button3.TabIndex = 12
        Me.Button3.Text = "Création d'un rapport"
        Me.Button3.UseVisualStyleBackColor = False
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
        Me.account.TabIndex = 11
        Me.account.Text = "Mon compte"
        Me.account.UseVisualStyleBackColor = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(896, 861)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents inputNomPatient As TextBox
    Friend WithEvents ReportDate As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents ImageList2 As ImageList
    Friend WithEvents Label8 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Panel7 As Panel
    Friend WithEvents MedicSelect As CheckedListBox
    Friend WithEvents inputObservations As TextBox
    Friend WithEvents validButton As Button
    Friend WithEvents declinerButton As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents account As Button
End Class
