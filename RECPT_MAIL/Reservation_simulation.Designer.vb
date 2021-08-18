<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Reservation_simulation
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
        Me.dgv1 = New System.Windows.Forms.DataGridView()
        Me.btn_view_simulation = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ofd_dt = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Payment_date_from = New System.Windows.Forms.DateTimePicker()
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv1
        '
        Me.dgv1.AllowUserToAddRows = False
        Me.dgv1.AllowUserToDeleteRows = False
        Me.dgv1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgv1.BackgroundColor = System.Drawing.Color.White
        Me.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv1.Location = New System.Drawing.Point(12, 74)
        Me.dgv1.Name = "dgv1"
        Me.dgv1.ReadOnly = True
        Me.dgv1.Size = New System.Drawing.Size(776, 364)
        Me.dgv1.TabIndex = 0
        '
        'btn_view_simulation
        '
        Me.btn_view_simulation.Location = New System.Drawing.Point(552, 24)
        Me.btn_view_simulation.Name = "btn_view_simulation"
        Me.btn_view_simulation.Size = New System.Drawing.Size(106, 23)
        Me.btn_view_simulation.TabIndex = 1
        Me.btn_view_simulation.Text = "View Simulation value"
        Me.btn_view_simulation.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(100, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "OFD UPTO:"
        '
        'ofd_dt
        '
        Me.ofd_dt.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.ofd_dt.Location = New System.Drawing.Point(180, 25)
        Me.ofd_dt.Name = "ofd_dt"
        Me.ofd_dt.Size = New System.Drawing.Size(99, 20)
        Me.ofd_dt.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(293, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(150, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Payment Exp Date From :"
        '
        'Payment_date_from
        '
        Me.Payment_date_from.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Payment_date_from.Location = New System.Drawing.Point(447, 25)
        Me.Payment_date_from.Name = "Payment_date_from"
        Me.Payment_date_from.Size = New System.Drawing.Size(99, 20)
        Me.Payment_date_from.TabIndex = 3
        '
        'Reservation_simulation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Payment_date_from)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ofd_dt)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_view_simulation)
        Me.Controls.Add(Me.dgv1)
        Me.Name = "Reservation_simulation"
        Me.Text = "Reservation Simulation"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgv1 As DataGridView
    Friend WithEvents btn_view_simulation As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents ofd_dt As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Payment_date_from As DateTimePicker
End Class
