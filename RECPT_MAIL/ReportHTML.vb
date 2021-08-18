Option Strict Off
Option Explicit On
Friend Class ReportHTML
	'
	' Module level variables.
	'
	Private mstrCurrentHTML As String 'HTML from CreateReport
	Private mstrWebDirectory As String 'name of the HTML output directory
	Private mstrWebFilename As String 'name of the HTML output file
	Private mstrReportTitle As String 'Report Title
	Private mstrReportSubtitle As String 'Report Subtitle
	Private mstrPageTitle As String 'HTML page title
	Private mstrPageBackground As String 'Page background image
	Private mstrPageLogo As String 'logo image file
	Private mstrPageFont As String 'page font
	Private mstrTableHeaderFontSize As String 'table header font size
	Private mstrTableBodyFontSize As String 'table body font size
	Private mstrTableColor As String 'table header color
	Private mstrTableTextColor As String 'table header text color
	Private mstrTableWidth As String
	Private mstrTableCellPadding As String
	Private mstrTableCellSpacing As String
	Private mstrTableBorder As String
	Private mstrFooterString As String
	
	'
	' Default page settings.
	'
	'Private Const mksWebDirectoryDef       As String = "F:\InetPub\wwwroot\Reports\"
    Private Const mksWebDirectoryDef As String = "D:\"
    Private Const mksWebFilenameDef As String = "WebOutput.xls"
	Private Const mksReportTitleDef As String = "Web Report"
	Private Const mksReportSubtitleDef As String = "Created by WebReport"
	Private Const mksPageTitleDef As String = "Web Report"
	Private Const mksPageBackgroundDef As String = "#FFFFFF" 'or can be Background file
	Private Const mksPageLogoDef As String = "../vbpjlogo.gif"
	Private Const mksPageFontDef As String = "Verdana"
	Private Const mksTableHeaderFontSizeDef As String = "2"
	Private Const mksTableBodyFontSizeDef As String = "2"
    Private Const mksTableColorDef As String = "#C8BBBE"
	Private Const mksTableTextColorDef As String = "#FFFFFF" 'white #000000 = black
    Private Const mksTableWidthDef As String = "50%"
	Private Const mksTableCellPaddingDef As String = "8"
	Private Const mksTableCellSpacingDef As String = "0"
	Private Const mksTableBorderDef As String = "1"
	Private Const mksFooterStringDef As String = "www.TheScarms.com"
    '	Public Function CreateReport(ByRef rst As ADODB.Recordset) As String
    '		Dim strHTML As String
    '		Dim lngRows As Integer
    '		Dim lngRow As Integer
    '		Dim lngCols As Integer
    '        Dim lngCol As Integer
    '        Dim align As String
    '		'
    '		' Returns an HTML string containing a report from RptData
    '		'

    '		On Error GoTo ErrorHandler
    '		If rst.EOF Then Exit Function

    '		'
    '		' Write the HEAD section of the html file.
    '		'
    '		strHTML = "<HTML>" & vbCrLf & "<HEAD>" & vbCrLf
    '		strHTML = strHTML & "<meta http-equiv=""Content-Type"" content=""text/html; charset=iso-8859-1"">" & vbCrLf
    '		'UPGRADE_WARNING: App property App.EXEName has a new behavior. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6BA9B8D2-2A32-4B6E-8D36-44949974A5B4"'
    '		strHTML = strHTML & "<meta name=""GENERATOR"" content=""" & My.Application.Info.AssemblyName & " " & FormatAppVersion() & """>" & vbCrLf

    '		strHTML = strHTML & "<TITLE>" & mstrPageTitle & "</TITLE>" & vbCrLf
    '		strHTML = strHTML & "</HEAD>" & vbCrLf & vbCrLf

    '		'
    '		' Write the BODY tag of the html file.
    '		'
    '		strHTML = strHTML & "<BODY "
    '		If InStr(mstrPageBackground, "#") = 0 Then
    '			strHTML = strHTML & " BACKGROUND=""" & mstrPageBackground & """>" & vbCrLf
    '		Else
    '			strHTML = strHTML & " BGCOLOR=""" & mstrPageBackground & """>" & vbCrLf
    '		End If

    '        'strHTML = strHTML & "<P ALIGN=""Left""><IMG SRC=""" & mstrPageLogo & """></P>" & vbCrLf
    '        'strHTML = strHTML & "<H1>" & mstrReportTitle & "</H1>" & vbCrLf
    '        'strHTML = strHTML & "<H2>" & mstrReportSubtitle & "</H2>" & vbCrLf
    '        'strHTML = strHTML & "<H4>Generated at: " & VB6.Format(Now, "dd-mmm-yyyy hh:mm:ss am/pm") & "</H4>" & vbCrLf & "<HR>" & vbCrLf

    '		'
    '		' Create the Table for the output.
    '		'
    '		strHTML = strHTML & "<FONT FACE=""" & mstrPageFont & ", Helvetica, Arial, sans-serif""> " & vbCrLf
    '        strHTML = strHTML & "<TABLE  align=""center"" WIDTH=""" & mstrTableWidth & """"
    '		strHTML = strHTML & " CELLPADDING=""" & mstrTableCellPadding & """"
    '		strHTML = strHTML & " CELLSPACING=""" & mstrTableCellSpacing & """"
    '		strHTML = strHTML & " BORDER=""" & mstrTableBorder & """"
    '		strHTML = strHTML & ">" & vbCrLf

    '		'
    '		' Loop to create the header.
    '		'
    '		strHTML = strHTML & "<TR BGCOLOR=""" & mstrTableColor & """>" & vbCrLf

    '		lngCols = rst.Fields.Count - 1

    '		For lngCol = 0 To lngCols
    '			strHTML = strHTML & vbTab & "<TD ALIGN=""Center""><FONT COLOR=""" & mstrTableTextColor & """ SIZE=""" & mstrTableHeaderFontSize & """>" & rst.Fields(lngCol).Name & "</FONT></TD>" & vbCrLf
    '		Next 
    '		strHTML = strHTML & "</TR>" & vbCrLf

    '		'
    '		' Loop to build the table.
    '		'
    '		rst.MoveFirst()

    '        Do While Not rst.EOF
    '            strHTML = strHTML & "<TR>" & vbCrLf

    '            For lngCol = 0 To lngCols

    '                If rst.Fields(lngCol).Value.GetType.Name = "Decimal" Then align = "right" Else align = "left"

    '                strHTML = strHTML & vbTab & "<TD ALIGN=" & align & "><FONT COLOR=""" & mstrTableTextColor & """ SIZE=""" & mstrTableBodyFontSize & """>" & rst.Fields(lngCol).Value & "</FONT></TD>" & vbCrLf

    '            Next

    '            strHTML = strHTML & "</TR>" & vbCrLf

    '            rst.MoveNext()
    '        Loop
    '		strHTML = strHTML & "</TABLE>" & vbCrLf

    '		'
    '		' Write the footer.
    '		'
    '        'strHTML = strHTML & "<BR><A HREF=""#Top"">Back to Top </A><H5>"
    '        'strHTML = strHTML & "<I>" & mstrFooterString & vbCrLf
    '        'strHTML = strHTML & "<BR>Generator version: " & FormatAppVersion & "</I></H5>" & vbCrLf
    '		strHTML = strHTML & "</BODY>" & vbCrLf & "</HTML>" & vbCrLf

    '		'
    '		' Save HTML result.
    '		'
    '		mstrCurrentHTML = strHTML
    '		CreateReport = strHTML
    '		Exit Function

    'ErrorHandler: 
    '		'    LogInfo App.EXEName, "Error in CreateReport, Error=" & Err & ", " & Error$
    '		Resume Next
    '	End Function
	Public Sub UpdateHTMLFile()
		Dim strDir As String
		Dim strFile As String
		Dim oFSO As New Scripting.FileSystemObject
		Dim oText As Scripting.TextStream
		'
		' Writes an HTML file to the web server.
		'
		

		
		strDir = mstrWebDirectory
		strFile = mstrWebFilename
		
		If oFSO.FolderExists(strDir) Then
			If Len(mstrCurrentHTML) > 0 Then
				oText = oFSO.CreateTextFile(strDir & strFile, True)
				oText.Write(mstrCurrentHTML)
            End If
            System.Diagnostics.Process.Start(strDir & strFile)
		Else
			Call MsgBox("Info", MsgBoxStyle.Information, "Folder does not exist: " & strDir)
		End If
		
        GoTo NormalExit

        On Error GoTo ErrorHandler
		
ErrorHandler: 
		Call MsgBox("Error", MsgBoxStyle.Exclamation, "Error in UpdateHTMLFile, err: " & Err.Number & ", " & ErrorToString())
		
NormalExit: 
		'UPGRADE_NOTE: Object oFSO may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		oFSO = Nothing
		'UPGRADE_NOTE: Object oText may not be destroyed until it is garbage collected. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="6E35BFF6-CD74-4B09-9689-3E1A43DF8969"'
		oText = Nothing
	End Sub
	Public Property WebDirectory() As String
		Get
			'
			' Returns current web directory.
			'
			WebDirectory = mstrWebDirectory
		End Get
		Set(ByVal Value As String)
			'
			' Sets web directory.
			'
			mstrWebDirectory = Value
		End Set
	End Property
	Public Property WebFilename() As String
		Get
			'
			' Returns current web filename.
			'
			WebFilename = mstrWebFilename
		End Get
		Set(ByVal Value As String)
			'
			' Sets web filename.
			'
			mstrWebFilename = Value
		End Set
	End Property
	Public Property ReportTitle() As String
		Get
			'
			' Returns current report title.
			'
			ReportTitle = mstrReportTitle
		End Get
		Set(ByVal Value As String)
			'
			' Sets report title.
			'
			mstrReportTitle = Value
		End Set
	End Property
	Public Property ReportSubtitle() As String
		Get
			'
			' Returns current report subtitle.
			'
			ReportSubtitle = mstrReportSubtitle
		End Get
		Set(ByVal Value As String)
			'
			' Sets report subtitle.
			'
			mstrReportSubtitle = Value
		End Set
	End Property
	Public Property PageTitle() As String
		Get
			'
			' Returns current page title.
			'
			PageTitle = mstrPageTitle
		End Get
		Set(ByVal Value As String)
			'
			' Sets page title.
			'
			mstrPageTitle = Value
		End Set
	End Property
	Public Property PageBackground() As String
		Get
			'
			' Returns current page background.
			'
			PageBackground = mstrPageBackground
		End Get
		Set(ByVal Value As String)
			'
			' Sets page background.
			'
			mstrPageBackground = Value
		End Set
	End Property
	Public Property PageLogo() As String
		Get
			'
			' Returns current page logo.
			'
			PageLogo = mstrPageLogo
		End Get
		Set(ByVal Value As String)
			'
			' Sets page logo.
			'
			mstrPageLogo = Value
		End Set
	End Property
	
	
	
	Public Property PageFont() As String
		Get
			'
			' Returns current page font.
			'
			PageFont = mstrPageFont
		End Get
		Set(ByVal Value As String)
			'
			' Sets page font.
			'
			mstrPageFont = Value
		End Set
	End Property
	Public Property TableHeaderFontSize() As String
		Get
			'
			' Returns current table header font size.
			'
			TableHeaderFontSize = mstrTableHeaderFontSize
		End Get
		Set(ByVal Value As String)
			'
			' Sets table header font size.
			'
			mstrTableHeaderFontSize = Value
		End Set
	End Property
	
	
	Public Property TableBodyFontSize() As String
		Get
			'
			' Returns current table body font size.
			'
			TableBodyFontSize = mstrTableBodyFontSize
		End Get
		Set(ByVal Value As String)
			'
			' Sets table body font size.
			'
			mstrTableBodyFontSize = Value
		End Set
	End Property
	
	
	Public Property TableColor() As String
		Get
			'
			' Returns current table header row color.
			'
			TableColor = mstrTableColor
		End Get
		Set(ByVal Value As String)
			'
			' Sets table header row color.
			' Must be in form "#FFFFFF"
			If InStr(Value, "#") Then
				mstrTableColor = Value
			End If
		End Set
	End Property
	Public Property TableTextColor() As String
		Get
			'
			' Returns current table header text color.
			'
			TableTextColor = mstrTableTextColor
		End Get
		Set(ByVal Value As String)
			'
			' Sets table header text color.
			' Must be in form "#FFFFFF"
			'
            If InStr(Value, "#") Then
                mstrTableTextColor = Value
            End If
		End Set
	End Property
	Public Property TableWidth() As String
		Get
			'
			' Returns current table width.
			'
			TableWidth = mstrTableWidth
		End Get
		Set(ByVal Value As String)
			'
			' Sets table width.
			'
			mstrTableWidth = Value
		End Set
	End Property
	Public Property TableCellPadding() As String
		Get
			'
			' Returns current table cell padding.
			'
			TableCellPadding = mstrTableCellPadding
		End Get
		Set(ByVal Value As String)
			'
			' Sets table cell padding.
			'
			mstrTableCellPadding = Value
		End Set
	End Property
	Public Property TableCellSpacing() As String
		Get
			'
			' Returns current table cell spacing.
			'
			TableCellSpacing = mstrTableCellSpacing
		End Get
		Set(ByVal Value As String)
			'
			' Sets table cell spacing.
			'
			mstrTableCellSpacing = Value
		End Set
	End Property
	Public Property TableBorder() As String
		Get
			'
			' Returns current table border.
			'
			TableBorder = mstrTableBorder
		End Get
		Set(ByVal Value As String)
			'
			' Sets table border.
			'
			mstrTableBorder = Value
		End Set
	End Property
	Public Property FooterString() As String
		Get
			'
			' Returns current footer string.
			'
			FooterString = mstrFooterString
		End Get
		Set(ByVal Value As String)
			'
			' Sets footer string.
			'
			mstrFooterString = Value
		End Set
	End Property
	Private Sub GetReportSettings()
		'
		' Get the default settings for report.
		'
		mstrWebDirectory = mksWebDirectoryDef
		mstrWebFilename = mksWebFilenameDef
		mstrReportTitle = mksReportTitleDef
		mstrReportSubtitle = mksReportSubtitleDef
		mstrPageTitle = mksPageTitleDef
		mstrPageBackground = mksPageBackgroundDef
		mstrPageLogo = mksPageLogoDef
		mstrPageFont = mksPageFontDef
		mstrTableHeaderFontSize = mksTableHeaderFontSizeDef
		mstrTableBodyFontSize = mksTableBodyFontSizeDef
		mstrTableColor = mksTableColorDef
		mstrTableTextColor = mksTableTextColorDef
		mstrTableWidth = mksTableWidthDef
		mstrTableCellPadding = mksTableCellPaddingDef
		mstrTableCellSpacing = mksTableCellSpacingDef
		mstrTableBorder = mksTableBorderDef
		mstrFooterString = mksFooterStringDef
		
	End Sub
	'UPGRADE_NOTE: Class_Initialize was upgraded to Class_Initialize_Renamed. Click for more: 'ms-help://MS.VSCC.v80/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
	Private Sub Class_Initialize_Renamed()
		'
		' Get default report settings.
		'
		Call GetReportSettings()
	End Sub
	Public Sub New()
        MyBase.New()
		Class_Initialize_Renamed()
	End Sub
	Private Function FormatAppVersion() As String
		
		FormatAppVersion = "V" & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Revision
		
	End Function
End Class