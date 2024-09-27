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
        Me.NomBox = New System.Windows.Forms.ComboBox()
        Me.SocGrid = New System.Windows.Forms.DataGridView()
        CType(Me.SocGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NomBox
        '
        Me.NomBox.FormattingEnabled = True
        Me.NomBox.Location = New System.Drawing.Point(16, 15)
        Me.NomBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.NomBox.Name = "NomBox"
        Me.NomBox.Size = New System.Drawing.Size(649, 24)
        Me.NomBox.TabIndex = 0
        '
        'SocGrid
        '
        Me.SocGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.SocGrid.Location = New System.Drawing.Point(16, 48)
        Me.SocGrid.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SocGrid.Name = "SocGrid"
        Me.SocGrid.RowHeadersWidth = 51
        Me.SocGrid.Size = New System.Drawing.Size(651, 506)
        Me.SocGrid.TabIndex = 1
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(683, 567)
        Me.Controls.Add(Me.SocGrid)
        Me.Controls.Add(Me.NomBox)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "Form1"
        Me.Text = "Test ORACLE"
        CType(Me.SocGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents NomBox As System.Windows.Forms.ComboBox
    Friend WithEvents SocGrid As System.Windows.Forms.DataGridView

End Class
