
Imports AccesoDatosSQL.accesodatosSQL

Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub submit_Click(sender As Object, e As EventArgs) Handles submit.Click

        'Comprobar si las validaciones (concretamente CustomValidator) son correctas
        If (Page.IsValid) Then
            Dim logResult As Integer

            logResult = comprobarUsuario(txtMail.Text, txtPass.Text)

            If logResult = -1 Then
                lblAns.Text = "Ese email no se encuentra registrado"
            ElseIf logResult = 0 Then
                lblAns.Text = "Contraseña errónea"
            Else
                Session("userEmail") = txtMail.Text
                'Redirigir a aplicación principal
            End If
        End If

    End Sub

End Class