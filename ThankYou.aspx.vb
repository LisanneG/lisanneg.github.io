Imports System.Net.Mail
Partial Class ThankYou
    Inherits System.Web.UI.Page
    Public custom As New custom()

    Public Sub ButtonMail_Click(sender As Object, e As EventArgs) Handles ButtonMail.Click
        Try
            Dim Smtp_Server As New SmtpClient
            Dim e_mail As New MailMessage()
            Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New Net.NetworkCredential("conkerlisanne@gmail.com", "Lg221195")
            Smtp_Server.Port = 587
            Smtp_Server.EnableSsl = True
            Smtp_Server.Host = "smtp.gmail.com"

            e_mail = New MailMessage()
            e_mail.From = New MailAddress("conkerlisanne@gmail.com")
            e_mail.To.Add("lisannegerrits@gmail.com")
            e_mail.Subject = "Order Confirmed"
            e_mail.IsBodyHtml = True
            e_mail.Body = "<h1>Your order has been confirmed</h1><br>thank you for shopping. If this is not you please contact us through <a href='mailto:info@tajam.com'>info@tajam.com</a>"
            Smtp_Server.Send(e_mail)
            MsgBox("Mail Sent")

        Catch error_t As Exception
            MsgBox(error_t.ToString)
        End Try
    End Sub
End Class
