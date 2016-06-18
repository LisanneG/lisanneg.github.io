Imports System.Data
Imports System.Data.OleDb
Public Partial Class Account_Register
    Inherits Page
    Public custom As New custom()
    Protected Sub submit_Click(sender As Object, e As EventArgs)
        Dim valid = True
        Dim todaysdate As String = String.Format("{0:dd/MM/yyyy}", DateTime.Now)
        Dim username_input As String = Request.Form("username")
        Dim firstname_input As String = Request.Form("firstName")
        Dim lastname_input As String = Request.Form("lastName")
        Dim email_input As String = Request.Form("email")
        Dim password_input As String = Request.Form("password")
        If Not termsAndConditions.Checked Then
            msg.Text = "<div class='alert alert-warning'><strong>Warning!</strong> You need to agree with the Terms & Conditions before you can register</div>"
        Else
            Dim conn = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Server.MapPath("/database/tajem.mdb"))
            Dim sql As String = "SELECT Username, Email FROM Accounts"
            Dim cmd As OleDbCommand = New OleDbCommand(sql, conn)
            conn.Open()
            Dim reader As OleDbDataReader = cmd.ExecuteReader
            While (reader.Read())
                If reader("Username").ToString() Like username_input Then
                    valid = False
                    msg.Text = "<div class='alert alert-warning'><strong>Warning!</strong> The username you typed in already exist, please choose a new one</div>"
                ElseIf reader("Email").ToString() Like email_input Then
                    valid = False
                    msg.Text = "<div class='alert alert-warning'><strong>Warning!</strong> The email you put in already exist, please choose a new one</div>"
                End If
            End While
            conn.Close()
            If valid = True Then
                sql = "INSERT INTO Accounts (FirstName, LastName, AccountDate, Email, Username, AccountPass) VALUES ('" & firstname_input & "', '" & lastname_input & "', '" & todaysdate & "', '" & email_input & "', '" & username_input & "', '" & password_input & "')"
                Dim cmd2 As OleDbCommand = New OleDbCommand(sql, conn)
                Try
                    conn.Open()
                    cmd2.ExecuteNonQuery()
                    conn.Close()
                    msg.Text = "<div class='alert alert-success'><strong>Success!</strong> You have been registered</div>"
                Catch ex As Exception
                    msg.Text = "<div class='alert alert-danger'><strong>danger!</strong> Something went wrong</div>"
                End Try
            End If
        End If
    End Sub
End Class

'Dim conn = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Server.MapPath("/database/tajem.mdb"))
'Dim sql As String = "SELECT Username, Password FROM Accounts"
'Dim cmd As OleDbCommand = New OleDbCommand(sql, conn)
'conn.Open()
'Dim reader As OleDbDataReader = cmd.ExecuteReader

'While (reader.Read())
'If reader("Username").ToString() Like username And reader("Password").ToString() Like password Then
'success = True
'Session("username") = username
'Session("login") = True
'End If
'End While