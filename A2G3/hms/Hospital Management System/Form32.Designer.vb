<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form32
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.id = New System.Windows.Forms.TextBox()
        Me.na = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.eid = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.quantit = New System.Windows.Forms.TextBox()
        Me.complete = New System.Windows.Forms.Button()
        Me.ad = New System.Windows.Forms.Button()
        Me.total = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.num = New System.Windows.Forms.TextBox()
        Me.nam = New System.Windows.Forms.TextBox()
        Me.phone = New System.Windows.Forms.TextBox()
        Me.city = New System.Windows.Forms.TextBox()
        Me.dat = New System.Windows.Forms.DateTimePicker()
        Me.pick = New System.Windows.Forms.Label()
        Me.add = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.gen = New System.Windows.Forms.Button()
        Me.list = New System.Windows.Forms.ListBox()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GroupBox2.Controls.Add(Me.id)
        Me.GroupBox2.Controls.Add(Me.na)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.eid)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.quantit)
        Me.GroupBox2.Controls.Add(Me.complete)
        Me.GroupBox2.Controls.Add(Me.ad)
        Me.GroupBox2.Controls.Add(Me.total)
        Me.GroupBox2.Location = New System.Drawing.Point(448, 35)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(404, 388)
        Me.GroupBox2.TabIndex = 48
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Medicine Details"
        '
        'id
        '
        Me.id.Location = New System.Drawing.Point(222, 42)
        Me.id.Name = "id"
        Me.id.Size = New System.Drawing.Size(143, 22)
        Me.id.TabIndex = 33
        '
        'na
        '
        Me.na.Location = New System.Drawing.Point(222, 92)
        Me.na.Name = "na"
        Me.na.Size = New System.Drawing.Size(143, 22)
        Me.na.TabIndex = 34
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(63, 213)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 17)
        Me.Label5.TabIndex = 43
        Me.Label5.Text = "Amount"
        '
        'eid
        '
        Me.eid.AutoSize = True
        Me.eid.Location = New System.Drawing.Point(38, 45)
        Me.eid.Name = "eid"
        Me.eid.Size = New System.Drawing.Size(107, 17)
        Me.eid.TabIndex = 36
        Me.eid.Text = "Eid Of Medicine"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(38, 99)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(121, 17)
        Me.Label7.TabIndex = 37
        Me.Label7.Text = "Name of Medicine"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(58, 158)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 17)
        Me.Label8.TabIndex = 38
        Me.Label8.Text = "Quantity"
        '
        'quantit
        '
        Me.quantit.Location = New System.Drawing.Point(222, 153)
        Me.quantit.Name = "quantit"
        Me.quantit.Size = New System.Drawing.Size(143, 22)
        Me.quantit.TabIndex = 35
        '
        'complete
        '
        Me.complete.Location = New System.Drawing.Point(222, 302)
        Me.complete.Name = "complete"
        Me.complete.Size = New System.Drawing.Size(138, 41)
        Me.complete.TabIndex = 41
        Me.complete.Text = "Complete"
        Me.complete.UseVisualStyleBackColor = True
        '
        'ad
        '
        Me.ad.Location = New System.Drawing.Point(41, 302)
        Me.ad.Name = "ad"
        Me.ad.Size = New System.Drawing.Size(141, 41)
        Me.ad.TabIndex = 39
        Me.ad.Text = "Add Item"
        Me.ad.UseVisualStyleBackColor = True
        '
        'total
        '
        Me.total.Location = New System.Drawing.Point(222, 208)
        Me.total.Name = "total"
        Me.total.ReadOnly = True
        Me.total.Size = New System.Drawing.Size(128, 22)
        Me.total.TabIndex = 42
        Me.total.Text = "0"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GroupBox1.Controls.Add(Me.num)
        Me.GroupBox1.Controls.Add(Me.nam)
        Me.GroupBox1.Controls.Add(Me.phone)
        Me.GroupBox1.Controls.Add(Me.city)
        Me.GroupBox1.Controls.Add(Me.dat)
        Me.GroupBox1.Controls.Add(Me.pick)
        Me.GroupBox1.Controls.Add(Me.add)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.gen)
        Me.GroupBox1.Location = New System.Drawing.Point(35, 35)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(333, 388)
        Me.GroupBox1.TabIndex = 47
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Add Customer"
        '
        'num
        '
        Me.num.Location = New System.Drawing.Point(115, 28)
        Me.num.Name = "num"
        Me.num.Size = New System.Drawing.Size(170, 22)
        Me.num.TabIndex = 24
        '
        'nam
        '
        Me.nam.Location = New System.Drawing.Point(115, 65)
        Me.nam.Name = "nam"
        Me.nam.Size = New System.Drawing.Size(170, 22)
        Me.nam.TabIndex = 21
        '
        'phone
        '
        Me.phone.Location = New System.Drawing.Point(115, 122)
        Me.phone.Name = "phone"
        Me.phone.Size = New System.Drawing.Size(170, 22)
        Me.phone.TabIndex = 22
        '
        'city
        '
        Me.city.Location = New System.Drawing.Point(115, 171)
        Me.city.Name = "city"
        Me.city.Size = New System.Drawing.Size(170, 22)
        Me.city.TabIndex = 23
        '
        'dat
        '
        Me.dat.Location = New System.Drawing.Point(140, 221)
        Me.dat.Name = "dat"
        Me.dat.Size = New System.Drawing.Size(145, 22)
        Me.dat.TabIndex = 30
        '
        'pick
        '
        Me.pick.AutoSize = True
        Me.pick.Location = New System.Drawing.Point(32, 226)
        Me.pick.Name = "pick"
        Me.pick.Size = New System.Drawing.Size(38, 17)
        Me.pick.TabIndex = 29
        Me.pick.Text = "Date"
        '
        'add
        '
        Me.add.Location = New System.Drawing.Point(68, 305)
        Me.add.Name = "add"
        Me.add.Size = New System.Drawing.Size(158, 45)
        Me.add.TabIndex = 31
        Me.add.Text = "Add Customer"
        Me.add.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(25, 171)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 17)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "City"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 125)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 17)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Phone Number"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 17)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 17)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Bill No."
        '
        'gen
        '
        Me.gen.Location = New System.Drawing.Point(111, 0)
        Me.gen.Name = "gen"
        Me.gen.Size = New System.Drawing.Size(98, 22)
        Me.gen.TabIndex = 32
        Me.gen.Text = "New Number"
        Me.gen.UseVisualStyleBackColor = True
        '
        'list
        '
        Me.list.FormattingEnabled = True
        Me.list.ItemHeight = 16
        Me.list.Location = New System.Drawing.Point(968, 35)
        Me.list.Name = "list"
        Me.list.ScrollAlwaysVisible = True
        Me.list.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.list.Size = New System.Drawing.Size(439, 388)
        Me.list.TabIndex = 46
        Me.list.Visible = False
        '
        'Form32
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(1424, 461)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.list)
        Me.Name = "Form32"
        Me.Text = "Billing"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents id As TextBox
    Friend WithEvents na As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents eid As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents quantit As TextBox
    Friend WithEvents complete As Button
    Friend WithEvents ad As Button
    Friend WithEvents total As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents num As TextBox
    Friend WithEvents nam As TextBox
    Friend WithEvents phone As TextBox
    Friend WithEvents city As TextBox
    Friend WithEvents dat As DateTimePicker
    Friend WithEvents pick As Label
    Friend WithEvents add As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents gen As Button
    Friend WithEvents list As ListBox
End Class
