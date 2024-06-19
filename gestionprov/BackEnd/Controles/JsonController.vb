Imports Newtonsoft.Json
Imports System.Web.Mvc
Imports Modelos
Public Class JsonController


    Inherits Controller

    <HttpGet>
    Function GetOrdenesCompra() As ActionResult
        Dim url As String = "http://192.168.1.22:8080/Comprobantes/GetOrdenesCompra/20180401/20230714/1605/null/0"

        ' Realizar la solicitud HTTP para obtener el JSON
        Dim client As New System.Net.WebClient()
        Dim json As String = client.DownloadString(url)

        ' Deserializar el JSON en una lista de objetos OrdenCompra
        Dim ordenesCompra As List(Of ModeloOrdenDeCompra) = JsonConvert.DeserializeObject(Of List(Of ModeloOrdenDeCompra))(json)

        ' Hacer algo con las ordenes de compra, por ejemplo, pasarlas a una vista
        Return View(ordenesCompra)
    End Function
End Class


