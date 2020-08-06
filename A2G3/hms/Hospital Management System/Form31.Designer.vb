<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form31
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form31))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.med = New System.Windows.Forms.Button()
        Me.strip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AddElementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CheckAvailabilityToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.updateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Bill = New System.Windows.Forms.Button()
        Me.strip.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Modern No. 20", 48.0!)
        Me.Label1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(617, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(588, 83)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "I-Care Pharmacy"
        '
        'med
        '
        Me.med.AllowDrop = True
        Me.med.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.med.ContextMenuStrip = Me.strip
        Me.med.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.med.ForeColor = System.Drawing.SystemColors.ControlText
        Me.med.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.med.Location = New System.Drawing.Point(631, 212)
        Me.med.Name = "med"
        Me.med.Size = New System.Drawing.Size(206, 44)
        Me.med.TabIndex = 7
        Me.med.Text = "Medicines"
        Me.med.UseVisualStyleBackColor = False
        '
        'strip
        '
        Me.strip.AllowDrop = True
        Me.strip.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.strip.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.strip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.strip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddElementToolStripMenuItem, Me.CheckAvailabilityToolStripMenuItem, Me.updateToolStripMenuItem})
        Me.strip.Name = "strip"
        Me.strip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.strip.Size = New System.Drawing.Size(254, 74)
        '
        'AddElementToolStripMenuItem
        '
        Me.AddElementToolStripMenuItem.Name = "AddElementToolStripMenuItem"
        Me.AddElementToolStripMenuItem.Padding = New System.Windows.Forms.Padding(0)
        Me.AddElementToolStripMenuItem.Size = New System.Drawing.Size(253, 22)
        Me.AddElementToolStripMenuItem.Text = "Add Medicines"
        '
        'CheckAvailabilityToolStripMenuItem
        '
        Me.CheckAvailabilityToolStripMenuItem.Name = "CheckAvailabilityToolStripMenuItem"
        Me.CheckAvailabilityToolStripMenuItem.Size = New System.Drawing.Size(253, 24)
        Me.CheckAvailabilityToolStripMenuItem.Text = "Check Availability"
        '
        'updateToolStripMenuItem
        '
        Me.updateToolStripMenuItem.Name = "updateToolStripMenuItem"
        Me.updateToolStripMenuItem.Size = New System.Drawing.Size(253, 24)
        Me.updateToolStripMenuItem.Text = "Update Medicines Data"
        '
        'Bill
        '
        Me.Bill.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Bill.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Bill.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Bill.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Bill.Location = New System.Drawing.Point(920, 212)
        Me.Bill.Name = "Bill"
        Me.Bill.Size = New System.Drawing.Size(219, 41)
        Me.Bill.TabIndex = 8
        Me.Bill.Text = "Billing"
        Me.Bill.UseVisualStyleBackColor = False
        '
        'Form31
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(1247, 568)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.med)
        Me.Controls.Add(Me.Bill)
        Me.Name = "Form31"
        Me.Text = "Pharmacy"
        Me.strip.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents med As Button
    Friend WithEvents Bill As Button
    Friend WithEvents strip As ContextMenuStrip
    Friend WithEvents AddElementToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CheckAvailabilityToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents updateToolStripMenuItem As ToolStripMenuItem
End Class
