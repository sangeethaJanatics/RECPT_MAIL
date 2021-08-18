<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FMS_desktop
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
        Me.DGV1 = New System.Windows.Forms.DataGridView()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.Rad_dashboard = New System.Windows.Forms.RadioButton()
        Me.Rad_high_cons = New System.Windows.Forms.RadioButton()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.link_sync_data = New System.Windows.Forms.LinkLabel()
        Me.btn_upload = New System.Windows.Forms.Button()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGV1
        '
        Me.DGV1.AllowUserToAddRows = False
        Me.DGV1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV1.BackgroundColor = System.Drawing.Color.White
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(12, 41)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.ReadOnly = True
        Me.DGV1.RowTemplate.Height = 35
        Me.DGV1.Size = New System.Drawing.Size(1139, 154)
        Me.DGV1.TabIndex = 1
        Me.DGV1.Visible = False
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WebBrowser1.Location = New System.Drawing.Point(10, 42)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(1139, 421)
        Me.WebBrowser1.TabIndex = 2
        '
        'Rad_dashboard
        '
        Me.Rad_dashboard.AutoSize = True
        Me.Rad_dashboard.Checked = True
        Me.Rad_dashboard.Font = New System.Drawing.Font("Verdana", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rad_dashboard.ForeColor = System.Drawing.Color.Orange
        Me.Rad_dashboard.Location = New System.Drawing.Point(106, 4)
        Me.Rad_dashboard.Name = "Rad_dashboard"
        Me.Rad_dashboard.Size = New System.Drawing.Size(244, 36)
        Me.Rad_dashboard.TabIndex = 3
        Me.Rad_dashboard.TabStop = True
        Me.Rad_dashboard.Text = "Machine-Wise"
        Me.Rad_dashboard.UseVisualStyleBackColor = True
        '
        'Rad_high_cons
        '
        Me.Rad_high_cons.AutoSize = True
        Me.Rad_high_cons.Font = New System.Drawing.Font("Verdana", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Rad_high_cons.ForeColor = System.Drawing.Color.Orange
        Me.Rad_high_cons.Location = New System.Drawing.Point(395, 4)
        Me.Rad_high_cons.Name = "Rad_high_cons"
        Me.Rad_high_cons.Size = New System.Drawing.Size(315, 36)
        Me.Rad_high_cons.TabIndex = 3
        Me.Rad_high_cons.Text = "Consumption-wise"
        Me.Rad_high_cons.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 10000
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackgroundImage = Global.RECPT_MAIL.My.Resources.Resources.logo
        Me.PictureBox1.Location = New System.Drawing.Point(994, 1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(157, 40)
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'link_sync_data
        '
        Me.link_sync_data.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.link_sync_data.AutoSize = True
        Me.link_sync_data.LinkColor = System.Drawing.Color.White
        Me.link_sync_data.Location = New System.Drawing.Point(1053, 471)
        Me.link_sync_data.Name = "link_sync_data"
        Me.link_sync_data.Size = New System.Drawing.Size(92, 13)
        Me.link_sync_data.TabIndex = 5
        Me.link_sync_data.TabStop = True
        Me.link_sync_data.Text = "Sync Master Data"
        '
        'btn_upload
        '
        Me.btn_upload.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_upload.Location = New System.Drawing.Point(923, 466)
        Me.btn_upload.Name = "btn_upload"
        Me.btn_upload.Size = New System.Drawing.Size(124, 23)
        Me.btn_upload.TabIndex = 6
        Me.btn_upload.Text = "Upload Data to Cloud"
        Me.btn_upload.UseVisualStyleBackColor = True
        '
        'FMS_desktop
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.CornflowerBlue
        Me.ClientSize = New System.Drawing.Size(1157, 490)
        Me.Controls.Add(Me.btn_upload)
        Me.Controls.Add(Me.link_sync_data)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Rad_high_cons)
        Me.Controls.Add(Me.Rad_dashboard)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Controls.Add(Me.DGV1)
        Me.Name = "FMS_desktop"
        Me.Text = "AFMS"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DGV1 As DataGridView
    Friend WithEvents WebBrowser1 As WebBrowser
    Friend WithEvents Rad_dashboard As RadioButton
    Friend WithEvents Rad_high_cons As RadioButton
    Friend WithEvents Timer1 As Timer
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents link_sync_data As LinkLabel
    Friend WithEvents btn_upload As Button
End Class
