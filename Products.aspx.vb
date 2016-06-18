Imports System.Net.Mail
Partial Class Products
    Inherits System.Web.UI.Page
    Public custom As New custom()

    'products
    Protected Sub products_SelectedIndexChanged(sender As Object, e As EventArgs)
        Dim totalValue As Integer = 0
        testAnswers.Text = ""
        For Each li As ListItem In CheckBoxList2.Items
            If li.Selected Then
                testAnswers.Text += "<li>" & li.Text & "<spam>" & li.Value & "</spam></li>"
                totalValue += li.Value
            End If
        Next
        If testAnswers.Text Is "" Then
            testAnswers.Text += "None"
            buyNowButton.Visible = False
        Else
            buyNowButton.Visible = True
        End If
        total.Text = totalValue
    End Sub

    'buy now button
    Protected Sub BuyNow(sender As Object, e As EventArgs)
        buyProducts.Visible = False
        thankYouMail.Visible = True
    End Sub

    'Email
    Protected Sub SendMailProduct(sender As Object, e As EventArgs) Handles sendMail.Click
        If Not termsAndConditions.Checked Then
            errorMail.Text = "<p>You need to agree with the Terms & Conditions before you can send an email</p>"
        Else
            Try
                Dim orders As String = ""
                For Each li As ListItem In CheckBoxList2.Items
                    If li.Selected Then
                        orders += "<li>" & li.Text & "</li>"
                    End If
                Next
                Dim from As String = Request.Form("sendEmail")
                Dim comment As String = Request.Form("comment")
                Dim updateProducts As String = "No"
                If updateMail.Checked Then
                    updateProducts = "Yes"
                End If
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
                e_mail.Subject = "Order"
                e_mail.IsBodyHtml = True
                e_mail.Body = "<b>Email from:</b> " & from &
                              "<br><b>Comment:</b> " & comment &
                              "<br><b>Keep me updated of the latest products:</b> " & updateProducts &
                              "<br><b>Orders:</b> <ul>" & orders & "</ul>"
                Smtp_Server.Send(e_mail)
                'MsgBox("Mail Sent")

            Catch error_t As Exception
                MsgBox(error_t.ToString)
            End Try
            Response.Redirect("/thankyou")
        End If
    End Sub
End Class
