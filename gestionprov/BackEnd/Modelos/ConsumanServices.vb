Imports System.Net.Http
Imports Newtonsoft.Json.Linq
Imports System.Net.Http.Headers
Imports Newtonsoft.Json
Imports Microsoft.IdentityModel.Tokens
Imports System.IdentityModel.Tokens.Jwt
Imports System.Text
Imports System.IO
Imports System.Net

Public Class ConsumanService
    Private ReadOnly baseUrl As String = "http://192.168.1.22:81/api/guma/get-vouchers/"


    Public Function ObtenerPendientesConsuman(idProveedor As Integer, token As String) As String
        Dim fechaDesde As Date = New Date(2018, 4, 1)
        Dim fechaHasta As Date = Date.Now
        fechaHasta = fechaHasta.AddDays(1)
        Dim url As String = $"{baseUrl}{fechaDesde:yyyyMMdd}/{fechaHasta:yyyyMMdd}/{idProveedor}/null/0"

        Dim request As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
        request.Method = "GET"
        request.Headers.Add("Authorization", token)
        request.ContentType = "application/json"

        Try
            Using response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
                If response.StatusCode = HttpStatusCode.OK Then
                    Using reader As New StreamReader(response.GetResponseStream())
                        Dim json As String = reader.ReadToEnd()
                        Return json
                    End Using
                Else
                    ' Manejar el error HTTP aquí según tu lógica
                    Return Nothing
                End If
            End Using
        Catch ex As WebException
            ' Manejar otras excepciones
            Return Nothing
        End Try
    End Function

    Public Function ConvertirJsonADatatable(json As String) As DataSet


        Dim ds As New DataSet()

        ' Crear tabla para las órdenes de compra
        Dim ordenesTable As New DataTable("OrdenesDeCompra")
        ordenesTable.Columns.Add("PrimaryKey", GetType(Integer)) ' Columna Primary Key
        ordenesTable.Columns.Add("Id", GetType(Integer))
        ordenesTable.Columns.Add("Number", GetType(Integer))
        ordenesTable.Columns.Add("VoucherTypeId", GetType(Integer))
        ordenesTable.Columns.Add("VoucherType", GetType(String))
        ordenesTable.Columns.Add("ResponsibleId", GetType(Integer))
        ordenesTable.Columns.Add("Responsible", GetType(String))
        ordenesTable.Columns.Add("ClientId", GetType(Integer))
        ordenesTable.Columns.Add("Client", GetType(Object))
        ordenesTable.Columns.Add("SupplierId", GetType(Integer))
        ordenesTable.Columns.Add("Supplier", GetType(String))
        ordenesTable.Columns.Add("SupplierKey", GetType(String))
        ordenesTable.Columns.Add("CreatedDate", GetType(Date))
        ordenesTable.Columns.Add("DateRequired", GetType(Date))

        ' Crear tabla para los detalles de las órdenes de compra
        Dim detallesTable As New DataTable("DetallesOrdenCompra")
        detallesTable.Columns.Add("PrimaryKey", GetType(Integer)) ' Columna Foreign Key
        detallesTable.Columns.Add("Id", GetType(Integer))
        detallesTable.Columns.Add("SupplyId", GetType(Integer))
        detallesTable.Columns.Add("Supply", GetType(String))
        detallesTable.Columns.Add("SupplyKey", GetType(String))
        detallesTable.Columns.Add("Quantity", GetType(Double))
        detallesTable.Columns.Add("Cost", GetType(Double))
        detallesTable.Columns.Add("KindId", GetType(Integer))

        ' Agregar las tablas al DataSet
        ds.Tables.Add(ordenesTable)
        ds.Tables.Add(detallesTable)

        If Not String.IsNullOrEmpty(json) Then
            Try
                Dim apiResponse As ApiResponse = JsonConvert.DeserializeObject(Of ApiResponse)(json)

                If apiResponse.Result = "success" AndAlso apiResponse.Data IsNot Nothing Then
                    For Each orden As ModeloOrdenDeCompra In apiResponse.Data
                        ' Crear una nueva fila para la tabla de órdenes de compra
                        Dim ordenRow As DataRow = ordenesTable.NewRow()
                        ordenRow("PrimaryKey") = orden.Id
                        ordenRow("Id") = orden.Id
                        ordenRow("Number") = orden.Number
                        ordenRow("VoucherTypeId") = orden.VoucherTypeId
                        ordenRow("VoucherType") = orden.VoucherType
                        ordenRow("ResponsibleId") = orden.ResponsibleId
                        ordenRow("Responsible") = orden.Responsible

                        ' Reemplazar ClientId con DBNull.Value si es Nothing
                        If orden.ClientId.HasValue Then
                            ordenRow("ClientId") = orden.ClientId
                        Else
                            ordenRow("ClientId") = DBNull.Value
                        End If

                        ' ... (resto de las asignaciones)

                        ' Agregar la fila a la tabla de órdenes de compra
                        ordenesTable.Rows.Add(ordenRow)

                        ' Verificar si la orden tiene detalles
                        If orden.Details IsNot Nothing AndAlso orden.Details.Count > 0 Then
                            For Each detalle As ModeloDetalleOrdenCompra In orden.Details
                                ' Crear una nueva fila para la tabla de detalles de órdenes de compra
                                Dim detalleRow As DataRow = detallesTable.NewRow()
                                detalleRow("PrimaryKey") = orden.Id
                                detalleRow("Id") = detalle.Id
                                detalleRow("SupplyId") = detalle.SupplyId
                                detalleRow("Supply") = detalle.Supply
                                detalleRow("SupplyKey") = detalle.SupplyKey
                                detalleRow("Quantity") = detalle.Quantity
                                detalleRow("Cost") = detalle.Cost
                                detalleRow("KindId") = detalle.KindId
                                ' Agregar la fila de detalles a la tabla de detalles de esta orden
                                detallesTable.Rows.Add(detalleRow)
                            Next
                        End If
                    Next
                Else
                    ' Manejar otros casos de respuesta aquí según tus necesidades
                    MsgBox("No se pudo obtener la lista de órdenes de compra.")
                End If
            Catch ex As Exception
                ' Manejar errores de deserialización u otras excepciones aquí
                MsgBox("Error al procesar la respuesta: " & ex.Message)
            End Try
        Else
            ' La sesión ha expirado, manejarlo de acuerdo a tus requerimientos
            MsgBox("La sesión ha expirado. Por favor, inicia sesión nuevamente.")
            ' Puedes redirigir a una página de inicio de sesión o cerrar la aplicación, según tus necesidades.
        End If
        Dim primaryKeyColumn As DataColumn = ordenesTable.Columns("PrimaryKey")
        Dim foreignKeyColumn As DataColumn = detallesTable.Columns("PrimaryKey")
        ' Establecer la relación entre las tablas usando la columna "Number" como clave principal/foránea
        ' Verificar si la columna "Number" existe en la tabla de órdenes de compra
        If ordenesTable.Columns.Contains("PrimaryKey") AndAlso detallesTable.Columns.Contains("PrimaryKey") Then
            ' Establecer la relación entre las tablas usando la columna "Number" como clave principal/foránea
            ds.Relations.Add("OrdenDetalleRelation", ordenesTable.Columns("PrimaryKey"), detallesTable.Columns("PrimaryKey"))
        Else
            ' Manejar el caso donde las columnas "Number" no existen en las tablas
            MsgBox("Las columnas 'Number' no existen en las tablas.")
        End If

        Return ds

    End Function

    Public Async Function PeticionPUTAsync(idDetalle As Integer, token As String) As Task(Of String)
        Dim url As String = $"http://192.168.1.22:81/api/guma/mark-sent/{idDetalle}"
        Dim rutaGuardado As String = "\\server1\f\dce\pruebajson\resultado.txt"
        ' Crear la solicitud HTTP
        Dim request As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
        request.Method = "PUT"
        request.Headers.Add("Authorization", token)
        request.ContentType = "application/json"

        Try

            ' Preparar el contenido JSON que estás enviando (ajusta esto según tu lógica)
            Dim contenidoJson As String = "{ ""key"": ""value"" }"

            ' Convertir el contenido a bytes y establecer la longitud en el encabezado
            Dim contenidoBytes As Byte() = Encoding.UTF8.GetBytes(contenidoJson)
            request.ContentLength = contenidoBytes.Length

            ' Escribir el contenido en la solicitud
            Using stream = request.GetRequestStream()
                stream.Write(contenidoBytes, 0, contenidoBytes.Length)
            End Using


            ' Realizar la solicitud PUT de manera asincrónica
            Using response As HttpWebResponse = CType(Await request.GetResponseAsync(), HttpWebResponse)
                ' Obtener la respuesta de la solicitud
                If response.StatusCode = HttpStatusCode.OK Then
                    ' Manejar la respuesta si es necesario
                    Using reader As New StreamReader(response.GetResponseStream())
                        Dim jsonResponse As String = reader.ReadToEnd()

                        ' Guardar el resultado en un archivo
                        File.WriteAllText(rutaGuardado, jsonResponse)

                        'Console.WriteLine("Solicitud PUT exitosa. Resultado guardado en " & rutaGuardado)
                        Return jsonResponse
                    End Using
                Else
                    ' Manejar el error HTTP aquí según tu lógica
                    Dim errorMessage As String = $"Error HTTP: {response.StatusCode}"

                    ' Guardar el mensaje de error en un archivo
                    File.WriteAllText(rutaGuardado, errorMessage)

                    'Console.WriteLine(errorMessage & ". Mensaje de error guardado en " & rutaGuardado)
                    Return errorMessage
                End If
            End Using
        Catch ex As WebException
            '' Manejar otras excepciones
            'Console.WriteLine($"Error en la solicitud PUT: {ex.Message}")
            'Return $"Error en la solicitud PUT: {ex.Message}"
            ' Manejar otras excepciones
            Dim errorMessage As String = $"Error en la solicitud PUT: {ex.Message}"

            ' Guardar el mensaje de error en un archivo
            File.WriteAllText(rutaGuardado, errorMessage)

            'Console.WriteLine(errorMessage & ". Mensaje de error guardado en " & rutaGuardado)
            Return errorMessage
        End Try
    End Function

End Class


