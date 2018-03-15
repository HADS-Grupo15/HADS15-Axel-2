Imports System.Data.SqlClient
Imports AccesoDatosSQL.accesodatosSQL

Public Class TareasAlumno
    Inherits System.Web.UI.Page

    Dim conexion As SqlConnection = New SqlConnection("Server=tcp:hads15iu.database.windows.net,1433;Initial Catalog=HADS-15-Tareas;Persist Security Info=False;
                                                       User ID=opalomo001@hads15iu;Password=Freetanga69;MultipleActiveResultSets=False;Encrypt=True;
                                                        TrustServerCertificate=False;Connection Timeout=30;")

    Dim adapAsg As New SqlDataAdapter()

    Dim dtsAsg As New DataSet

    Dim dtblAsg As New DataTable

    Dim drowAsg As DataRow

    '------------------------------------'

    Dim adapTareas As New SqlDataAdapter()

    Dim dtsTareas As New DataSet

    Dim dtblTareas As New DataTable

    Dim rowTareas As DataRow

    Dim dvTareas As DataView


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Session("UserID") = "pepe@ikasle.ehu.es"

        If Page.IsPostBack Then

            dtsAsg = Session("Asignaturas")

            dtsTareas = Session("Tareas")

        Else

            adapAsg = New SqlDataAdapter("SELECT * FROM Asignaturas INNER JOIN GruposClase ON GruposClase.codigoasig = Asignaturas.codigo 
                                          INNER JOIN EstudiantesGrupo ON EstudiantesGrupo.Grupo = GruposClase.codigo 
                                          WHERE EstudiantesGrupo.Email = '" & Session("UserID") & "'", conexion)

            Dim bldAsignaturas As New SqlCommandBuilder(adapAsg)

            adapAsg.Fill(dtsAsg, "Asignaturas")

            dtblAsg = dtsAsg.Tables("Asignaturas")

            DropDownList1.DataSource = dtblAsg

            DropDownList1.DataValueField = "Codigo"

            DropDownList1.DataTextField = "Codigo"

            DropDownList1.DataBind()

            Session("Asignaturas") = dtsAsg

            Session("AdapterAsignaturas") = adapAsg


            '-------------------------------------------------'


            adapTareas = New SqlDataAdapter("SELECT TareasGenericas.Codigo,TareasGenericas.Descripcion,
                                             TareasGenericas.HEstimadas,TareasGenericas.TipoTarea 
                                             FROM TareasGenericas WHERE TareasGenericas.CodAsig='" & DropDownList1.SelectedItem.Value & "' 
                                             AND TareasGenericas.Explotacion='True' 
                                             AND TareasGenericas.Codigo NOT IN (
                                                SELECT EstudiantesTareas.CodTarea 
                                                FROM EstudiantesTareas INNER JOIN TareasGenericas ON EstudiantesTareas.CodTarea = TareasGenericas.Codigo 
                                                WHERE EstudiantesTareas.Email='" & Session("UserID") & "' AND 
                                                TareasGenericas.CodAsig='" & DropDownList1.SelectedValue & "')", conexion)

            Dim bldTareas As New SqlCommandBuilder(adapTareas)

            adapTareas.Fill(dtsTareas, "Tareas")

            dtblTareas = dtsTareas.Tables("Tareas")

            dvTareas = dtsTareas.Tables(0).DefaultView

            GridViewTareas.DataSource = dvTareas

            GridViewTareas.DataBind()

            Session("Tareas") = dtsTareas

            Session("AdapterTareas") = adapTareas

        End If

    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DropDownList1.SelectedIndexChanged

        dtblTareas.Rows.Clear()

        adapTareas = New SqlDataAdapter("SELECT TareasGenericas.Codigo,TareasGenericas.Descripcion,TareasGenericas.HEstimadas,
                                         TareasGenericas.TipoTarea FROM TareasGenericas 
                                         WHERE TareasGenericas.CodAsig='" & DropDownList1.SelectedValue & "' 
                                         AND TareasGenericas.Explotacion='True' 
                                         AND TareasGenericas.Codigo NOT IN 
                                         (SELECT EstudiantesTareas.CodTarea FROM EstudiantesTareas INNER JOIN TareasGenericas 
                                         ON EstudiantesTareas.CodTarea = TareasGenericas.Codigo 
                                         WHERE EstudiantesTareas.Email='" & Session("UserID") & "' 
                                         AND TareasGenericas.CodAsig='" & DropDownList1.SelectedValue & "')", conexion)

        Dim bldTareas As New SqlCommandBuilder(adapTareas)

        dtsTareas.Clear()

        adapTareas.Fill(dtsTareas, "Tareas")

        dtblTareas = dtsTareas.Tables("Tareas")

        dvTareas = dtsTareas.Tables(0).DefaultView

        GridViewTareas.DataSource = dvTareas

        GridViewTareas.DataBind()

        Session("AdapterTareas") = adapTareas

    End Sub



End Class