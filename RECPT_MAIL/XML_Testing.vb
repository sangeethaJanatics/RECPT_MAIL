Imports System.Data.OleDb

Imports System.IO
Imports System.Xml


Public Class XML_Testing
    Dim ds As New DataSet
    Dim con As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 8.0;HDR={1}'"
    Private Sub ReadXmlButton_Click(sender As Object, e As EventArgs) Handles ReadXmlButton.Click
        ' String filePath = "Complete path where you saved the XML file"

        ds = New DataSet
        'ds.ReadXml("d:\projects\RECPT_MAIL\RECPT_MAIL\authors.xml")
        'ds.ReadXml(Environment.CurrentDirectory("authors.xml"))
        'ds.ReadXml("C:\Users\edp005\Desktop\Untitled 1.xml")
        ds.ReadXml("fms3.xml")

        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "product"
        'WriteXmlToFile(ds)
    End Sub

    Private Sub ShowSchemaButton_Click(sender As Object, e As EventArgs) Handles ShowSchemaButton.Click
        Dim swXML As New StringWriter
        '= New System.IO.StringWriter()
        ds.WriteXmlSchema(swXML)
        TextBox1.Text = swXML.ToString()
    End Sub
    Private Sub WriteXmlToFile(ByVal thisDataSet As DataSet)
        If thisDataSet Is Nothing Then
            Return
        End If

        Dim filename As String = "d:\projects\RECPT_MAIL\RECPT_MAIL\XmlDoc.xml"
        Dim stream As System.IO.FileStream = New System.IO.FileStream(filename, System.IO.FileMode.Create)
        Dim xmlWriter As System.Xml.XmlTextWriter = New System.Xml.XmlTextWriter(stream, System.Text.Encoding.Unicode)
        thisDataSet.WriteXml(xmlWriter)
        xmlWriter.Close()
    End Sub

    Private Sub WritexmlFile_Click(sender As Object, e As EventArgs) Handles WritexmlFile.Click
        ds = New DataSet
        sql = "select * from jan_bi_sales_user"
        sql = "select * from (select bill_to_cust_Name,sum(quantity_invoiced*unit_selling_price)sale_val from jan_sales_any_1_copy where trx_date>='1-feb-2020' group by bill_to_cust_Name order by bill_to_cust_Name ) " ' where bill_to_cust_Name like 'C%'"
        ds = SQL_SELECT("data", sql)
        'TextBox1.Text = ds.GetXml()
        'Dim xmlFilename As String = "sale.xml"
        'Dim streamWrite As System.IO.FileStream = New System.IO.FileStream(xmlFilename, System.IO.FileMode.Create)
        'ds.WriteXml(streamWrite)
        'streamWrite.Close()

        Dim xmlDoc As Xml.XmlDocument = New Xml.XmlDocument()
        xmlDoc.Load("sale.xml")

        'Dim courseName = "DEF Course"

        For i = 0 To ds.Tables("data").Rows.Count - 1
            With xmlDoc.SelectSingleNode("/NewDataSet").CreateNavigator().AppendChild()
                .WriteStartElement("Data")
                .WriteElementString("BILL_TO_CUST_NAME", "" & ds.Tables("data").Rows(i).Item("BILL_TO_CUST_NAME") & "")
                .WriteElementString("SALE_VAL", "" & ds.Tables("data").Rows(i).Item("SALE_VAL") & "")
                .WriteEndElement()
                .Close()
            End With
        Next
        xmlDoc.Save("sale.xml")
        MessageBox.Show("DATA Saved", "SS", MessageBoxButtons.OK)



    End Sub

    Private Sub btn_modify_Click(sender As Object, e As EventArgs) Handles btn_modify.Click
        'Dim xmlDoc As Xml.XmlDocument = New Xml.XmlDocument()
        'xmlDoc.Load("Course.xml")

        'Dim courseName = "DEF Course"
        'With xmlDoc.SelectSingleNode("/Courses/Course[Name = '" & courseName & "']/Lesson").CreateNavigator().AppendChild()
        '    .WriteStartElement("Lesson")
        '    .WriteElementString("Lesson_name", "Learn something else2!")
        '    .WriteElementString("Lesson_date", "YY/YY/YYYY")
        '    .WriteEndElement()
        '    .Close()
        '    xmlDoc.Save("Course.xml")
        'End With


        Dim xmlDoc As Xml.XmlDocument = New Xml.XmlDocument()
        xmlDoc.Load("sale.xml")

        Dim courseName = "DEF Course"
        With xmlDoc.SelectSingleNode("/NewDataSet/Data").CreateNavigator().AppendChild()
            .WriteStartElement("Date_New")
            .WriteElementString("Date_New", "28-feb-2020")

            .WriteEndElement()
            .Close()
            xmlDoc.Save("sale.xml")
        End With

    End Sub

    Private Sub btn_create_new_xml_file_Click(sender As Object, e As EventArgs) Handles btn_create_new_xml_file.Click
        'Dim writeStart As Boolean
        'If Not IO.File.Exists("doc.xml") Then writeStart = True
        'Dim xmlFile As IO.FileStream = New IO.FileStream("doc.xml", IO.FileMode.Append)
        'Dim myXmlTextWriter As New Xml.XmlTextWriter(xmlFile, System.Text.Encoding.Default)

        'With myXmlTextWriter
        '    .Formatting = Xml.Formatting.Indented
        '    .Indentation = 3
        '    .IndentChar = CChar(" ")
        '    If writeStart Then .WriteStartDocument()
        '    .WriteComment("Data for 3030")
        '    .WriteStartElement("3030")
        '    .WriteElementString("jod", "364887")
        '    .WriteElementString("aag_SN", "782 YvV0007")
        '    .WriteElementString("te", "9.03")
        '    .WriteFullEndElement()
        '    .Close()
        'End With

        'Dim writeStart As Boolean
        'If Not IO.File.Exists("doc.xml") Then writeStart = True

        'Dim xmlFile As IO.FileStream = New IO.FileStream("doc.xml", IO.FileMode.Append)
        'Dim myXmlTextWriter As New Xml.XmlTextWriter(xmlFile, System.Text.Encoding.Default)
        'If writeStart Then
        '    With myXmlTextWriter
        '        .Formatting = Xml.Formatting.Indented
        '        .Indentation = 3
        '        .IndentChar = CChar(" ")
        '        .WriteStartDocument()
        '        .WriteStartElement("root")
        '        .WriteEndElement()
        '    End With
        'End If
        'myXmlTextWriter.Close()

        'AddXmlData("c:\temp\doc.xml", "a3030", "364887", "782 YvV0007", "9.03")


        'Dim writer As New XmlTextWriter("product.xml", System.Text.Encoding.UTF8)
        'writer.WriteStartDocument(True)
        'writer.Formatting = Formatting.Indented
        'writer.Indentation = 2
        'writer.WriteStartElement("Table")
        'createNode(1, "Product 1", "1000", writer)
        'createNode(2, "Product 2", "2000", writer)
        'createNode(3, "Product 3", "3000", writer)
        'createNode(4, "Product 4", "4000", writer)
        'writer.WriteEndElement()
        'writer.WriteEndDocument()
        'writer.Close()
        ''  , , reading_time, 

        'Dim writer As New XmlTextWriter("FMS3.xml", System.Text.Encoding.UTF8)
        'writer.WriteStartDocument(True)
        'writer.Formatting = Formatting.Indented
        'writer.Indentation = 2
        'writer.WriteStartElement("Table")
        'createNode("1Z0103", 18, "1", writer)
        'createNode("1Z0103", 18.5, "1", writer)
        'createNode("1Z0103", 18.2, "1", writer)
        'createNode("1Z0103", 18.9, "1", writer)
        'writer.WriteEndElement()
        'writer.WriteEndDocument()
        'writer.Close()
        'End
        Dim xmlDoc As Xml.XmlDocument = New Xml.XmlDocument()
        xmlDoc.Load("FMS2.xml")
        Dim air_flow As Double = 18
        Dim courseName = "DEF Course"
        For i = 0 To 200
            If air_flow >= 28 Then air_flow = 18
            air_flow += 0.2
            System.Threading.Thread.Sleep(1000)

            With xmlDoc.SelectSingleNode("/Table").CreateNavigator().AppendChild()
                System.Threading.Thread.Sleep(300)
                .WriteStartElement("Product")
                .WriteStartElement("fm_id")
                .WriteString("1Z0102")
                .WriteEndElement()
                .WriteStartElement("air_flow")
                .WriteString(air_flow)
                .WriteEndElement()
                .WriteStartElement("run_ideal")
                .WriteString(0)
                .WriteEndElement()
                .WriteStartElement("reading_date")
                .WriteString(Format(Date.Now, "dd-MM-yyyy"))
                .WriteEndElement()
                .WriteStartElement("reading_time")
                .WriteString(Format(TimeOfDay, "HH:mm:ss"))
                .WriteEndElement()
                .WriteStartElement("unit_code")
                .WriteString(1)
                .WriteEndElement()
                .WriteEndElement()
                .Close()

            End With

        Next
        xmlDoc.Save("FMS2.xml")

        MessageBox.Show("Xml file saved", "FMS", MessageBoxButtons.OK)
    End Sub
    Private Sub createNode(ByVal fm_id As String, ByVal air_flow As String, ByVal unit_code As String, ByVal writer As XmlTextWriter)

        writer.WriteStartElement("Product")
        writer.WriteStartElement("fm_id")
        writer.WriteString(fm_id)
        writer.WriteEndElement()
        writer.WriteStartElement("air_flow")
        writer.WriteString(air_flow)
        writer.WriteEndElement()
        writer.WriteStartElement("run_ideal")
        writer.WriteString(0)
        writer.WriteEndElement()
        writer.WriteStartElement("reading_date")
        writer.WriteString(Format(Date.Now, "dd-MM-yyyy"))
        writer.WriteEndElement()
        writer.WriteStartElement("reading_time")
        writer.WriteString(Format(TimeOfDay, "HH:mm:ss"))
        writer.WriteEndElement()
        writer.WriteStartElement("unit_code")
        writer.WriteString(unit_code)
        writer.WriteEndElement()
        writer.WriteEndElement()

        'writer.WriteStartElement("Product")
        'writer.WriteStartElement("Product_id")
        'writer.WriteString(pID)
        'writer.WriteEndElement()
        'writer.WriteStartElement("Product_name")
        'writer.WriteString(pName)
        'writer.WriteEndElement()
        'writer.WriteStartElement("Product_price")
        'writer.WriteString(pPrice)
        'writer.WriteEndElement()
        'writer.WriteEndElement()
    End Sub



    Private Sub create_xml_from_xl_Click(sender As Object, e As EventArgs) Handles create_xml_from_xl.Click
        'If txt_sheet_name.Text <> "" Then



        Dim filePath As String = "C:\Users\edp005\Desktop\Sample data -AVG & RAW.xls"

        Dim extension As String = Path.GetExtension(filePath)
        Dim conStr As String, sheetName As String

        conStr = String.Empty
        Select Case extension

            Case ".xls"
                conStr = String.Format(con, filePath, "YES")
                Exit Select
        End Select


        Using con As New OleDbConnection(conStr)
            Using cmd As New OleDbCommand()
                cmd.Connection = con
                con.Open()
                Dim dtExcelSchema As DataTable = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
                'sheetName = dtExcelSchema.Rows(1)("TABLE_NAME").ToString()
                'sheetName = dtExcelSchema.Rows(0)( ("TABLE_NAME").ToString()

                sheetName = "Unit 2" & "$"

                con.Close()
            End Using
        End Using

        Dim dt As New DataTable()
        Using con As New OleDbConnection(conStr)
            Using cmd As New OleDbCommand()
                Using oda As New OleDbDataAdapter()

                    cmd.CommandText = (Convert.ToString("SELECT * From [") & sheetName) + "]"
                    cmd.Connection = con
                    con.Open()
                    oda.SelectCommand = cmd
                    oda.Fill(dt)
                    con.Close()


                    DataGridView1.DataSource = dt
                End Using
            End Using
        End Using

        ds = New DataSet
        ds.Tables.Add(dt)
        Dim xmlFilename As String = "FMS_sample_unit2.xml"
        Dim streamWrite As System.IO.FileStream = New System.IO.FileStream(xmlFilename, System.IO.FileMode.Create)
        ds.WriteXml(streamWrite)
        streamWrite.Close()

        'Dim xmlDoc As Xml.XmlDocument = New Xml.XmlDocument()
        ''xmlDoc.Load("sale.xml")

        '''Dim courseName = "DEF Course"

        'For i = 0 To ds.Tables("data").Rows.Count - 1
        '    With xmlDoc.SelectSingleNode("/NewDataSet").CreateNavigator().AppendChild()
        '        .WriteStartElement("Data")
        '        .WriteElementString("BILL_TO_CUST_NAME", "" & ds.Tables("data").Rows(i).Item("BILL_TO_CUST_NAME") & "")
        '        .WriteElementString("SALE_VAL", "" & ds.Tables("data").Rows(i).Item("SALE_VAL") & "")
        '        .WriteEndElement()
        '        .Close()
        '    End With
        'Next
        'xmlDoc.Save("sale.xml")
        MessageBox.Show("DATA Saved", "SS", MessageBoxButtons.OK)


    End Sub
    Private Sub btn_xml_query_Click(sender As Object, e As EventArgs) Handles btn_xml_query.Click
        Dim xmlDoc As Xml.XmlDocument = New Xml.XmlDocument()
        xmlDoc.Load("FMS2.xml")

        '  XmlDocument doc = New XmlDocument()
        'doc.Load("books.xml")

        Dim currNode As XmlNode = xmlDoc.DocumentElement.FirstChild
        TextBox1.Text = currNode.InnerText
        Exit Sub

        Dim query As String
        query = "Select Doc.query('/Persons/Person[Salary>12000]') From #TempXML WHERE DocId=1"
        query = "Select Doc.query('/Table/Product[air_flow=18]') From #document WHERE DocId=1"


    End Sub



    Private Sub btn_xml_to_sqlserver_Click(sender As Object, e As EventArgs) Handles btn_xml_to_sqlserver.Click
        'ds = New DataSet
        'sql = "select * from jan_flow_meter_lines where flow_meter_id='1Z0103'"
        'ds = return_ds(sql, "data")
        'DataGridView1.DataSource = ds.Tables("data")
        'ds = New DataSet
        'ds.ReadXml("fms3.xml")

        'Dim xmlDoc As Xml.XmlDocument = New Xml.XmlDocument()
        'xmlDoc.Load("fms1.xml")
        'TextBox1.Text = xmlDoc.InnerXml

        Dim xdoc As XmlDocument = New XmlDocument()
        xdoc.Load("fms1.xml")

        For Each xnode As XmlNode In xdoc.SelectNodes("Table/Product")
            If xnode.SelectSingleNode("reading_time").InnerText = "22:45:23" Then
                xnode.RemoveAll()
            End If

        Next


        xdoc.Save("fms1.xml")



        'TextBox1.Text = xmlDoc.SelectSingleNode("/Table/Product").ToString
        Exit Sub
        sql = " SET QUERY_GOVERNOR_COST_LIMIT 6000 " 'Line added to prevent the Error :The query has been canceled because the estimated cost of this query (1480) exceeds the configured threshold of 600. Contact the system administrator.'
        sql &= "DECLARE @xmlData Xml
SET @xmlData = '"
        For i = 0 To ds.Tables(0).Rows.Count - 1
            With ds.Tables(0).Rows(i)
                sql &= " <Product>"
                sql &= "<fm_id>" & .Item("fm_id") & "</fm_id>

<air_flow>" & .Item("air_flow") & "</air_flow>

<run_ideal>" & .Item("run_ideal") & "</run_ideal>

<reading_date>" & .Item("reading_date") & "</reading_date>

<reading_time>" & .Item("reading_time") & "</reading_time>

<unit_code>" & .Item("unit_code") & "</unit_code>"
                sql &= " </Product>"

            End With
        Next
        sql &= "'"
        sql &= " EXEC jan_flow_meter_linesXML @xmlData"
        ExecuteSQL(sql)

        MessageBox.Show("data Saved")
    End Sub
    Public Sub TestMethod1()
        'Dim todaysDate1 = New DateTime(2001, 10, 30) ' no nodes selected
        'Dim todaysDate2 = New DateTime(2016, 10, 28) ' one node selected
        'Dim todaysDate3 = New DateTime(2016, 10, 30) ' 2 nodes selected
        'Dim todaysDate4 = New DateTime(2016, 12, 25) ' 3 nodes selected
        'Dim xmlData = "<Info><Details><ID>user</ID><StartDate>23-10-2016</StartDate><EndDate>22-10-2016</EndDate></Details><Details><ID>user1</ID><StartDate>23-10-2016</StartDate><EndDate>29-10-2016</EndDate></Details><Details><ID>user2</ID><StartDate>23-10-2016</StartDate><EndDate>22-11-2016</EndDate></Details></Info>"
        'Dim xdoc As XmlDocument = XmlDocument.Parse(xmlData)
        'Dim nodes = xdoc.Descendants("Details")
        'nodes.Where(Function(x) Date.Compare(Date.Parse(x.Element("EndDate").Value), todaysDate1) > 0).Remove()
        'Assert.AreEqual(0, xdoc.Descendants(CStr("Details")).Count())

        '' Test 2
        'xdoc = XDocument.Parse(xmlData)
        'nodes = xdoc.Descendants("Details")
        'nodes.Where(Function(x) Date.Compare(Date.Parse(x.Element("EndDate").Value), todaysDate2) > 0).Remove()
        'Assert.AreEqual(1, xdoc.Descendants(CStr("Details")).Count())

        '' Test 3
        'xdoc = XDocument.Parse(xmlData)
        'nodes = xdoc.Descendants("Details")
        'nodes.Where(Function(x) Date.Compare(Date.Parse(x.Element("EndDate").Value), todaysDate3) > 0).Remove()
        'Assert.AreEqual(2, xdoc.Descendants(CStr("Details")).Count())

        '' Test 4
        'xdoc = XmlDocument.Parse(xmlData)
        'nodes = xdoc.Descendants("Details")
        'nodes.Where(Function(x) Date.Compare(Date.Parse(x.Element("EndDate").Value), todaysDate4) > 0).Remove()
        'Assert.AreEqual(3, xdoc.Descendants(CStr("Details")).Count())
    End Sub
End Class