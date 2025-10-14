Public Class FormPersona
    Inherits System.Web.UI.Page
    Public persona As New Persona()
    Protected dbHelper As New DataBaseHelper()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btn_guardar_Click(sender As Object, e As EventArgs)
        Persona.Nombre = txt_nombre.Text
        persona.Apellido = txt_apellido.Text
        persona.Edad = txt_edad.Text
        lbl_mensaje.Text = dbHelper.create(persona)
    End Sub


    Protected Sub GV_personas_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)

        Try
            Dim id As Integer = Convert.ToInt32(GV_personas.DataKeys(e.RowIndex).Value)
            dbHelper.delete(id)
            e.Cancel = "True"
            GV_personas.DataBind()

        Catch ex As Exception
            lbl_mensaje.Text = "Error al eliminar la persona: " & ex.Message
        End Try

    End Sub

End Class