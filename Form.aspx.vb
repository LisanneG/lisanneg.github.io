
Partial Class Form
    Inherits System.Web.UI.Page
    Public custom As New custom()

    Protected Sub Button1_Click(sender As Object, e As EventArgs)
        Dim result As Integer = 0
        Dim counter As Integer = 0

        answers.Text += "<div class='flex'>"
        For Each li As ListItem In CheckBoxList1.Items
            If Not li.Selected And li.Value = "18" Then
                result = 1
                answers.Text = "If you are not 18 you may not do this form"
            End If
            If li.Selected And result = 0 And li.Value IsNot "18" Then
                If counter = 3 Then
                    answers.Text += "<div class='flex'>"
                End If
                answers.Text += "<div>"
                Select Case li.Value
                    Case "civ"
                        answers.Text += "<h2>Sid Meier's Civilization V</h2><p>Sid Meier's Civilization V is a turn-based strategy game released on September 21, 2010. You can buy this game for &euro;10 on steam.</p>"
                    Case "dishonored"
                        answers.Text += "<h2>Dishonored</h2><p>Dishonored is a first person stealth-action game developed by Arkane Studios. You can buy this game for &euro;10 on steam.</p>"
                    Case "gta"
                        answers.Text += "<h2>Grand Theft Auto V</h2><p>Grand Theft Auto V is an open world action-adventure video game developed by Rockstar North and published by Rockstar Games. You can buy this game for &euro;10 on steam.</p>"
                    Case "zelda"
                        answers.Text += "<h2>The Legend of Zelda: Marjoa's Mask</h2><p>The Legend of Zelda: Majora's Mask is an action-adventure video game developed and published by Nintendo for the Nintendo 64. You can buy this game for &euro;10 on steam.</p>"
                    Case "conker"
                        answers.Text += "<h2>Conker's Bad Fur Day</h2><p>Conker's Bad Fur Day is an action-platform video game developed by Rare and released for the Nintendo 64 video game console in 2001. You can buy this game for &euro;10 on steam.</p>"
                End Select
                answers.Text += "</div>"
                counter += 1
            End If
            If counter = 3 Then
                answers.Text += "</div>"
            End If
        Next
        answers.Text += "</div>"
        CheckBoxList1.Visible = False
        Button1.Visible = False
    End Sub
End Class
