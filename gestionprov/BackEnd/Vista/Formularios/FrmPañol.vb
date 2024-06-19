Imports Modelos
Imports Newtonsoft
Imports Newtonsoft.Json
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Text
Imports System
Imports TheArtOfDevHtmlRenderer.Adapters
Imports System.IO
Imports Controles
Imports System.Net
Imports System.Runtime.InteropServices

Public Class FrmPañol
    Private Declare Function GetWindowText Lib "user32.dll" Alias "GetWindowTextA" (ByVal hwnd As Int32, ByVal lpString As String, ByVal cch As Int32) As Int32
    Dim model As New ConsumanService
    Public id As String
    Dim WithEvents temporizador As New Timer()
    Dim token As String
    Dim ordenesCompra As List(Of ModeloOrdenDeCompra)
    Dim ds As DataSet
    Private originalItems As New List(Of String)
    Dim codinsumo As String = ""
    Dim codCentroCosto As String = ""
    Public TipoMovimiento As String
    Dim controlInsumo As New ControlerInsumo
    Dim frmprinc As New FrmPrincipal
    Public Sub New(frmprincipal As FrmPrincipal)
        InitializeComponent()
        'TuMetodoAsincronico()
        frmprinc = frmprincipal
    End Sub

    Public Async Sub TuMetodoAsincronico()
        Dim username As String = "sistemas"
        Dim password As String = "sisjg2018"
        Dim ipAddress As String = "http://192.168.1.22:81"

        ' Llama a GenerateToken utilizando Await para esperar el resultado
        token = Await TokenService.GenerateToken(username, password, ipAddress)


    End Sub

    Private Async Sub UsarTokenParaSolicitudesProtegidas(token As String)
        ' URL de la API protegida
        Dim apiUrl As String = "http://192.168.1.22:81/api/guma/get-vouchers/20180401/20230714/1548/null/0?"

        ' Configurar la solicitud HTTP con el token de autorización
        Using client As New HttpClient()
            client.DefaultRequestHeaders.Authorization = New AuthenticationHeaderValue("Bearer", token)

            ' Realizar la solicitud GET protegida
            Try
                Dim response As HttpResponseMessage
                response = Await client.GetAsync(apiUrl)
                MsgBox(response)
                ' Verificar si la solicitud fue exitosa
                If response.IsSuccessStatusCode Then
                    ' Leer la respuesta como texto
                    Dim responseData As String = Await response.Content.ReadAsStringAsync()
                Else
                    ' Manejar errores de la solicitud protegida
                    MessageBox.Show("Error en la solicitud protegida. Código de estado: " & response.StatusCode.ToString())
                End If
            Catch ex As Exception
                ' Manejar otras excepciones que puedan ocurrir durante la solicitud
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End Using
    End Sub




    Private Async Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Obtener el token de forma asíncrona
        token = Await TokenService.GenerateToken("sistemas", "sisjg2018", "http://192.168.1.22:81/token")

        ' Validar que se obtuvo el token correctamente
        If String.IsNullOrEmpty(token) Then
            MsgBox("Error al obtener el token.")
            End
        End If

        ' Obtener datos de la API protegida de forma síncrona

        Dim peticion As String

        ' Verificar si se proporcionan al menos dos parámetros
        If Environment.GetCommandLineArgs.Length > 1 Then
            If Command().Length >= 2 Then
                ' Obtener el primer y segundo parámetro
                id = Environment.GetCommandLineArgs(1)
                peticion = Environment.GetCommandLineArgs(2)

                ' Realizar la validación para decidir si se debe realizar una solicitud GET o PUT
                If peticion = "GET" Then
                    ' Llamar al método para la solicitud GET
                    TipoMovimiento = "FACTURA"
                    peticionGET(id, peticion)
                Else
                    ' Llamar al método para la solicitud PUT
                    Dim respuesta As String
                    respuesta = Await PeticionPUTAsync(id, token)
                    If respuesta <> "" Then
                        End
                    End If
                End If
            End If
        Else
            ' Establecer valores predeterminados si no se proporcionan suficientes parámetros
            'id = "1660"
            peticion = "GET"
            If peticion = "GET" Then
                ' Llamar al método para la solicitud GET
                peticionGET(id, peticion)
            Else
            End If
        End If

    End Sub

    Private Sub peticionGET(idProveedor As Integer, peticion As String)
        Dim idsubrubro As Integer
        Dim json As String = model.ObtenerPendientesConsuman(Convert.ToInt32(idProveedor), token)
        ds = ConvertirJsonADatatable(json)
        If Not String.IsNullOrEmpty(json) Then
            Try
                Dim apiResponse As ApiResponse = JsonConvert.DeserializeObject(Of ApiResponse)(json)

                If apiResponse.Result = "success" AndAlso apiResponse.Data IsNot Nothing Then
                    ordenesCompra = apiResponse.Data

                    ' Crear una lista para almacenar los elementos del ChkListado
                    Dim items As New List(Of ItemLista)()

                    ' Procesar las órdenes de compra aquí
                    For Each orden As ModeloOrdenDeCompra In ordenesCompra
                        If TipoMovimiento = "FACTURA" Then
                            If orden.VoucherTypeId = "2468" Then
                                ' Obtener el número de la orden de compra
                                Dim number As Int32 = CInt(orden.Number)
                                Dim tipocomp As String = orden.VoucherType

                                ' Iterar sobre cada detalle de la orden de compra
                                For Each detalle As ModeloDetalleOrdenCompra In orden.Details
                                    ' Obtener los datos del detalle de la orden de compra
                                    Dim detalleId As Integer = detalle.Id
                                    Dim supplyId As Integer = detalle.SupplyId
                                    Dim supply As String = detalle.Supply
                                    Dim supplyKey As String = detalle.SupplyKey
                                    Dim quantity As Double = detalle.Quantity
                                    Dim cost As Double = detalle.Cost
                                    idsubrubro = detalle.SubKindId
                                    controlInsumo.ObtenerCodInsumoBySubRubro(detalle.SubKindId, codinsumo, codCentroCosto)

                                    ' Crear un objeto ItemLista y agregarlo a la lista de items
                                    Dim listItem As New ItemLista()
                                    listItem.Text = $"Tipo Comprobante: {orden.VoucherType}; Número: {orden.Number}; ID: {codinsumo}; Producto: {supply}; Cantidad: {quantity}; Costo: {cost}; Centro Costo: {codCentroCosto}"
                                    listItem.Value = orden.Number
                                    items.Add(listItem)
                                Next
                            End If
                        Else
                            ' Obtener el número de la orden de compra
                            Dim number As Int32 = CInt(orden.Number)
                            Dim tipocomp As String = orden.VoucherType
                            If orden.VoucherTypeId = "1259" Then
                                ' Iterar sobre cada detalle de la orden de compra
                                For Each detalle As ModeloDetalleOrdenCompra In orden.Details
                                    ' Obtener los datos del detalle de la orden de compra
                                    Dim detalleId As Integer = detalle.Id
                                    Dim supplyId As Integer = detalle.SupplyId
                                    Dim supply As String = detalle.Supply
                                    Dim supplyKey As String = detalle.SupplyKey
                                    Dim quantity As Double = detalle.Quantity
                                    Dim cost As Double = detalle.Cost
                                    idsubrubro = detalle.SubKindId
                                    controlInsumo.ObtenerCodInsumoBySubRubro(detalle.SubKindId, codinsumo, codCentroCosto)

                                    ' Crear un objeto ItemLista y agregarlo a la lista de items
                                    Dim listItem As New ItemLista()
                                    listItem.Text = $"Tipo Comprobante: {orden.VoucherType}; Número: {orden.Number}; ID: {codinsumo}; Producto: {supply}; Cantidad: {quantity}; Costo: {cost}; Centro Costo: {codCentroCosto}"
                                    listItem.Value = orden.Number
                                    items.Add(listItem)
                                Next
                            End If
                        End If
                    Next

                    ' Asignar la lista de items al ChkListado
                    ChkListado.DataSource = items
                    ChkListado.DisplayMember = "Text" ' Establecer el DisplayMember como "Text"
                    ChkListado.ValueMember = "Value" ' Establecer el ValueMember como "Value"


                    ' Iterar a través de los elementos del CheckListBox y marcarlos como checked
                    'For i As Integer = 0 To ChkListado.Items.Count - 1
                    '    ChkListado.SetItemChecked(i, True)
                    'Next
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
    End Sub


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
            Dim errorMessage As String = $"Error en la solicitud PUT: {ex.Message}"

            ' Guardar el mensaje de error en un archivo
            File.WriteAllText(rutaGuardado, errorMessage)

            'Console.WriteLine(errorMessage & ". Mensaje de error guardado en " & rutaGuardado)
            Return errorMessage
        End Try
    End Function




    Private Sub BtnCerrar_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Me.Close()
    End Sub

    Private Async Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If ChkListado.CheckedItems.Count = 0 Then
            MsgBox("Debe seleccionar al menos un item de la grilla", vbExclamation, "Advertencia")
            ChkListado.Focus()
            Exit Sub
        End If
        Dim numerosSeleccionados As New HashSet(Of Integer)()

        ' Recorrer los elementos del CheckBoxList y agregar los números de las órdenes seleccionadas al HashSet
        For Each item As Object In ChkListado.CheckedItems
            ' Obtener el número de la OrdenDeCompra del Value del CheckBoxList
            Dim orderId As Integer = item.Value

            ' Agregar el número de la orden al HashSet
            numerosSeleccionados.Add(orderId)
        Next

        ' Crear una lista para almacenar los elementos seleccionados del chkListado
        'Dim elementosSeleccionados As New List(Of ModeloOrdendeCompraSeleccion)()

        '' Recorrer los números de las órdenes seleccionadas y agregar los detalles correspondientes a la lista
        For Each numeroOrden As Integer In numerosSeleccionados
            ' Obtener la OrdenDeCompra correspondiente a partir del número
            Dim ordenSeleccionada As ModeloOrdenDeCompra = ordenesCompra.FirstOrDefault(Function(orden) orden.Number = numeroOrden)

            ' Verificar si se encontró la OrdenDeCompra correspondiente
            If ordenSeleccionada IsNot Nothing Then
                ' Recorrer los detalles de la OrdenDeCompra y agregarlos a la lista elementosSeleccionados
                For Each detalle As ModeloDetalleOrdenCompra In ordenSeleccionada.Details
                    controlInsumo.ObtenerCodInsumoBySubRubro(detalle.SubKindId, codinsumo, codCentroCosto)
                    Dim ordenDetalle As New ModeloOrdendeCompraSeleccion(
                    Convert.ToInt32(ordenSeleccionada.Number), ' PrimaryKey de detallesTable
                    Convert.ToInt32(detalle.Id),
                    Convert.ToInt32(ordenSeleccionada.Number),
                    detalle.SupplyId,
                    detalle.Supply,
                    Convert.ToDouble(detalle.Quantity),
                    Convert.ToDouble(detalle.Cost),
                    Convert.ToDouble(detalle.Cost) * Convert.ToDouble(detalle.Quantity),
                    Convert.ToInt32(detalle.KindId),
                    controlInsumo.BuscarCentroCostoXInsumo(codinsumo),
                    codinsumo
                )
                    ' Asignar el valor de CostCenter después de crear la instancia
                    frmprinc.elementosSeleccionados.Add(ordenDetalle)
                Next
            End If
        Next

        Me.Close()
    End Sub
    Private Sub Temporizador_Tick(sender As Object, e As EventArgs) Handles temporizador.Tick
        TuMetodoAsincronico()

    End Sub

    Private Sub btnCerrar2_Click(sender As Object, e As EventArgs) Handles btnCerrar2.Click
        Me.Close()
    End Sub

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

    Private Sub btnQuitar_Click(sender As Object, e As EventArgs) Handles btnQuitar.Click
        ' Deseleccionar todos los elementos en el CheckBoxList
        For i As Integer = 0 To ChkListado.Items.Count - 1
            ChkListado.SetItemChecked(i, False)
        Next
    End Sub

    Private Sub btnSeleccionarTodas_Click(sender As Object, e As EventArgs) Handles btnSeleccionarTodas.Click
        ' Seleccionar todas las opciones en el CheckBoxList
        For i As Integer = 0 To ChkListado.Items.Count - 1
            ChkListado.SetItemChecked(i, True)
        Next
    End Sub

    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub
    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
    End Sub
    Private Sub PanelTitleBar_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseDown, Guna2Panel1.MouseDown
        ReleaseCapture()
        SendMessage(Me.Handle, &H112, &HF012, 0)
    End Sub

End Class


Module TimeSpanExtensions
    <System.Runtime.CompilerServices.Extension()>
    Public Function Add20Seconds(originalTimeSpan As TimeSpan) As TimeSpan
        Return originalTimeSpan.Add(New TimeSpan(0, 0, 20))
    End Function
End Module