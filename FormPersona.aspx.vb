﻿Imports Persona.Models

Public Class FormPersona
    Inherits System.Web.UI.Page
    Public persona As New Persona()
    Protected dbHelper As New DataBaseHelper()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btn_guardar_Click(sender As Object, e As EventArgs)
        persona.Nombre = txt_nombre.Text
        persona.Apellido = txt_apellido.Text
        persona.Edad = txt_edad.Text
        lbl_mensaje.Text = dbHelper.create(persona)
        GV_personas.DataBind()


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

    Protected Sub GV_personas_RowCancelingEdit(sender As Object, e As GridViewCancelEditEventArgs)

        GV_personas.EditIndex = -1
        GV_personas.DataBind()

    End Sub

    Protected Sub GV_personas_RowUpdating(sender As Object, e As GridViewUpdateEventArgs)

        Dim id As Integer = Convert.ToInt32(GV_personas.DataKeys(e.RowIndex).Value)
        Dim persona As Persona = New Persona With {
            .Nombre = e.NewValues("Nombre"),
            .Apellido = e.NewValues("Apellido"),
            .Edad = e.NewValues("Edad"),
            .Id = id
        }

        dbHelper.update(persona)
        GV_personas.DataBind()
        e.Cancel = True
        GV_personas.EditIndex = -1

    End Sub

    Protected Sub GV_personas_RowEditing(sender As Object, e As GridViewEditEventArgs)

    End Sub

    Protected Sub GV_personas_SelectedIndexChanged(sender As Object, e As EventArgs)

        Dim row As GridViewRow = GV_personas.SelectedRow()
        Dim id As Integer = Convert.ToInt32(row.Cells(2).Text)
        Dim persona As Persona = New Persona()

        txt_nombre.Text = row.Cells(3).Text
        txt_apellido.Text = row.Cells(4).Text
        txt_edad.Text = row.Cells(5).Text

        editando.Value = id

    End Sub

    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs)


        Dim persona As Persona = New Persona With {
            .Nombre = txt_nombre.Text,
            .Apellido = txt_apellido.Text,
            .Edad = txt_edad.Text,
            .Id = editando.Value()
        }
        dbHelper.update(persona)
        GV_personas.DataBind()
        GV_personas.EditIndex = -1



    End Sub
End Class