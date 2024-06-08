<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class StatsUser
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Arial", 15.0!)
        Me.Button1.Location = New System.Drawing.Point(65, 32)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(231, 48)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "A - Z"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.Font = New System.Drawing.Font("Arial", 15.0!)
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(414, 36)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(231, 43)
        Me.ComboBox1.TabIndex = 3
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Arial", 15.0!)
        Me.Button2.Location = New System.Drawing.Point(65, 107)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(231, 48)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Meilleur temps"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'ComboBox2
        '
        Me.ComboBox2.Font = New System.Drawing.Font("Arial", 15.0!)
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(954, 254)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(231, 43)
        Me.ComboBox2.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 15.0!)
        Me.Label1.Location = New System.Drawing.Point(417, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(129, 35)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Difficulte"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 15.0!)
        Me.Label2.Location = New System.Drawing.Point(913, 190)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(297, 35)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Chercher par un nom"
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Arial", 15.0!)
        Me.Button3.Location = New System.Drawing.Point(979, 134)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(231, 43)
        Me.Button3.TabIndex = 8
        Me.Button3.Text = "Ok"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.Cursor = System.Windows.Forms.Cursors.Default
        Me.ListBox1.Font = New System.Drawing.Font("Arial", 13.0!)
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 31
        Me.ListBox1.Location = New System.Drawing.Point(54, 201)
        Me.ListBox1.MultiColumn = True
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(276, 190)
        Me.ListBox1.TabIndex = 0
        '
        'Button4
        '
        Me.Button4.Font = New System.Drawing.Font("Arial", 15.0!)
        Me.Button4.Location = New System.Drawing.Point(83, 525)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(132, 51)
        Me.Button4.TabIndex = 11
        Me.Button4.Text = "Menu"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'StatsUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1119, 633)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Button1)
        Me.Font = New System.Drawing.Font("宋体", 9.0!)
        Me.Name = "StatsUser"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As Button
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Button2 As Button
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Button4 As Button
End Class
