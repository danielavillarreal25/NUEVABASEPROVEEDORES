Imports System.Data.SqlClient

Module ConexionBD
    Public Function ObtenerConexion() As SqlConnection
        ' Cadena de conexión a la base de datos
        Dim cadenaConexion As String = "Data Source=DESKTOP-NS0DOBO\SQLEXPRESS;Initial Catalog=NUEVABASEPROVEEDORES;Integrated Security=True"

        ' Crear la conexión
        Dim conexion As New SqlConnection(cadenaConexion)

        Return conexion
    End Function

End Module
