<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class XML_Testing
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ReadXmlButton = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ShowSchemaButton = New System.Windows.Forms.Button()
        Me.WritexmlFile = New System.Windows.Forms.Button()
        Me.btn_modify = New System.Windows.Forms.Button()
        Me.btn_create_new_xml_file = New System.Windows.Forms.Button()
        Me.create_xml_from_xl = New System.Windows.Forms.Button()
        Me.btn_xml_query = New System.Windows.Forms.Button()
        Me.btn_xml_to_sqlserver = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 250)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(776, 188)
        Me.DataGridView1.TabIndex = 0
        '
        'ReadXmlButton
        '
        Me.ReadXmlButton.Location = New System.Drawing.Point(713, 6)
        Me.ReadXmlButton.Name = "ReadXmlButton"
        Me.ReadXmlButton.Size = New System.Drawing.Size(75, 23)
        Me.ReadXmlButton.TabIndex = 1
        Me.ReadXmlButton.Text = "ReadXml"
        Me.ReadXmlButton.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(68, 12)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox1.Size = New System.Drawing.Size(561, 170)
        Me.TextBox1.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Label1"
        '
        'ShowSchemaButton
        '
        Me.ShowSchemaButton.Location = New System.Drawing.Point(713, 76)
        Me.ShowSchemaButton.Name = "ShowSchemaButton"
        Me.ShowSchemaButton.Size = New System.Drawing.Size(75, 23)
        Me.ShowSchemaButton.TabIndex = 1
        Me.ShowSchemaButton.Text = "ShowSchema"
        Me.ShowSchemaButton.UseVisualStyleBackColor = True
        '
        'WritexmlFile
        '
        Me.WritexmlFile.Location = New System.Drawing.Point(713, 35)
        Me.WritexmlFile.Name = "WritexmlFile"
        Me.WritexmlFile.Size = New System.Drawing.Size(75, 23)
        Me.WritexmlFile.TabIndex = 1
        Me.WritexmlFile.Text = "WriteXml"
        Me.WritexmlFile.UseVisualStyleBackColor = True
        '
        'btn_modify
        '
        Me.btn_modify.Location = New System.Drawing.Point(713, 105)
        Me.btn_modify.Name = "btn_modify"
        Me.btn_modify.Size = New System.Drawing.Size(75, 23)
        Me.btn_modify.TabIndex = 1
        Me.btn_modify.Text = "Modify XML"
        Me.btn_modify.UseVisualStyleBackColor = True
        '
        'btn_create_new_xml_file
        '
        Me.btn_create_new_xml_file.Location = New System.Drawing.Point(644, 134)
        Me.btn_create_new_xml_file.Name = "btn_create_new_xml_file"
        Me.btn_create_new_xml_file.Size = New System.Drawing.Size(144, 23)
        Me.btn_create_new_xml_file.TabIndex = 1
        Me.btn_create_new_xml_file.Text = "Create New XML"
        Me.btn_create_new_xml_file.UseVisualStyleBackColor = True
        '
        'create_xml_from_xl
        '
        Me.create_xml_from_xl.Location = New System.Drawing.Point(644, 163)
        Me.create_xml_from_xl.Name = "create_xml_from_xl"
        Me.create_xml_from_xl.Size = New System.Drawing.Size(144, 23)
        Me.create_xml_from_xl.TabIndex = 4
        Me.create_xml_from_xl.Text = "Create XML From XL"
        Me.create_xml_from_xl.UseVisualStyleBackColor = True
        '
        'btn_xml_query
        '
        Me.btn_xml_query.Location = New System.Drawing.Point(644, 192)
        Me.btn_xml_query.Name = "btn_xml_query"
        Me.btn_xml_query.Size = New System.Drawing.Size(144, 23)
        Me.btn_xml_query.TabIndex = 4
        Me.btn_xml_query.Text = "Query XML"
        Me.btn_xml_query.UseVisualStyleBackColor = True
        '
        'btn_xml_to_sqlserver
        '
        Me.btn_xml_to_sqlserver.Location = New System.Drawing.Point(597, 221)
        Me.btn_xml_to_sqlserver.Name = "btn_xml_to_sqlserver"
        Me.btn_xml_to_sqlserver.Size = New System.Drawing.Size(180, 23)
        Me.btn_xml_to_sqlserver.TabIndex = 4
        Me.btn_xml_to_sqlserver.Text = "XML to SQL Server Transfer"
        Me.btn_xml_to_sqlserver.UseVisualStyleBackColor = True
        '
        'XML_Testing
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btn_xml_to_sqlserver)
        Me.Controls.Add(Me.btn_xml_query)
        Me.Controls.Add(Me.create_xml_from_xl)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.btn_create_new_xml_file)
        Me.Controls.Add(Me.btn_modify)
        Me.Controls.Add(Me.ShowSchemaButton)
        Me.Controls.Add(Me.WritexmlFile)
        Me.Controls.Add(Me.ReadXmlButton)
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "XML_Testing"
        Me.Text = "XML_Testing"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents ReadXmlButton As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ShowSchemaButton As Button
    Friend WithEvents WritexmlFile As Button
    Friend WithEvents btn_modify As Button
    Friend WithEvents btn_create_new_xml_file As Button
    Friend WithEvents create_xml_from_xl As Button
    Friend WithEvents btn_xml_query As Button
    Friend WithEvents btn_xml_to_sqlserver As Button
End Class
