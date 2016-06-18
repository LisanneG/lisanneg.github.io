Imports System.Data
Imports System.Data.OleDb
Partial Class About
    Inherits System.Web.UI.Page
    Public custom As New custom()

    Sub Page_Load()
        Dim dbconn, sql, dbcomm, dbread
        dbconn = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; data source=" & Server.MapPath("/database/tajem.mdb"))
        dbconn.Open()
        sql = "SELECT contentText FROM ContentText WHERE pageName='About'"
        dbcomm = New OleDbCommand(sql, dbconn)
        dbread = dbcomm.ExecuteReader()
        content.DataSource = dbread
        content.DataBind()

        dbread.Close()
        dbconn.Close()
    End Sub
End Class
