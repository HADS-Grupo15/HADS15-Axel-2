Public Class Profesor2
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Label1.Text = Session("UserID")

    End Sub

    Protected Sub ImageButton2_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton2.Click

        Session.Abandon()

        Response.Redirect("../Inicio.aspx")

    End Sub

End Class