<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form33
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form33))
        Me.Box1 = New System.Windows.Forms.GroupBox()
        Me.clear = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.eid = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.nam = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.rate = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.quantity = New System.Windows.Forms.TextBox()
        Me.add_item = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dat = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Box1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Box1
        '
        Me.Box1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Box1.Controls.Add(Me.clear)
        Me.Box1.Controls.Add(Me.Button1)
        Me.Box1.Controls.Add(Me.eid)
        Me.Box1.Controls.Add(Me.Label6)
        Me.Box1.Controls.Add(Me.nam)
        Me.Box1.Controls.Add(Me.Label5)
        Me.Box1.Controls.Add(Me.rate)
        Me.Box1.Controls.Add(Me.Label4)
        Me.Box1.Controls.Add(Me.quantity)
        Me.Box1.Controls.Add(Me.add_item)
        Me.Box1.Controls.Add(Me.Label2)
        Me.Box1.Controls.Add(Me.dat)
        Me.Box1.Controls.Add(Me.Label1)
        Me.Box1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Box1.Location = New System.Drawing.Point(12, 33)
        Me.Box1.Name = "Box1"
        Me.Box1.Size = New System.Drawing.Size(487, 431)
        Me.Box1.TabIndex = 15
        Me.Box1.TabStop = False
        Me.Box1.Text = "Details"
        '
        'clear
        '
        Me.clear.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.clear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.clear.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.clear.Location = New System.Drawing.Point(195, 358)
        Me.clear.Name = "clear"
        Me.clear.Size = New System.Drawing.Size(126, 54)
        Me.clear.TabIndex = 13
        Me.clear.Text = "Clear"
        Me.clear.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Button1.Location = New System.Drawing.Point(340, 358)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(118, 54)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "Close"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'eid
        '
        Me.eid.BackColor = System.Drawing.SystemColors.Control
        Me.eid.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.eid.Location = New System.Drawing.Point(259, 71)
        Me.eid.Name = "eid"
        Me.eid.Size = New System.Drawing.Size(187, 27)
        Me.eid.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(50, 290)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(149, 18)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Select the Expiry date"
        '
        'nam
        '
        Me.nam.BackColor = System.Drawing.SystemColors.Control
        Me.nam.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nam.Location = New System.Drawing.Point(259, 117)
        Me.nam.Name = "nam"
        Me.nam.Size = New System.Drawing.Size(187, 27)
        Me.nam.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(51, 237)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(150, 18)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Quantity of Medicines"
        '
        'rate
        '
        Me.rate.BackColor = System.Drawing.SystemColors.Control
        Me.rate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rate.Location = New System.Drawing.Point(259, 167)
        Me.rate.Name = "rate"
        Me.rate.Size = New System.Drawing.Size(187, 27)
        Me.rate.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(71, 178)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(126, 18)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Rate of one Piece"
        '
        'quantity
        '
        Me.quantity.BackColor = System.Drawing.SystemColors.Control
        Me.quantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.quantity.Location = New System.Drawing.Point(259, 237)
        Me.quantity.Name = "quantity"
        Me.quantity.Size = New System.Drawing.Size(187, 27)
        Me.quantity.TabIndex = 2
        '
        'add_item
        '
        Me.add_item.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.add_item.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.add_item.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.add_item.Location = New System.Drawing.Point(37, 358)
        Me.add_item.Name = "add_item"
        Me.add_item.Size = New System.Drawing.Size(134, 54)
        Me.add_item.TabIndex = 4
        Me.add_item.Text = "Add into data"
        Me.add_item.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(68, 119)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(131, 18)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Name Of Medicine"
        '
        'dat
        '
        Me.dat.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dat.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dat.Location = New System.Drawing.Point(259, 288)
        Me.dat.Name = "dat"
        Me.dat.Size = New System.Drawing.Size(187, 27)
        Me.dat.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(110, 71)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 18)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Eid Number"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(532, 24)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(695, 457)
        Me.PictureBox1.TabIndex = 18
        Me.PictureBox1.TabStop = False
        '
        'Form33
        '
        Me.AcceptButton = Me.add_item
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(1251, 495)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Box1)
        Me.Name = "Form33"
        Me.Text = "Add Medicine"
        Me.Box1.ResumeLayout(False)
        Me.Box1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Box1 As GroupBox
    Friend WithEvents eid As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents nam As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents rate As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents quantity As TextBox
    Friend WithEvents add_item As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents dat As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents clear As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents PictureBox1 As PictureBox
End Class
