<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form34
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pick = New System.Windows.Forms.DateTimePicker()
        Me.quantity = New System.Windows.Forms.TextBox()
        Me.rate = New System.Windows.Forms.TextBox()
        Me.input = New System.Windows.Forms.TextBox()
        Me.id = New System.Windows.Forms.TextBox()
        Me.upda = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.pick)
        Me.GroupBox1.Controls.Add(Me.quantity)
        Me.GroupBox1.Controls.Add(Me.rate)
        Me.GroupBox1.Controls.Add(Me.input)
        Me.GroupBox1.Controls.Add(Me.id)
        Me.GroupBox1.Location = New System.Drawing.Point(22, 27)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(402, 297)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Update"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 227)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 17)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Expiry Before"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(37, 184)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 17)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Quantity"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(60, 143)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 17)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Rate"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(53, 105)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 17)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(70, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 17)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Eid"
        '
        'pick
        '
        Me.pick.Location = New System.Drawing.Point(127, 222)
        Me.pick.Name = "pick"
        Me.pick.Size = New System.Drawing.Size(249, 22)
        Me.pick.TabIndex = 16
        '
        'quantity
        '
        Me.quantity.Location = New System.Drawing.Point(127, 184)
        Me.quantity.Name = "quantity"
        Me.quantity.Size = New System.Drawing.Size(249, 22)
        Me.quantity.TabIndex = 15
        '
        'rate
        '
        Me.rate.Location = New System.Drawing.Point(127, 143)
        Me.rate.Name = "rate"
        Me.rate.Size = New System.Drawing.Size(249, 22)
        Me.rate.TabIndex = 14
        '
        'input
        '
        Me.input.Location = New System.Drawing.Point(127, 105)
        Me.input.Name = "input"
        Me.input.Size = New System.Drawing.Size(249, 22)
        Me.input.TabIndex = 13
        '
        'id
        '
        Me.id.Location = New System.Drawing.Point(127, 58)
        Me.id.Name = "id"
        Me.id.Size = New System.Drawing.Size(249, 22)
        Me.id.TabIndex = 12
        '
        'upda
        '
        Me.upda.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.upda.Location = New System.Drawing.Point(22, 356)
        Me.upda.Name = "upda"
        Me.upda.Size = New System.Drawing.Size(127, 45)
        Me.upda.TabIndex = 11
        Me.upda.Text = "Update"
        Me.upda.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Button1.Location = New System.Drawing.Point(168, 356)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(123, 45)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "clear"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Button2.Location = New System.Drawing.Point(297, 356)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(127, 45)
        Me.Button2.TabIndex = 13
        Me.Button2.Text = "Close"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Form34
        '
        Me.AcceptButton = Me.upda
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(449, 428)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.upda)
        Me.Name = "Form34"
        Me.Text = "Update Pharmacy"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents pick As DateTimePicker
    Friend WithEvents quantity As TextBox
    Friend WithEvents rate As TextBox
    Friend WithEvents input As TextBox
    Friend WithEvents id As TextBox
    Friend WithEvents upda As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
End Class
