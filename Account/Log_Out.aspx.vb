
Partial Class Account_Log_Out
    Inherits System.Web.UI.Page
    Public custom As New custom()
    Protected Sub logout_Click(sender As Object, e As EventArgs)
        Session("login") = False
        msg.Text = "<div class='alert alert-success'>You have successfully logged out!</div>"
    End Sub
End Class
