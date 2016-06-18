Imports System.Data
Imports System.Data.OleDb
Partial Class Accounts
    Inherits System.Web.UI.Page
    Public custom As New custom()

    Sub Page_Load()
        Dim dbconn, sql, dbcomm, dbread
        dbconn = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; data source=" & Server.MapPath("/database/tajem.mdb"))
        dbconn.Open()
        sql = "SELECT * FROM Accounts"
        dbcomm = New OleDbCommand(sql, dbconn)
        dbread = dbcomm.ExecuteReader()
        customers.DataSource = dbread
        customers.DataBind()

        dbcomm = New OleDbCommand("SELECT * FROM Orders", dbconn)
        dbread = dbcomm.ExecuteReader()
        orders.DataSource = dbread
        orders.DataBind()

        dbread.Close()
        dbconn.Close()
    End Sub
    Protected Sub editbtn_Click(sender As Object, e As EventArgs)
        Dim conn = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Server.MapPath("/database/tajem.mdb"))
        Dim sql As String = "SELECT id FROM Accounts"
        Dim cmd As OleDbCommand = New OleDbCommand(sql, conn)
        conn.Open()
        Dim reader As OleDbDataReader = cmd.ExecuteReader
        While (reader.Read())
            test.Text += reader("id").ToString()
        End While
        conn.Close()
    End Sub
    Protected Sub removebtn_Click(sender As Object, e As EventArgs)
        Dim conn = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Server.MapPath("/database/tajem.mdb"))
        Dim id As String
        For Each item As ListItem In idlist.Items
            If item.Selected Then
                id = item.Text
            End If
        Next
        Dim sql As String = "DELETE * FROM Accounts WHERE Id='5'"
        Dim cmd As OleDbCommand = New OleDbCommand(sql, conn)
        conn.Open()
        cmd.ExecuteNonQuery()
    End Sub
End Class
