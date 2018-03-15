Imports System.Data.SqlClient

Public Class InsertarTarea
    Inherits System.Web.UI.Page

    Dim conexion As SqlConnection = New SqlConnection(
        "Server=tcp: hads15iu.database.windows.net,1433;Initial Catalog=HADS-15-Tareas;Persist Security Info=False;
                                                       User ID = opalomo001@hads15iu;Password=Freetanga69;MultipleActiveResultSets=False;Encrypt=True;
                                                        TrustServerCertificate=False;Connection Timeout=30;")

    Dim dapTareasProfesor As New SqlDataAdapter()
    Dim dtsTareasProfesor As New DataSet
    Dim tblTareasProfesor As New DataTable
    Dim rowTareasProfesor As DataRow

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try

            tblTareasProfesor = dtsTareasProfesor.Tables("TareasProfesor")

            rowTareasProfesor = tblTareasProfesor.NewRow()

            '-------------------------------------------------

            rowTareasProfesor("Codigo") = TextBox3.Text

            rowTareasProfesor("Descripcion") = TextBox4.Text

            rowTareasProfesor("CodAsig") = DropDownList3.SelectedValue

            rowTareasProfesor("HEstimadas") = TextBox1.Text

            rowTareasProfesor("Explotacion") = False '<!--Preguntar valor por defecto-->

            rowTareasProfesor("TipoTarea") = DropDownList4.SelectedValue

            '-------------------------------------------------

            tblTareasProfesor.Rows.Add(rowTareasProfesor)

            dapTareasProfesor = Session("AdapterTareasProfesor")

            dapTareasProfesor.Update(dtsTareasProfesor, "TareasProfesor")

            dtsTareasProfesor.AcceptChanges()

        Catch

            LblError.Text = "Error al intentar meterla a la base de datos"

        End Try

    End Sub


End Class