Imports System.Drawing
Imports System.Windows.Forms
Imports System.IO
'Imports System.Windows.Forms.DataVisualization.Charting


Public Class Form1
    Dim strBasePath As String
    Dim strFilePath, FILE_NAME As String
    Dim strFileName As String
    'Inherits Form
    'Private treeView1 As TreeView
    Private showCheckedNodesButton As Button

    Public Sub New()
        TreeView1 = New TreeView
        showCheckedNodesButton = New Button

        Me.SuspendLayout()

        ' Initialize treeView1.
        TreeView1.Location = New Point(0, 25)
        TreeView1.Size = New Size(292, 248)
        'TreeView1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Bottom Or AnchorStyles.Right
        TreeView1.CheckBoxes = True

        ' Add nodes to treeView1.
        Dim node As TreeNode
        Dim x As Integer
        For x = 0 To 3
            ' Add a root node.
            node = TreeView1.Nodes.Add(String.Format("Node{0}", x * 4))
            Dim y As Integer
            For y = 1 To 4
                ' Add a node as a child of the previously added node.
                node = node.Nodes.Add(String.Format("Node{0}", x * 4 + y))
            Next y
        Next x

        ' Set the checked state of one of the nodes to
        ' demonstrate the showCheckedNodesButton button behavior.
        TreeView1.Nodes(1).Nodes(0).Nodes(0).Checked = True

        ' Initialize showCheckedNodesButton.
        showCheckedNodesButton.Size = New Size(144, 24)
        showCheckedNodesButton.Text = "Show Checked Nodes"
        AddHandler showCheckedNodesButton.Click, AddressOf showCheckedNodesButton_Click

        ' Initialize the form.
        Me.ClientSize = New Size(292, 273)
        Me.Controls.AddRange(New Control() {showCheckedNodesButton, TreeView1})

        'Me.ResumeLayout(False)
    End Sub

    <STAThreadAttribute()>
    Shared Sub Main()
        Application.Run(New Form1)
    End Sub

    Private Sub showCheckedNodesButton_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Disable redrawing of treeView1 to prevent flickering 
        ' while changes are made.
        TreeView1.BeginUpdate()

        ' Collapse all nodes of treeView1.
        TreeView1.CollapseAll()

        ' Add the CheckForCheckedChildren event handler to the BeforeExpand event.
        AddHandler TreeView1.BeforeExpand, AddressOf CheckForCheckedChildren

        ' Expand all nodes of treeView1. Nodes without checked children are 
        ' prevented from expanding by the checkForCheckedChildren event handler.
        TreeView1.ExpandAll()

        ' Remove the checkForCheckedChildren event handler from the BeforeExpand 
        ' event so manual node expansion will work correctly.
        RemoveHandler TreeView1.BeforeExpand, AddressOf CheckForCheckedChildren

        ' Enable redrawing of treeView1.
        TreeView1.EndUpdate()
    End Sub

    ' Prevent expansion of a node that does not have any checked child nodes.
    Private Sub CheckForCheckedChildren(ByVal sender As Object, ByVal e As TreeViewCancelEventArgs)
        If Not HasCheckedChildNodes(e.Node) Then
            e.Cancel = True
        End If
    End Sub
    Private Function GetCheckedNodes() As List(Of TreeNode)
        Dim result As New List(Of TreeNode)

        'Get the root nodes
        Dim nodes As New Stack(Of TreeNode)
        For Each tn As TreeNode In TreeView1.Nodes
            nodes.Push(tn)
        Next

        'Check each node and it's children
        While nodes.Count > 0
            Dim popNode As TreeNode = nodes.Pop
            If popNode.Checked Then
                result.Add(popNode)
            End If
            For Each tn As TreeNode In popNode.Nodes
                nodes.Push(tn)
            Next
        End While

        Return result
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        For Each tn As TreeNode In GetCheckedNodes()
            MessageBox.Show(tn.Text)
        Next

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim myChart As Chart = New Chart
        'myChart.Location = New Point(50, 50)
        ''Chart1.Size = New Size(500, 500)
        ''Me.Controls.Add(myChart)
        'Dim ca As New ChartArea("ChartArea1")
        'Chart1.ChartAreas.Add(ca)
        'Dim cl As New Legend("Legend1")
        'Chart1.Legends.Add(cl)
        ''Dim cs As New Series("Series1")
        ''For i As Integer = 1 To 5
        ''    cs.Points.Add(i ^ 2)
        ''Next
        ''cs.ChartType = SeriesChartType.Line
        ''cs.IsVisibleInLegend = True
        ''cs.IsValueShownAsLabel = True
        ''Chart1.Series.Add(cs)

    End Sub

    Private Sub Chart1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        'Me.Chart1.Series("Series1").Points.AddXY("Mark", 33)
        'Me.Chart1.Series("Series1").Points.AddXY("Jogn", 63)
    End Sub

    ' Returns a value indicating whether the specified 
    ' TreeNode has checked child nodes.
    Private Function HasCheckedChildNodes(ByVal node As TreeNode) As Boolean
        If node.Nodes.Count = 0 Then
            Return False
        End If
        Dim childNode As TreeNode
        For Each childNode In node.Nodes
            If childNode.Checked Then
                Return True
            End If
            ' Recursively check the children of the current child node.
            If HasCheckedChildNodes(childNode) Then
                Return True
            End If
        Next childNode
        Return False
    End Function 'HasCheckedChildNodes
End Class


