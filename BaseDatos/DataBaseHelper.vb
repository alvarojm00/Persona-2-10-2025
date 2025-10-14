Imports System.Data.SqlClient

Public Class DataBaseHelper

    Private ReadOnly connectionString As String = ConfigurationManager.ConnectionStrings("ll-46ConnectionString").ConnectionString

    'Crear Persona'
    Public Function create(Persona As Persona) As String
        Try
            Dim sql As String = "INSERT INTO Personas (Nombre,Apellido,Edad) VALUES (@Nombre,@Apellido,@Edad)"
            Dim parametros As New List(Of SqlParameter) From {
                New SqlParameter("@Nombre", Persona.Nombre),
                New SqlParameter("@Apellido", Persona.Apellido),
                New SqlParameter("@Edad", Persona.Edad)
            }

            Using connection As New SqlConnection(connectionString)

                Using command As New SqlCommand(sql, connection)
                    command.Parameters.AddRange(parametros.ToArray())
                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using

        Catch ex As Exception

        End Try
        Return "Persona creada"
    End Function


    'Eliminar persona'
    Public Function delete(ByRef id As Integer) As String
        Try
            Dim sql As String = "DELETE FROM Personas WHERE ID = @id"
            Dim Parametros As New List(Of SqlParameter) From {
                New SqlParameter("@id", id)
            }
            Using connection As New SqlConnection(connectionString)

                Using command As New SqlCommand(sql, connection)
                    command.Parameters.AddRange(Parametros.ToArray())
                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using

        Catch ex As Exception

        End Try

        Return "Persona Eliminada"

    End Function

End Class
