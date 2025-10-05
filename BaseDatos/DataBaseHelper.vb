Imports System.Data.SqlClient

Public Class DataBaseHelper

    Private ReadOnly connectionString As String = ConfigurationManager.ConnectionStrings("ll-46ConnectionString").ConnectionString
    Public Function create(Persona As Persona) As String
        Try
            Dim sql As String = "INSERT INTO Personas (Nombre,Apellido,Edad) VALUES (@Nombre,@Apellido,@Edad)"
            Dim parametros As New List(Of SqlParameter) From {
                New SqlParameter("@Nombre", Persona.Nombre),
                New SqlParameter("@Apellido", Persona.Apellido),
                New SqlParameter("@Edad", Persona.edad)
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

End Class
