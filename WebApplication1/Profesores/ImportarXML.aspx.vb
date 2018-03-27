Imports System.Data.SqlClient
Imports System.Xml

Public Class ImportarXML
    Inherits System.Web.UI.Page

    Dim conexion As SqlConnection = New SqlConnection(
        "Server=tcp: hads15iu.database.windows.net,1433;Initial Catalog=HADS-15-Tareas;Persist Security Info=False;
                                                       User ID = opalomo001@hads15iu;Password=Freetanga69;MultipleActiveResultSets=False;Encrypt=True;
                                                        TrustServerCertificate=False;Connection Timeout=30;")

    Dim adapTareas As New SqlDataAdapter()

    Dim dtsTareas As New DataSet

    Dim dtblTareas As New DataTable

    Dim rowTareas As DataRow

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Session("UserID") = "blanco@ehu.es"

    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged

        Dim found As Boolean

        found = System.IO.File.Exists(Server.MapPath("../App_Data/" & DropDownList1.SelectedValue & ".xml")) 'HAS.xml // SEG.xml

        If found Then

            divSort.Visible = True

            xml.DocumentSource = Server.MapPath("../App_Data/" & DropDownList1.SelectedValue & ".xml")

            xml.TransformSource = Server.MapPath("../App_Data/XSLTFile.xsl")

        Else

            divSort.Visible = False

            Page.ClientScript.RegisterStartupScript(Me.GetType(), "PopupScript", "alert('¡Revisa el fichero de Origen!')", True)

        End If

    End Sub

    Protected Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click

        Response.Redirect("./Profesor.aspx")

    End Sub

    Protected Sub ImageButton2_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton2.Click

        Session.Abandon()

        Response.Redirect("../Inicio.aspx")

    End Sub


    '--------OPCIONAL-------------'

    Protected Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnImportar.Click

        adapTareas = New SqlDataAdapter("SELECT * FROM TareasGenericas WHERE TareasGenericas.CodAsig='" & DropDownList1.SelectedValue & "'", conexion)

        Dim bldTareas As New SqlCommandBuilder(adapTareas)

        dtsTareas.Clear() 'vaciar por si hay algo previo

        '----------------------------------------------------------------------------------




        '----------------------------------------------------------------------------------

        GridView1.DataSource = dtsTareas.Tables("Tareas")

        GridView1.DataBind()

    End Sub

    Protected Sub btnSortCod_Click(sender As Object, e As EventArgs) Handles btnSortCod.Click

        xml.DocumentSource = Server.MapPath("../App_Data/" & DropDownList1.SelectedValue & ".xml")

        xml.TransformSource = Server.MapPath("../App_Data/XSLTCodigo.xslt")

    End Sub

    Protected Sub btnSortDesc_Click(sender As Object, e As EventArgs) Handles btnSortDesc.Click

        xml.DocumentSource = Server.MapPath("../App_Data/" & DropDownList1.SelectedValue & ".xml")

        xml.TransformSource = Server.MapPath("../App_Data/XSLTDescripcion.xslt")

    End Sub

    Protected Sub btnSortHE_Click(sender As Object, e As EventArgs) Handles btnSortHE.Click

        xml.DocumentSource = Server.MapPath("../App_Data/" & DropDownList1.SelectedValue & ".xml")

        xml.TransformSource = Server.MapPath("../App_Data/XSLTHEstimadas.xslt")

    End Sub

End Class