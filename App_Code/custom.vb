Imports System.Data
Imports System.Data.OleDb
Partial Public Class custom
    Public Function generateMenu() As String
        Dim invalidOptions As String() = {"Default", "Manage", "RegisterExternalLogin", "Template"}
        Dim path As String = HttpContext.Current.Request.Url.AbsolutePath
        Dim args As String = ""
        Dim filehref As String = ""
        Dim files() As String = System.IO.Directory.GetFiles("E:\School\Vakken\Stage\Websites\Tajem\Visual Studio\", "*.aspx", IO.SearchOption.AllDirectories)
        Dim menu As String = ""
        If path Like "/default.aspx" Then
            menu += "<li><a class='active' href='/'>HOME</a></li>"
        Else
            menu += "<li><a href='/'>HOME</a></li>"
        End If
        For Each file In files
            If Not file.Contains("ThankYou") Then
                If file.Contains("Account\") Then
                    file = file.Replace("E:\School\Vakken\Stage\Websites\Tajem\Visual Studio\Account\", "")
                    filehref = "Account\" & file
                Else
                    file = file.Replace("E:\School\Vakken\Stage\Websites\Tajem\Visual Studio\", "")
                    filehref = file
                End If
                filehref = filehref.Replace(".aspx", "")
                file = file.Replace(".aspx", "")
                If file.Contains("_") Then
                    file = file.Replace("_", " ")
                End If
                If Not invalidOptions.Contains(file) Then
                    Select Case file.ToString()
                        Case "CMS", "Log Out", "Accounts"
                            If System.Web.HttpContext.Current.Session("login") = True Then
                                args = "<li><a href='/" & filehref.ToLower() & "'>" & file.ToUpper() & "</a></li>"
                                menu += args
                            End If
                        Case "Log In", "Register"
                            If System.Web.HttpContext.Current.Session("login") = False Then
                                args = "<li><a href='/" & filehref.ToLower() & "'>" & file.ToUpper() & "</a></li>"
                                menu += args
                            End If
                        Case Else
                            If path Like "/" & file Then
                                args = "<li><a class='active' href='/" & filehref.ToLower() & "'>" & file.ToUpper() & "</a></li>"
                            Else
                                args = "<li><a href='/" & filehref.ToLower() & "'>" & file.ToUpper() & "</a></li>"
                            End If
                            menu += args
                    End Select
                End If
            End If
        Next
        Return menu
    End Function

    Public Function getH1() As String
        Dim path As String = HttpContext.Current.Request.Url.AbsolutePath
        Dim h1 As String = ""
        If path.Contains("/Account/") Then
            path = path.Replace("/Account/", "")
        Else
            path = path.Replace("/", "")
        End If
        If path.Contains("_") Then
            path = path.Replace("_", " ")
        End If
        path = path.Replace(".aspx", "")
        h1 = "<h1 class='contentH1'>" & path.ToUpper() & "</h1>"
        Return h1
    End Function

    Public Function getContent() As String
        Dim path As String = HttpContext.Current.Request.Url.AbsolutePath
        Dim pageContentText As String = ""
        path = path.Replace("/", "")
        path = path.Replace(".aspx", "")

        Dim conn = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:/School/Vakken/Stage/Websites/Tajem/Visual Studio/database/tajem.mdb")
        Dim sql As String = "SELECT contentText FROM ContentText WHERE pageName='" & path & "'"
        Dim cmd As OleDbCommand = New OleDbCommand(sql, conn)
        conn.Open()
        Dim reader As OleDbDataReader = cmd.ExecuteReader
        While (reader.Read())
            pageContentText = reader("contentText").ToString()
        End While
        conn.Close()
        Return pageContentText
    End Function
End Class
