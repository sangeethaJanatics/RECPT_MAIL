<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cog_login
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.BTN_LOGIN = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.TXT_UNAME = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TXT_PWD = New System.Windows.Forms.TextBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BTN_LOGIN
        '
        Me.BTN_LOGIN.Location = New System.Drawing.Point(320, 133)
        Me.BTN_LOGIN.Name = "BTN_LOGIN"
        Me.BTN_LOGIN.Size = New System.Drawing.Size(75, 23)
        Me.BTN_LOGIN.TabIndex = 2
        Me.BTN_LOGIN.Text = "Login .."
        Me.BTN_LOGIN.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(197, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "User Name :"
        '
        'TXT_UNAME
        '
        Me.TXT_UNAME.Location = New System.Drawing.Point(279, 68)
        Me.TXT_UNAME.Name = "TXT_UNAME"
        Me.TXT_UNAME.Size = New System.Drawing.Size(117, 20)
        Me.TXT_UNAME.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(205, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Password :"
        '
        'TXT_PWD
        '
        Me.TXT_PWD.Location = New System.Drawing.Point(278, 95)
        Me.TXT_PWD.Name = "TXT_PWD"
        Me.TXT_PWD.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TXT_PWD.Size = New System.Drawing.Size(117, 20)
        Me.TXT_PWD.TabIndex = 1
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.RECPT_MAIL.My.Resources.Resources.COG1
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(180, 207)
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'cog_login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.ClientSize = New System.Drawing.Size(431, 205)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.TXT_PWD)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TXT_UNAME)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BTN_LOGIN)
        Me.MaximizeBox = False
        Me.Name = "cog_login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cog Login ...!"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BTN_LOGIN As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TXT_UNAME As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TXT_PWD As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
