Imports System.Data.SqlClient

Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Cargar todos los proveedores al DataGridView
        CargarProveedores()
    End Sub

    Private Sub CargarProveedores()
        Dim conexion As SqlConnection = ConexionBD.ObtenerConexion()
        Dim tablaProveedores As New DataTable()

        Try
            conexion.Open()

            ' Consulta SQL para obtener todos los proveedores
            Dim consulta As String = "SELECT * FROM Proveedores"

            ' Crear el comando SQL
            Dim comando As New SqlCommand(consulta, conexion)

            ' Ejecutar el comando y llenar la tabla de proveedores
            Dim adaptador As New SqlDataAdapter(comando)
            adaptador.Fill(tablaProveedores)

            ' Asignar la tabla de datos al DataGridView
            dataGridViewProveedores.DataSource = tablaProveedores
        Catch ex As Exception
            MessageBox.Show("Error al cargar los proveedores: " & ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub

    Private Sub txtBuscarProveedor_TextChanged(sender As Object, e As EventArgs) Handles txtBuscarProveedor.TextChanged
        FiltrarProveedores(txtBuscarProveedor.Text)
    End Sub

    Private Sub FiltrarProveedores(ByVal filtro As String)
        Dim vista As DataView = CType(dataGridViewProveedores.DataSource, DataTable).DefaultView
        vista.RowFilter = $"Proveedor LIKE '%{filtro}%'"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.Show()
        Me.Hide()
    End Sub
End Class
