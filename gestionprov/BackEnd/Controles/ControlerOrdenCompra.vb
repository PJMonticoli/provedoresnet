Imports Modelos
Imports Newtonsoft.Json
Imports System.Reflection
Imports System.Web.Mvc

Public Class ControlerOrdenCompra
    Inherits Controller

    Private ReadOnly _consumanService As New ConsumanService()

    Function ObtenerOrdenesCompra(idProveedor As Integer, token As String) As ActionResult
        Dim json As String = _consumanService.ObtenerPendientesConsuman(idProveedor, token)

        ' Deserializar el JSON en una lista de objetos OrdenDeCompra
        Dim ordenesCompra As List(Of ModeloOrdenDeCompra) = JsonConvert.DeserializeObject(Of List(Of ModeloOrdenDeCompra))(json)

        ' Puedes hacer cualquier manipulación adicional con los datos de ordenesCompra si es necesario

        ' Pasar los datos a la vista
        Return View(ordenesCompra)
    End Function
End Class
