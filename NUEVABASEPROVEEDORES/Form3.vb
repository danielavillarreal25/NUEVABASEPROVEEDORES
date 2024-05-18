Imports System.Data.SqlClient

Public Class Form3
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Cargar todas las compras al DataGridView
        CargarCompras()
    End Sub

    Private Sub CargarCompras()
        Dim conexion As SqlConnection = ConexionBD.ObtenerConexion()
        Dim tablaCompras As New DataTable()

        Try
            conexion.Open()

            ' Consulta SQL para obtener todas las compras
            Dim consulta As String = "SELECT * FROM Compras"

            ' Crear el comando SQL
            Dim comando As New SqlCommand(consulta, conexion)

            ' Ejecutar el comando y llenar la tabla de compras
            Dim adaptador As New SqlDataAdapter(comando)
            adaptador.Fill(tablaCompras)

            ' Asignar la tabla de datos al DataGridView_compras
            DataGridView_compras.DataSource = tablaCompras
        Catch ex As Exception
            MessageBox.Show("Error al cargar las compras: " & ex.Message)
        Finally
            conexion.Close()
        End Try
    End Sub

    Private Sub dateTimePickerFecha_ValueChanged(sender As Object, e As EventArgs) Handles dateTimePickerFecha.ValueChanged
        FiltrarComprasPorFecha(dateTimePickerFecha.Value)
    End Sub

    Private Sub FiltrarComprasPorFecha(ByVal fecha As Date)
        Dim vista As DataView = CType(DataGridView_compras.DataSource, DataTable).DefaultView
        vista.RowFilter = $"FechaUltimaCompra >= '{fecha.ToShortDateString()}' AND FechaUltimaCompra < '{fecha.AddDays(1).ToShortDateString()}'"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.Show()
        Me.Hide()

    End Sub
End Class