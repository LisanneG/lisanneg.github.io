Imports System.Data
Imports System.Data.OleDb
Partial Class Account_Log_In
    Inherits System.Web.UI.Page
    Public custom As New custom()


    Protected Sub Loginbtn_Click(sender As Object, e As EventArgs)
        Dim username As String = Request.Form("username")
        Dim password As String = Request.Form("password")
        Dim success As Boolean = False
        msg.Text = ""

        Dim conn = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Server.MapPath("/database/tajem.mdb"))
        Dim sql As String = "SELECT Username, AccountPass FROM Accounts"
        Dim cmd As OleDbCommand = New OleDbCommand(sql, conn)
        conn.Open()
        Dim reader As OleDbDataReader = cmd.ExecuteReader

        While (reader.Read())
            If reader("Username").ToString() Like username And reader("AccountPass").ToString() Like password Then
                success = True
                Session("username") = username
                Session("login") = True
            End If
        End While
        If success = False Then
            msg.Text = "<div class='alert alert-danger'><strong>Error:</strong> Incorrect username/password please try again, or <a href='/contact'>contact</a> us.</div>"
        Else
            If stayLoggedIn.Checked Then
                Session.Timeout = 9999
            End If
            msg.Text = "<div class='alert alert-success'><b>Hello " & username & "</b>, You have successfully logged in!</div>"
        End If
        conn.Close()
    End Sub
End Class
