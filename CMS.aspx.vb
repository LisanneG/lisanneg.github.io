Imports System.Data
Imports System.Data.OleDb
Imports System.Windows.Controls
Partial Class CMS
    Inherits System.Web.UI.Page
    Public custom As New custom()

    Sub Page_Load()
        If Not PageName.Items.Count > 0 Then
            Dim newListItem As ListItem
            Dim conn = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:/School/Vakken/Stage/Websites/Tajem/Visual Studio/database/tajem.mdb")
            Dim sql As String = "SELECT pageName FROM ContentText"
            Dim cmd As OleDbCommand = New OleDbCommand(sql, conn)
            conn.Open()
            Dim reader As OleDbDataReader = cmd.ExecuteReader
            While (reader.Read())
                newListItem = New ListItem(reader("pageName").ToString)
                PageName.Items.Add(newListItem)
            End While
            conn.Close()
        End If
    End Sub

    'Loads page content
    Protected Sub loadPageContent(sender As Object, e As EventArgs)
        Dim conn = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Server.MapPath("/database/tajem.mdb"))
        Dim getPageName As String
        For Each item As ListItem In PageName.Items
            If item.Selected Then
                getPageName = item.Text
            End If
        Next
        'TextBoxCommitment.Text = getPageName

        Dim sql As String = "SELECT contentText FROM ContentText WHERE PageName='" & getPageName & "'"
        Dim cmd As OleDbCommand = New OleDbCommand(sql, conn)
        conn.Open()
        Dim reader As OleDbDataReader = cmd.ExecuteReader
        If (reader.Read()) Then
            CKEditor1.Text = reader.GetValue(0).ToString
            conn.Close()
        End If
        invisiblePageName.Visible = False
        invisiblePageName.Text = getPageName
    End Sub
    'update page content
    Protected Sub updatePageContent(sender As Object, e As EventArgs)
        Dim conn = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Server.MapPath("/database/tajem.mdb"))
        Dim getPageName As String = invisiblePageName.Text
        Dim sql As String = "UPDATE ContentText SET contentText='" & CKEditor1.Text & "' WHERE pageName='" & getPageName & "'"
        Dim cmd As OleDbCommand = New OleDbCommand(sql, conn)
        conn.Open()
        cmd.ExecuteNonQuery()
        invisiblePageName.Visible = False
        msg.Text = "<div class='alert alert-success'><strong>Success!</strong> Text has been updated</div>"
    End Sub
    'create new page
    Protected Sub createPage_Click(sender As Object, e As EventArgs)
        Dim newPageName As String = Request.Form("newPageName")
        My.Computer.FileSystem.CopyFile("E:\School\Vakken\Stage\Websites\Tajem\Template\Template.aspx", "E:\School\Vakken\Stage\Websites\Tajem\Visual Studio\" & newPageName & ".aspx",
    Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
    Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
        Dim conn = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Server.MapPath("/database/tajem.mdb"))
        Dim sql As String = "INSERT INTO ContentText (PageName, contentText) VALUES ('" & newPageName & "', 'Lorem ipsum dolor sit amet, malorum complectitur vel ei.')"
        Dim cmd As OleDbCommand = New OleDbCommand(sql, conn)
        Try
            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()
            msg.Text = "<div class='alert alert-success'><strong>Success!</strong> New page made, named '" & newPageName & "'</div>"
        Catch ex As Exception
            msg.Text = "<div class='alert alert-danger'><strong>danger!</strong> Something went wrong</div>"
        End Try
    End Sub
    'delete page
    Protected Sub DeletePage_Click(sender As Object, e As EventArgs)
        Dim conn = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Server.MapPath("/database/tajem.mdb"))
        Dim getPageName As String
        For Each item As ListItem In PageName.Items
            If item.Selected Then
                getPageName = item.Text
            End If
        Next
        Dim sql As String = "DELETE FROM ContentText WHERE PageName='" & getPageName & "'"
        Dim cmd As OleDbCommand = New OleDbCommand(sql, conn)
        Try
            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()
            msg.Text = "<div class='alert alert-success'><strong>Success!</strong> You deleted a page called: " & getPageName & "</div>"
        Catch ex As Exception
            msg.Text = "<div class='alert alert-danger'><strong>danger!</strong> Something went wrong</div>"
        End Try
        My.Computer.FileSystem.DeleteFile("E:\School\Vakken\Stage\Websites\Tajem\Visual Studio\" & getPageName & ".aspx",
        Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
        Microsoft.VisualBasic.FileIO.RecycleOption.DeletePermanently,
        Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
    End Sub
End Class
