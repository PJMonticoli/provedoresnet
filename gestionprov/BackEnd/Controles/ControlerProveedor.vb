Imports System.Data.SqlClient
Imports System.Reflection
Imports System.Runtime.Remoting.Contexts
Imports System.Web.UI.WebControls
Imports System.Windows.Forms
Imports ClasesGlobal
Imports GrapeCity.Enterprise.Data.DataEngine.DataProcessing
Imports Modelos

Public Class ControlerProveedor
    Inherits ServidorSQl
    Dim OrigenFacturacion As Integer
    Dim model As ConsumanService
    Dim token As String
    Dim ds As DataSet
    Dim controlInsumo As ControlerInsumo
    Public Function buscarProveedor(idproveedor As Integer, ByRef tabla As DataTable) As Integer
        Try
            Dim query = "SELECT NroProveedor, RSocial,Direccion,Localidad,CodCuit as 'Condicion Proveedor'
                    FROM Proveedores.dbo.Proveedor             
                    WHERE nroProveedor = " & idproveedor

            tabla = ServidorSQl.GetTabla(query)
            If tabla Is Nothing Then
                GoTo errores
            ElseIf tabla.Rows.Count = 0 Then
                buscarProveedor = 0
            Else
                buscarProveedor = 1
            End If
            Exit Function

errores:
            buscarProveedor = -1
        Catch ex As Exception
            Throw ex
            buscarProveedor = -1
        End Try
    End Function

    Public Function buscarProveedorCAI(ByRef nroProveedor As Integer, ByRef tipo As Integer, ByRef desc As Integer, ByRef tabla As DataTable) As Integer

        Try
            Dim query = "SELECT ProveedorCAI.id, ProveedorCAI.CAI, ProveedorCAI.FechaVto from ProveedorCAI where ProveedorCai.NroProveedor=" & nroProveedor & " and ProveedorCAI.tipocomp=" & tipo & " and ProveedorCAI.desccomp=" & desc & " order by id desc"

            tabla = ServidorSQl.GetTabla(query)
            If tabla Is Nothing Then
                GoTo errores
            ElseIf tabla.Rows.Count = 0 Then
                buscarProveedorCAI = 0
            Else
                buscarProveedorCAI = 1
            End If
            Exit Function

errores:
            buscarProveedorCAI = -1
        Catch ex As Exception
            Throw ex
            buscarProveedorCAI = -1
        End Try
    End Function

    Public Function buscarProveedorHabilitadosAFIP(idproveedor As Integer, ByRef tabla As DataTable) As Integer
        Try
            Dim query = "SELECT p.NroProveedor, RSocial,Direccion,Localidad,
ConvMulti, CodTipoInsumosProveedor, NroCUIT, pi.observaciones,InhabilitacionImpositiva, CodEstadoProveedor 
                    FROM Proveedores.dbo.Proveedor p LEFT OUTER JOIN  Proveedores.dbo.ProveedoresInhabilitados as pi on pi.nroProveedor = p.NroProveedor
                    WHERE p.nroProveedor = " & idproveedor

            tabla = ServidorSQl.GetTabla(query)
            If tabla Is Nothing Then
                GoTo errores
            ElseIf tabla.Rows.Count = 0 Then
                buscarProveedorHabilitadosAFIP = 0
            Else
                buscarProveedorHabilitadosAFIP = 1
            End If
            Exit Function

errores:
            buscarProveedorHabilitadosAFIP = -1
        Catch ex As Exception
            Throw ex
            buscarProveedorHabilitadosAFIP = -1
        End Try
    End Function

    Public Function buscarProveedorPorNroComprobante(nroComp As String, ByRef tabla As DataTable) As Integer
        Try
            Dim query = "SELECT p.NroProveedor, RSocial,cp.NroComp FROM Proveedores.dbo.Proveedor as p inner join Proveedores.dbo.ComprobantesProveedores cp on cp.NroProveedor = p.NroProveedor WHERE cp.NroComp = " & nroComp
            tabla = ServidorSQl.GetTabla(query)
            If tabla Is Nothing Then
                GoTo errores
            ElseIf tabla.Rows.Count = 0 Then
                buscarProveedorPorNroComprobante = 0
            Else
                buscarProveedorPorNroComprobante = 1
            End If
            Exit Function

errores:
            buscarProveedorPorNroComprobante = -1
        Catch ex As Exception
            Throw ex
            buscarProveedorPorNroComprobante = -1
        End Try
    End Function

    Public Function Filtrar(RazonSocial As String, ByRef rec As DataTable) As Long
        '-----------------------------------------------------
        'Descripción: Obtiene nro de Proveedor que coincidan con la
        'descripcion del proveedor dada por Razonsocial
        'Parámetros : Razón social del proveedor
        '             DataTable rec por ref.
        'Output     : 1 se encontraron datos.
        '            -1 Error al filtrar datos.
        '-----------------------------------------------------
        Dim query
        On Error GoTo errores
        If Not String.IsNullOrEmpty(RazonSocial) And IsNumeric(RazonSocial) Then
            query = "SELECT p.NroProveedor, RSocial,Direccion,Localidad,
                     ConvMulti FROM Proveedor as P where P.NroProveedor LIKE'%" + (Trim(RazonSocial)) + "%'ORDER BY Rsocial"
        Else
            query = "SELECT p.NroProveedor, RSocial,Direccion,Localidad,
                    ConvMulti FROM Proveedor as P WHERE 
                    (P.RSocial LIKE '%" + Left(Trim(RazonSocial), 30) + "%') ORDER BY Rsocial"
        End If
        rec = ServidorSQl.GetTabla(query)

        If rec Is Nothing Then
            GoTo errores
        ElseIf rec.Rows.Count = 0 Then
            Filtrar = 0
        Else
            Filtrar = 1
        End If
        Exit Function

errores:
        Filtrar = -1
    End Function

    Public Function FiltrarCC(ByRef descripcion As String, ByRef rec As DataTable) As Long
        '-----------------------------------------------------
        'Descripción: Obtiene nro de Proveedor que coincidan con la
        'descripcion del proveedor dada por Razonsocial
        'Parámetros : Razón social del proveedor
        '             DataTable rec por ref.
        'Output     : 1 se encontraron datos.
        '            -1 Error al filtrar datos.
        '-----------------------------------------------------
        Dim query
        On Error GoTo errores
        If Not String.IsNullOrEmpty(descripcion) Then
            If IsNumeric(descripcion) Then
                query = "SELECT Codigo, Descripcion FROM ComprobantesCentroCosto WHERE Estado = 1 and CODIGO LIKE '%" & descripcion & "%' ORDER BY codigo"
            Else
                query = "SELECT Codigo, Descripcion FROM ComprobantesCentroCosto WHERE Estado = 1 and DESCRIPCION LIKE '%" & descripcion & "%' ORDER BY codigo"
            End If
        End If
        rec = ServidorSQl.GetTabla(query)

        If rec Is Nothing Then
            GoTo errores
        ElseIf rec.Rows.Count = 0 Then
            FiltrarCC = 0
        Else
            FiltrarCC = 1
        End If
        Exit Function

errores:
        FiltrarCC = -1
    End Function

    Public Function BuscarDescripcionComprobantesTodos(ByRef Recordset As DataTable) As Long
        '-----------------------------------------------------
        'Descripción: Obtiene las descripciones de Comprobantes
        'Parámetros : Recordset por ref.
        'Output     : 0 no se encontraron desc.
        '             1 se encontraron desc.
        '            -1 Error al buscar desc.
        '-----------------------------------------------------
        On Error GoTo errores
        Recordset = ServidorSQl.GetTabla("select * from DescripcionComprobantes order by Descripcion asc")
        If Recordset Is Nothing Then
            GoTo errores
        ElseIf Recordset Is Nothing OrElse Recordset.Rows.Count = 0 Then
            BuscarDescripcionComprobantesTodos = 0
        Else
            BuscarDescripcionComprobantesTodos = 1
        End If
        Exit Function
errores:
        BuscarDescripcionComprobantesTodos = -1
    End Function
    Public Function BuscarTipos(ByRef Recordset As DataTable) As Long
        '-----------------------------------------------------
        'Descripción: Busca los tipos de comprobantes
        '             que pueden existir
        'Parámetros : Recordset por referencia para llenarlo c/
        '             los tipos
        'Output     : 0 no se encontraron tipos
        '             1 se encontraron tipos
        '            -1 Error al buscar tipos
        '-----------------------------------------------------
        On Error GoTo errores
        Recordset = ServidorSQl.GetTabla("select * from TiposComprobantes order by codigo asc")
        If Recordset Is Nothing Then
            GoTo errores
        ElseIf Recordset Is Nothing OrElse Recordset.Rows.Count = 0 Then
            BuscarTipos = 0
        Else
            BuscarTipos = 1
        End If
        Exit Function
errores:
        BuscarTipos = -1
    End Function
    Public Function BuscarProvincias(ByRef Recordset As DataTable) As Long
        '-----------------------------------------------------
        'Descripción: Busca las Provincias
        'Parámetros : Recordset por ref. para llenarlo
        'Output     : 0 no se encontraron Provincias
        '             1 se encontraron Provincias
        '            -1 Error al buscar Provincias
        '-----------------------------------------------------

        On Error GoTo errores
        Recordset = ServidorSQl.GetTabla("select * from Bancos.dbo.provincia order by DescProvincia asc")
        If Recordset Is Nothing Then
            GoTo errores
        ElseIf Recordset Is Nothing OrElse Recordset.Rows.Count = 0 Then
            BuscarProvincias = 0
        Else
            BuscarProvincias = 1
        End If
        Exit Function
errores:
        BuscarProvincias = -1
    End Function

    Public Function BuscarCondicionesPagoComprobantes(ByRef rec As DataTable) As Long
        '-----------------------------------------------------
        'Descripción: Obtiene las condiciones de pago
        '             para los Comprobantes
        'Parámetros : Recordset por ref.
        'Output     : 0 no se encontraron desc.
        '             1 se encontraron desc.
        '            -1 Error al buscar desc.
        '-----------------------------------------------------
        On Error GoTo errores
        rec = ServidorSQl.GetTabla("select * from CondicionPagoComprobantes order by descripcion")
        If rec Is Nothing Then
            GoTo errores
        ElseIf rec Is Nothing Or rec.Rows.Count = 0 Then
            BuscarCondicionesPagoComprobantes = 0
        Else
            BuscarCondicionesPagoComprobantes = 1
        End If
        Exit Function
errores:
        BuscarCondicionesPagoComprobantes = -1
    End Function

    Public Function ControlarUsuarioAfip(ByRef rec As DataTable, ByRef codusuario As Int16) As Int32
        Dim query As String = "SELECT COUNT(*) as cant FROM CtasCtesSQl.dbo.usuariosprefijo WHERE codusuario = " & codusuario & "AND codgestion = 6"
        Try
            rec = ServidorSQl.GetTabla(query)
            If rec Is Nothing Then
                GoTo errores
            ElseIf rec Is Nothing Or rec.Rows.Count = 0 Then
                ControlarUsuarioAfip = 0
            Else
                ControlarUsuarioAfip = 1
            End If

            Exit Function
errores:
            ControlarUsuarioAfip = -1
        Catch ex As Exception
            Throw ex
            ControlarUsuarioAfip = -1
        End Try
    End Function
    Public Function BuscarProveedorPorCuit(ByRef codigo As String, ByRef dataTable As DataTable) As Long
        '-----------------------------------------------------
        'Descripción: Obtiene datos de Proveedor especificado
        '           por N° de cuit (código)
        'Parámetros : N° de proveedor
        '             dataTable rec por ref.
        'Output     : 1 se encontraron datos.
        '             0 no se enontraron datos
        '            -1 Error al obtener datos.
        '-----------------------------------------------------
        On Error GoTo errores

        Dim query As String = "SELECT * FROM Proveedor WHERE nrocuit='" & Trim(codigo) & "'"
        ' Reemplaza TuConexion con tu objeto SqlConnection

        dataTable = ServidorSQl.GetTabla(query)

        ' Llena el DataTable con los resultados de la consulta


        If dataTable Is Nothing Then
            GoTo errores
        ElseIf dataTable.Rows.Count = 0 Then
            BuscarProveedorPorCuit = 0
        Else
            BuscarProveedorPorCuit = 1
        End If

        Exit Function
errores:
        BuscarProveedorPorCuit = -1
    End Function
    Public Function FiltrarComprobante(RazonSocial As String, ByRef rec As DataTable) As Long
        On Error GoTo errores

        ' Combinar condiciones de filtrado por Razón Social y Número de Comprobante
        Dim filtroRazonSocial As String = ""
        Dim filtroNroComp As String = ""

        If Not String.IsNullOrEmpty(RazonSocial) And IsNumeric(RazonSocial) Then
            filtroRazonSocial = "ComprobantesProveedores.NroComp=" & RazonSocial & ") AND "
        Else
            filtroRazonSocial = "Proveedor.RSocial LIKE '%" & Left(Trim(RazonSocial), 30) & "%' AND "
        End If

        ' Construir la consulta SQL con los filtros
        Dim query As String = "SELECT ComprobantesProveedores.NroInterno, ComprobantesProveedores.NroComp, CONVERT(date, ComprobantesProveedores.FechaCarga) as FechaCarga, Proveedor.RSocial " &
                              "FROM Proveedores.dbo.ComprobantesProveedores INNER JOIN Proveedores.dbo.Proveedor ON ComprobantesProveedores.NroProveedor = Proveedor.NroProveedor " &
                              "WHERE " & filtroRazonSocial & filtroNroComp & "1=1 " & "ORDER BY ComprobantesProveedores.NroInterno DESC, Rsocial"

        rec = ServidorSQl.GetTabla(query)

        If rec Is Nothing Then
            GoTo errores
        ElseIf rec.Rows.Count = 0 Then
            FiltrarComprobante = 0
        Else
            FiltrarComprobante = 1
        End If
        Exit Function

errores:
        FiltrarComprobante = -1
    End Function
    Public Function Buscar(ByVal NroInterno As Long, ByRef rec As DataTable, ByRef recPercepcionIB As DataTable, ByRef recIngresos As DataTable, ByRef recOC As DataTable, ByRef recPS As DataTable, ByRef recGastosExp As DataTable) As Long
        '-----------------------------------------------------
        'Descripción: Obtiene los datos de un comprobante
        '             identificado por Nro Interno
        'Parámetros : DataTable por ref.
        '             NroInterno
        'Output     : 0 no se encontraron datos.
        '             1 se encontraron datos.
        '            -1 Error al buscar datos.
        '-----------------------------------------------------

        Try
            Dim query As String = "SELECT * FROM Proveedores.dbo.ComprobantesProveedores WHERE NroInterno =" & NroInterno
            ' Obtener datos de ComprobantesProveedores
            rec = ServidorSQl.GetTabla(query)

            If rec.Rows.Count = 0 Then
                ' No se encontraron datos
                Return 0
            End If

            ' Obtener datos de ComprobantesPercepcionesIB
            recPercepcionIB = ServidorSQl.GetTabla("SELECT * FROM Proveedores.dbo.ComprobantesPercepcionesIB as cp
            join Bancos.dbo.provincia p on p.codProvincia = cp.Provincia WHERE NroInterno =" & NroInterno)
            query = "SELECT CO.*, DescProvincia AS LugarEntrega FROM ComprobantesOrdenes AS CO " &
                                           "INNER JOIN ComprobantesProveedores AS CP ON CO.NroInterno = CP.NroInterno " &
                                           "LEFT OUTER JOIN DetalleIngresoInsumo ON DetalleIngresoInsumo.NroIngreso = CO.NroIngreso " &
                                           "LEFT OUTER JOIN ocomdetalle OCD ON DetalleIngresoInsumo.nroordencompra = OCD.coddetalle " &
                                           "LEFT OUTER JOIN OrdenCompra OC ON OC.codOrdenCompra = OCD.codOrdenCompra " &
                                           "LEFT OUTER JOIN LugarEntrega LE ON OC.CodLugarEntrega = LE.CodLugarEntrega " &
                                           "LEFT OUTER JOIN CtasCtesSQL.dbo.Provincias P ON P.CodProvincia = LE.CodProvincia " &
                                           "WHERE CO.NroInterno =" & NroInterno
            ' Obtener datos de ComprobantesOrdenes
            recIngresos = ServidorSQl.GetTabla(query)

            If rec.Rows(0)("DescCOmp").ToString() = "1" Then
                ' Obtener datos de ComprobanteXParteSalida
                recPS = ServidorSQl.GetTabla("SELECT * FROM ComprobanteXParteSalida WHERE NroInterno =" & NroInterno)
            Else
                ' Obtener datos de ComprobanteXOrdenCarga
                recOC = ServidorSQl.GetTabla("SELECT * FROM ComprobanteXOrdenCarga WHERE NroInterno =" & NroInterno)
            End If

            ' Obtener datos de GastosMonedaExt
            recGastosExp = ServidorSQl.GetTabla("SELECT GME.* FROM insumosdegastos IG " &
                                            "INNER JOIN gastosmonedaext GME ON IG.coddetalle = GME.coddetalle " &
                                            "WHERE IG.codgestion = 2 AND IG.idgestionorigen =" & NroInterno)

            ' Se encontraron datos
            Return 1
        Catch ex As Exception
            ' Manejar la excepción según tus necesidades
            Return -1
        End Try
    End Function

    Public Function BuscarOP(ByVal NroInterno As Long, ByRef NroOP As Long, ByRef NroLiquidacion As Long) As Integer
        '-----------------------------------------------------
        'Descripción: Obtiene los datos de op de un comprobante
        '             identificado por Nro Interno
        'Parámetros : DataTables por ref.
        '             NroInterno
        'Output     : 0 no se encontraron datos.
        '             1 se encontraron datos.
        '            -1 Error al buscar datos.
        '-----------------------------------------------------
        Dim rec As New DataTable()
        Try
            ' Obtener datos de OP
            rec = ServidorSQl.GetTabla("SELECT NroOP, OP.NroLiquidacion, Estado FROM Proveedores.dbo.OP " &
                                   "INNER JOIN Proveedores.dbo.DetalleLiquidaciones ON OP.NroLiquidacion = DetalleLiquidaciones.NroLiquidacion " & "WHERE NroInterno = " & NroInterno)
            If rec.Rows.Count = 0 Then
                Return 0
            End If

            Return 1
        Catch ex As Exception
            Return -1
        End Try
    End Function

    Public Function BuscarIngresosPendientes(ByVal numeroProveedor As Integer) As DataTable
        Try
            Dim sql As String = "SELECT DetalleIngresoInsumo.NroIngreso, DetalleIngresoInsumo.CodInsumo, DetalleIngresoInsumo.DescInsumo, OcomDetalle.Preciopactado * OcomDetalle.Cantidad AS ImporteTotal, OcomDetalle.Cantidad, OcomDetalle.Preciopactado, OrdenCompra.CodMoneda, DetalleIngresoInsumo.Precio AS OC_Precio, DetalleIngresoInsumo.Cantidad AS OC_cant, DetalleIngresoInsumo.Precio * DetalleIngresoInsumo.Cantidad AS OC_Total, insumos.CodCentroCosto " _
            & " FROM OcomDetalle LEFT OUTER JOIN OrdenCompra ON OcomDetalle.codOrdenCompra = OrdenCompra.codOrdenCompra RIGHT OUTER JOIN NrosIngresoNrosOC ON OcomDetalle.codOrdenCompra = NrosIngresoNrosOC.NroOC RIGHT OUTER JOIN DetalleIngresoInsumo INNER JOIN IngresoInsumos ON DetalleIngresoInsumo.NroParte = IngresoInsumos.NroParte ON NrosIngresoNrosOC.NroIngreso = DetalleIngresoInsumo.NroIngreso" _
            & " LEFT OUTER JOIN insumos ON insumos.CodInsumo = DetalleIngresoInsumo.CodInsumo" _
            & " WHERE (DetalleIngresoInsumo.EstadoInsumo <> 'N' AND Insumos.Estado='S') AND (IngresoInsumos.NroProveedor = " & numeroProveedor & ") AND (DetalleIngresoInsumo.NroIngreso NOT IN " _
            & " (SELECT NroIngreso FROM ComprobantesOrdenes))"
            'AND Insumos.Estado='S' agregamos al where para que traiga unicamente los insumos activos de la tabla insumos
            ' Llamada al método que ejecuta la consulta y devuelve un DataTable
            Return ServidorSQl.GetTabla(sql)
        Catch ex As Exception
            ' Manejo de errores
            Throw New Exception("Error al realizar la consulta SQL.", ex)
        End Try
    End Function

    Public Function ObtenerDescripcion(CodigoInsumo As Double) As String
        '-----------------------------------------------------
        'Descripción: Obtiene la descripción del insumo
        '             correspondiente al codigo
        'Parámetros : NroIngreso
        'Output     : Descricpción del insumo en caso que
        '             exista el mismo
        '             Mensaje de Error en caso contrario
        '-----------------------------------------------------
        Dim descripcion As String = ""

        Try
            Dim sql As String = "SELECT descripcion FROM insumos WHERE codinsumo=" & CodigoInsumo & " AND Estado= 'S'"

            ' Llamada al método que ejecuta la consulta y devuelve un DataTable
            Dim tabla As DataTable = ServidorSQl.GetTabla(sql)

            ' Verificar si se encontraron resultados en la consulta
            If tabla.Rows.Count > 0 Then
                ' Obtener la descripción de la primera fila (asumiendo que es única)
                descripcion = tabla.Rows(0)("descripcion").ToString()
            Else
                ' En caso de que no haya resultados
                descripcion = "DIE"
            End If
        Catch ex As Exception
            ' Manejo de errores
            Throw New Exception("Error al realizar la consulta SQL.", ex)
        End Try

        Return descripcion
    End Function

    Public Function BuscarCentroCostoXInsumo(ByVal insumo As String) As String
        '-----------------------------------------------------
        'Descripción: Busca C.C. de acuerdo al insumo
        'Parámetros : Insumo
        'Output     : "" = no se encontraron datos
        '             descripción si se encontraron datos
        '            Error
        '-----------------------------------------------------
        Try
            Dim sql As String = "SELECT * FROM Insumos WHERE CodInsumo = '" & insumo & "' AND Estado = 'S'"
            Dim tabla As DataTable = ServidorSQl.GetTabla(sql)

            If tabla.Rows.Count > 0 Then
                Return tabla.Rows(0)("codCentroCosto").ToString()
            Else
                Return ""
            End If
        Catch ex As Exception
            ' Manejo de errores
            Throw New Exception("Error al realizar la consulta SQL.", ex)
        End Try
    End Function


    Public Sub LlenarListBox(ByRef NroProveedor As Integer, ByRef tabla As DataTable)
        Dim i As Long
        Dim separador As String
        Dim sql As String

        separador = Chr(124) & " "

        If NroProveedor <= 0 Then
            MsgBox("Proveedor No válido.", vbInformation)
            ' No se activa ni oculta el botón CAceptar aquí, puedes manejarlo según tus necesidades.
            Exit Sub
        End If

        sql = "SELECT distinct DetalleIngresoInsumo.NroIngreso, DetalleIngresoInsumo.CodInsumo, DetalleIngresoInsumo.DescInsumo,OcomDetalle.Preciopactado * OcomDetalle.Cantidad AS ImporteTotal, OcomDetalle.Cantidad, OcomDetalle.Preciopactado, OrdenCompra.CodMoneda,DetalleIngresoInsumo.Precio AS OC_Precio, DetalleIngresoInsumo.CantEfectiva AS OC_cant,DetalleIngresoInsumo.Precio * DetalleIngresoInsumo.Cantidad AS OC_Total, CondicionPagoComprobantes.CantDias, insumos.CodCentroCosto " _
    & " FROM OrdenCompra INNER JOIN CondicionPagoComprobantes ON OrdenCompra.CondPago = CondicionPagoComprobantes.codigo RIGHT OUTER JOIN DetalleIngresoInsumo INNER JOIN IngresoInsumos ON DetalleIngresoInsumo.NroParte = IngresoInsumos.NroParte LEFT OUTER JOIN OcomDetalle INNER JOIN NrosIngresoNrosOC ON OcomDetalle.codInsumo = NrosIngresoNrosOC.CodInsumo AND OcomDetalle.codOrdenCompra = NrosIngresoNrosOC.NroOC ON DetalleIngresoInsumo.NroIngreso = NrosIngresoNrosOC.NroIngreso ON OrdenCompra.codOrdenCompra = OcomDetalle.codOrdenCompra" _
    & " LEFT OUTER JOIN insumos ON insumos.CodInsumo = DetalleIngresoInsumo.CodInsumo" _
    & " WHERE ordencompra.seguimiento=0 and (DetalleIngresoInsumo.EstadoInsumo <> 'N' AND Insumos.Estado='S') AND (IngresoInsumos.NroProveedor = " & NroProveedor & ") AND (DetalleIngresoInsumo.NroIngreso NOT IN (SELECT NroIngreso FROM ComprobantesOrdenes)) order by DetalleIngresoInsumo.NroIngreso asc"
        'AND Insumos.Estado='S' agregamos al where para que traiga unicamente los insumos activos de la tabla insumos
        ' Llamada al método que ejecuta la consulta y devuelve un DataTable
        tabla = ServidorSQl.GetTabla(sql)

    End Sub


    Public Function BuscarPorNroProveedor(ByRef codigo As Long, ByRef tabla As DataTable) As Long
        '-----------------------------------------------------
        'Descripción: Obtiene datos de Proveedor especificado
        '           por N° de proveedor
        'Parámetros : N° de proveedor
        '             recordset rec por ref.
        'Output     : 1 se encontraron datos.
        '             0 no se enontraron datos
        '            -1 Error al obtener datos.
        '-----------------------------------------------------

        tabla = ServidorSQl.GetTabla("SELECT p.NroProveedor, RSocial,Direccion,Localidad,
ConvMulti, CodTipoInsumosProveedor, NroCUIT, pi.observaciones,InhabilitacionImpositiva, CodEstadoProveedor FROM Proveedor as P LEFT OUTER JOIN  ProveedoresInhabilitados as PI on pi.nroProveedor = P.NroProveedor  where P.NroProveedor=" & codigo)
        If tabla Is Nothing Then
            Return -1
        ElseIf tabla.Rows.Count = 0 Then
            BuscarPorNroProveedor = 0
        Else
            BuscarPorNroProveedor = 1
        End If
    End Function
    Public Function ObtenertipoInsumoProveedor(ByRef codigo As Integer)

        Try
            Dim tabla As DataTable = ServidorSQl.GetTabla("SELECT codigosinsumosprovistos.descripcion FROM Proveedor INNER JOIN codigosinsumosprovistos ON proveedor.codtipoinsumosproveedor = codigosinsumosprovistos.codigo WHERE proveedor.nroproveedor = " & codigo)

            If tabla IsNot Nothing AndAlso tabla.Rows.Count > 0 Then
                Return UCase(Trim(tabla.Rows(0)("Descripcion").ToString()))
            Else
                Return ""
            End If
        Catch ex As Exception
            ' Manejar la excepción
            MsgBox("Error al obtener tipo de insumo del proveedor. Detalles: " & ex.Message, MsgBoxStyle.Exclamation)
            Return ""
        End Try
    End Function


    Public Function ValidarOrdenCarga(ByRef rec As DataTable, ByRef nroInterno As String) As Integer
        Dim RstAux As New DataTable
        Dim CadenaSql As String
        ValidarOrdenCarga = 0
        rec.DefaultView.Sort = "NroOrdenCarga"
        rec.DefaultView.RowFilter = ""

        If rec.Rows.Count > 0 Then
            For Each row As DataRowView In rec.DefaultView
                If row("NroOrdenCarga") = 0 Then
                    ValidarOrdenCarga = 4
                    Exit Function
                Else
                    CadenaSql = "SELECT * FROM Ventas.dbo.OCarga WHERE NroOCarga = " & row("NroOrdenCarga")
                    RstAux = ServidorSQl.GetTabla(CadenaSql)
                    If RstAux.Rows.Count > 0 Then
                        Dim fechaDiff As Integer = DateDiff(DateInterval.Day, DateTime.Now, Convert.ToDateTime(RstAux.Rows(0)("Fecha")))
                        If fechaDiff > 15 Then
                            ValidarOrdenCarga = 2
                            Exit Function
                        Else
                            ValidarOrdenCarga = 1
                        End If
                    Else
                        ValidarOrdenCarga = 0
                        Exit Function
                    End If

                    CadenaSql = "SELECT * FROM ComprobanteXOrdenCarga WHERE NroOrdenCarga = " & Convert.ToInt32(row("NroOrdenCarga")) & " AND nrointerno <>" & nroInterno
                    RstAux = ServidorSQl.GetTabla(CadenaSql)

                    If RstAux.Rows.Count > 0 Then
                        ValidarOrdenCarga = 1
                    End If
                End If
            Next
        End If

        ValidarOrdenCarga = -1
    End Function

    Public Function ValidarParteSalida(ByRef RstParteSalida As DataTable, ByVal Estado As String, ByRef nroInterno As String) As Integer
        Dim CadenaSql As String
        Dim RstAux As New DataTable

        ValidarParteSalida = 0

        If RstParteSalida.Rows.Count > 0 Then
            For Each row As DataRow In RstParteSalida.Rows
                If row("NroParteSalida") = 0 Then
                    ValidarParteSalida = 4
                    Exit Function
                Else
                    CadenaSql = "Select * from Almacen.dbo.ParteSalida where NroParteSalida = " & CStr(row("NroParteSalida")).Replace(",", "")
                    RstAux = ServidorSQl.GetTabla(CadenaSql)

                    If RstAux.Rows.Count > 0 Then
                        If DateDiff(DateInterval.Day, Date.Now, CDate(RstAux.Rows(0)("Fecha"))) >= 0 Then
                            ValidarParteSalida = 2
                            Exit Function
                        Else
                            ValidarParteSalida = 1
                        End If
                    Else
                        ValidarParteSalida = 0
                        Exit Function
                    End If

                    If Estado = "MODIFICAR" Then
                        CadenaSql = "select * from ComprobanteXParteSalida where NroParteSalida = " & CStr(row("NroParteSalida")).Replace(",", "") & " AND nrointerno <>" & Int(nroInterno)
                        RstAux = ServidorSQl.GetTabla(CadenaSql)
                        If RstAux.Rows.Count = 0 Then

                        Else
                            ValidarParteSalida = 3
                            Exit Function
                        End If
                    Else
                        CadenaSql = "select * from ComprobanteXParteSalida where NroParteSalida = " & CStr(row("NroParteSalida")).Replace(",", "")
                        RstAux = ServidorSQl.GetTabla(CadenaSql)

                        If RstAux.Rows.Count = 0 Then
                        Else
                            ValidarParteSalida = 3
                            Exit Function
                        End If
                    End If
                End If
            Next
        End If

        ValidarParteSalida = -1
    End Function

    Public Sub ObtenerProveedor(ByRef dt As DataTable, ByRef nroProveedor As Integer)
        Dim CadenaSql As String = "select * from proveedor where NroProveedor = " & nroProveedor
        dt = ServidorSQl.GetTabla(CadenaSql)
    End Sub

    Public Function ValidarNroFactura(ByVal NroProveedor As Long, ByVal NroFactura As String, ByVal TipoComprobante As Integer, ByVal LetraComprobante As Integer) As Long
        '---------------------------------------------------------------
        'Descripción: verifica si el nro de comprobamnte ya esta cargado
        'Parámetros : Nro de Proveedor, Nro de factura
        'Output     : 0 la factura no está cargada
        '             1 la factura ya esta cargada.
        '            -1 Error al buscar datos de factura.
        '-----------------------------------------------------
        Dim rec As New DataTable
        rec = ServidorSQl.GetTabla("select nrointerno from ComprobantesProveedores where tipocomp=" & LetraComprobante & " and desccomp=" & TipoComprobante & " and NroProveedor=" & NroProveedor & " and NroComp='" & NroFactura & "'")
        If rec Is Nothing Then
        ElseIf rec.Rows.Count = 0 Then
            ValidarNroFactura = 0
        Else
            ValidarNroFactura = rec.Rows(0)("NroInterno").ToString()
        End If
        Exit Function
        ValidarNroFactura = -1
    End Function
    Public Function ValidarNroComprobante(ByVal NroProveedor As Long, ByVal NroFactura As String, ByVal TipoComprobante As Integer, ByVal LetraComprobante As Integer) As Long
        '---------------------------------------------------------------
        'Descripción: verifica si el nro de comprobamnte ya esta cargado
        'Parámetros : Nro de Proveedor, Nro de factura
        'Output     : 0 la factura no está cargada
        '             1 la factura ya esta cargada.
        '            -1 Error al buscar datos de factura.
        '-----------------------------------------------------
        Dim rec As New DataTable
        Dim Grupo As Integer


        If VariablesGlobales.pantallaCreditoDebito = "CREDITODEBITO" Then

            Select Case TipoComprobante
                Case 5, 14, 17, 19 'Debitos Guma
                    Grupo = 6
                Case 10, 12, 18, 20
                    Grupo = 4      'Creditos Guma
            End Select
        Else

            Select Case TipoComprobante
                Case 1
                    Grupo = 1
                Case 2
                    Grupo = 2
                Case 3, 4, 5, 6, 13, 14, 17, 19 'debitos
                    If Len(CStr(NroFactura)) = 12 And Left(NroFactura, 4) = 4000 Then ''es Guma
                        Grupo = 6
                    Else
                        Grupo = 5
                    End If
                Case 7, 8, 9, 10, 11, 12, 18, 20 'creditos
                    If Len(CStr(NroFactura)) = 12 And Left(NroFactura, 4) = 4000 Then ''es Guma
                        Grupo = 4
                    Else
                        Grupo = 3
                    End If
                Case 23, 24
                    Grupo = 11
            End Select
        End If

        rec = ServidorSQl.GetTabla("select nrointerno from ComprobantesProveedores where tipocomp=" & LetraComprobante & " and desccomp=" & TipoComprobante & " and NroProveedor=" & NroProveedor & " and NroComp='" & NroFactura & "'")
        If rec Is Nothing Then
        ElseIf rec.Rows.Count = 0 Then
            ValidarNroComprobante = 0
        Else
            ValidarNroComprobante = rec.Rows(0)("NroInterno").ToString()
        End If
        Exit Function
        ValidarNroComprobante = -1
    End Function



    Public Function NuevoComprobantePrincipal(ByRef comprobante As ModeloComprobanteProveedor, ByVal CodBarra As String, ByRef ItemsIB As DataTable, ByRef ItemsIngresos As DataTable,
                                              ByRef RstOC As DataTable, ByRef RstPS As DataTable, ByVal FechaVtoCAE As String, Pantalla As String,
                                              CodValidacionCba As String, FechaIngresoProv As String, nroCompAlfanumerico As String, ChkPorCuentaTercero As Integer,
ByVal CODoPERADOR As Integer) As Long

        Dim ordenesCompra As List(Of ModeloOrdenDeCompra)
        Dim rec As DataTable
        Dim recc As DataTable
        Dim Record As New DataTable
        Dim RstAux As New DataTable
        Dim RstAuxCons As New DataTable
        Dim tipoAutoriza As Integer
        Dim Cotiza As String
        Dim sumaTipoAutoriza As Integer
        Dim sql As String

        Dim Grupo As Integer
        Dim Fichero As String
        Dim oVtoCAI As String
        Dim oCAI As String
        Dim CadenaSQL As String
        Dim oiva As String
        Dim oExento As String
        Dim oGravado As String
        Dim oCodDetalleExp As Long
        Dim NuevoidComprobanteOrden As Integer
        Dim oIdMaterialConsuman As String
        Dim json As String


        tipoAutoriza = 0
        sumaTipoAutoriza = 0
        Dim oPrefijo As String
        Dim oNumero As String
        Dim oNroProv As Integer

        If Pantalla = "CREDITODEBITO" Then
            Select Case comprobante.DescComp
                Case 5, 14, 17, 19 'Debitos Guma
                    Grupo = 6
                Case 10, 12, 18, 20
                    Grupo = 4      'Creditos Guma
            End Select
        Else
            ''colocar aca los tipos de grupo
            Select Case comprobante.DescComp
                Case 1
                    Grupo = 1
                Case 2
                    Grupo = 2
                Case 3, 4, 5, 6, 13, 14, 17, 19 'debitos
                    If Len(CStr(comprobante.NroComp)) = 12 And Left(comprobante.NroComp, 4) = 4000 Then ''es Guma
                        Grupo = 6
                    Else
                        Grupo = 5
                    End If
                Case 7, 8, 9, 10, 11, 12, 18, 20 'creditos
                    If Len(CStr(comprobante.NroComp)) = 12 And Left(comprobante.NroComp, 4) = 4000 Then ''es Guma
                        Grupo = 4
                    Else
                        Grupo = 3
                    End If
                Case 23, 24
                    Grupo = 11
            End Select
        End If

        oCAI = Trim(comprobante.CAI)
        oVtoCAI = Trim(comprobante.VtoCAI)

        If Grupo = 11 Then
            sql = "INSERT INTO ComprobantesProveedores (NroProveedor,DescComp,TipoComp,NroComp,FechaComp,FechaCarga,FechaVto,CondicionPago,Observacion,IvaProd,ImporteProd,IvaFinan,ImporteFinan,PercepIva,PercepGan,TotalPercepIB,ImporteNoImp,TotalComprobante,cai,vtocai,codbarra,codestadopago,TipoGrupo,cotizaciondolar, Iva21, Iva105, Iva27,Iva25, Imp21, Imp105, Imp27, Imp25, CodValidacionCba,FechaIngresoProveedores, nroCompAlfanumerico, codOrigenFacturacion, porcuentadetercero , CodOperadorIngresoComp " _
            & ") VALUES (" & comprobante.NroProveedor & "," & comprobante.DescComp & ", " & comprobante.TipoComp & "," & comprobante.NroComp.Replace("-", "") & ",'" & comprobante.FechaComp & "','" & comprobante.FechaCarga & "','" & comprobante.FechaVto & "'," & comprobante.CondicionPago & ",'" & Left(comprobante.Observacion, 200) & "'," & Trim(comprobante.IvaProd).Replace(",", ".") & "," & Trim(comprobante.ImporteProd).Replace(",", ".") & ",0 ,0 ," & Trim(comprobante.PercepIva).Replace(",", ".") & "," & Trim(comprobante.PercepGan).Replace(",", ".") & "," & Trim(comprobante.TotalPercepIB).Replace(",", ".") & "," & Trim(comprobante.ImporteNoImp).Replace(",", ".") & "
            ," & Trim(comprobante.TotalComp).Replace(",", ".") & ",'" & Left(oCAI, 14) & "', '" & oVtoCAI & "','" & Left(CodBarra, 40) & "',4," & Grupo & "," & Replace(comprobante.CotizacionDolar, ",", ".") & ", " & Trim(comprobante.Iva21) & ", " & Trim(comprobante.Iva105) & ", " & Trim(comprobante.Iva27).Replace(",", ".") & ", " & Trim(comprobante.Iva25).Replace(",", ".") & "," & Trim(comprobante.Imp21).Replace(",", ".") & ", " & Trim(comprobante.Imp105).Replace(",", ".") & ", " & Trim(comprobante.Imp27).Replace(",", ".") & ", " & Trim(comprobante.Imp25).Replace(",", ".") & ", " _
            & " '" & CodValidacionCba & "','" & FechaIngresoProv & "', '" & nroCompAlfanumerico & "' ," & OrigenFacturacion & ", " & ChkPorCuentaTercero & ", " & CODoPERADOR & ") "
        Else
            sql = "INSERT INTO ComprobantesProveedores (NroProveedor,DescComp,TipoComp,NroComp,FechaComp,FechaCarga,FechaVto,CondicionPago,Observacion,IvaProd,ImporteProd,IvaFinan,ImporteFinan,PercepIva,PercepGan,TotalPercepIB,ImporteNoImp,TotalComprobante,cai,vtocai,codbarra,codestadopago,TipoGrupo,cotizaciondolar, Iva21, Iva105, Iva27, Iva25, Imp21, Imp105, Imp27,Imp25, CodValidacionCba,FechaIngresoProveedores, codOrigenFacturacion, porcuentadetercero , CodOperadorIngresoComp " _
            & ") VALUES (" & comprobante.NroProveedor & "," & comprobante.DescComp & ", " & comprobante.TipoComp & "," & comprobante.NroComp.Replace("-", "") & ",'" & comprobante.FechaComp & "','" & comprobante.FechaCarga & "','" & comprobante.FechaVto & "'," & comprobante.CondicionPago & ",'" & Left(comprobante.Observacion, 200) & "'," & Trim(comprobante.IvaProd).Replace(",", ".") & "," & Trim(comprobante.ImporteProd).Replace(",", ".") & ",0 ,0 ," & Trim(comprobante.PercepIva).Replace(",", ".") & "," & Trim(comprobante.PercepGan).Replace(",", ".") & "," & Trim(comprobante.TotalPercepIB).Replace(",", ".") & "," & Trim(comprobante.ImporteNoImp).Replace(",", ".") & "," & Trim(comprobante.TotalComp).Replace(",", ".") & ",'" & oCAI & "', '" & oVtoCAI & "','" & Left(CodBarra, 40) & "',4," & Grupo & "," & Replace(comprobante.CotizacionDolar, ",", ".") & ", " & Trim(comprobante.Iva21).Replace(",", ".") & ", " & Trim(comprobante.Iva105).Replace(",", ".") & ", " & Trim(comprobante.Iva27).Replace(",", ".") & ", " & Trim(comprobante.Iva25).Replace(",", ".") & "," & Trim(comprobante.Imp21).Replace(",", ".") & ", " & Trim(comprobante.Imp105).Replace(",", ".") & ", " & Trim(comprobante.Imp27).Replace(",", ".") & ", " & Trim(comprobante.Imp25).Replace(",", ".") & ", " _
            & " '" & CodValidacionCba & "','" & FechaIngresoProv & "'," & OrigenFacturacion & ", " & ChkPorCuentaTercero & ", " & CODoPERADOR & ") "
        End If


        ServidorSQl.GetTabla(sql)


        Record = ServidorSQl.GetTabla("select top 1 nrointerno from ComprobantesProveedores order by nrointerno desc")
        If Record.Rows.Count = 0 Then
        Else
            NuevoComprobantePrincipal = CInt(Record.Rows(0)("NroInterno"))
            If NuevoComprobantePrincipal = 100000000 Then
                NuevoComprobantePrincipal = -2
                Record = Nothing
                RstAux = Nothing
                Exit Function
            End If
        End If

        If RstOC.Rows.Count > 0 Then
            For Each row As DataRow In RstOC.Rows
                If Not IsDBNull(row("NroOrdenCarga")) AndAlso (row("NroOrdenCarga") IsNot Nothing AndAlso row("NroOrdenCarga").ToString() <> "") Then
                    sql = "INSERT INTO ComprobanteXOrdenCarga (NroComp, NroInterno, NroOrdenCarga, Observacion, Fecha, NroProveedor) " &
                                        "VALUES (" & comprobante.NroComp & ", " & NuevoComprobantePrincipal & ", " & row("NroOrdenCarga") & " ,'' , '" & Now.ToString("dd/MM/yyyy") & "', " & comprobante.NroProveedor & ")"
                    ServidorSQl.InsertTabla(sql)
                End If
            Next
        End If



        If RstPS.Rows.Count > 0 Then

            For Each row As DataRow In RstPS.Rows
                If Not IsDBNull(row("NroParteSalida")) AndAlso (row("NroParteSalida") IsNot Nothing AndAlso row("NroParteSalida").ToString() <> "") Then
                    sql = "INSERT INTO ComprobanteXParteSalida(NroInterno, NroParteSalida, NroProveedor, Valor) " &
                                        "VALUES (" & NuevoComprobantePrincipal & ", " & row("NroParteSalida") & ", " & comprobante.NroProveedor & ", " & Replace(row("Valor").ToString(), ",", ".") & " )"
                    ServidorSQl.InsertTabla(sql)
                End If
            Next
        End If


        If ItemsIB.Rows.Count > 0 Then
            For Each row As DataRow In ItemsIB.Rows
                Dim provincia As String = If(IsDBNull(row("Provincia")), "NULL", "'" & row("Provincia").ToString() & "'")
                Dim baseImponible As String = If(IsDBNull(row("BaseImponible")), "NULL", FormatoSQL(Trim(row("BaseImponible").ToString())))
                Dim percepcion As String = If(IsDBNull(row("Percepcion")), "NULL", FormatoSQL(Trim(row("Percepcion").ToString())))

                sql = $"INSERT INTO ComprobantesPercepcionesIB (NroInterno, provincia, baseImponible, percepcion) VALUES ({NuevoComprobantePrincipal}, {provincia}, {baseImponible}, {percepcion})"
                ServidorSQl.InsertTabla(sql)
            Next
        End If

        If ItemsIngresos.Rows.Count > 0 Then
            For Each row As DataRow In ItemsIngresos.Rows
                tipoAutoriza = 0
                oNroProv = comprobante.NroProveedor
                If ItemsIngresos.Columns.Contains("nroingreso") AndAlso Not IsDBNull(row("nroingreso")) Then

                    If ItemsIngresos.Columns.Contains("idMaterial") AndAlso Not row.IsNull("idMaterial") Then

                        json = model.ObtenerPendientesConsuman(Convert.ToInt32(oNroProv), token)
                        ds = model.ConvertirJsonADatatable(json)
                        Select Case json
                            Case json <> ""
                            Case Else
                                Exit Function
                        End Select
                        For Each fila As DataRow In recc.Rows
                            ' Obtener la fila correspondiente en ItemsIngresos
                            Dim ingresosRow As DataRow = ItemsIngresos.Rows(0)

                            If fila("nroingreso").Equals(ingresosRow("idDetalle")) AndAlso CInt(fila("idMaterial")) <> 0 Then
                                CadenaSQL = $"INSERT INTO ComprobanteOrdenesPorDetalleConsuman (idDetalle, Cantidad, Precio, Numero, idMaterial, tipoingreso) OUTPUT inserted.id VALUES " &
                                 $"({FormatoSQL(Trim(row("idDetalle")))}, {row("cantidad")}, {FormatoSQL(Trim(fila("precio")))}, {fila("nroComprobante")}, {fila("idMaterial")}, 1)"
                                RstAuxCons = ServidorSQl.GetTabla(CadenaSQL)

                                If CDbl(ingresosRow("cantidad")) <> CDbl(fila("cantidad")) Then
                                    ServidorSQl.InsertTabla($"UPDATE ComprobantesProveedores SET MarcaAcumulado='P' WHERE NroInterno={NuevoComprobantePrincipal}")
                                    tipoAutoriza = 7
                                End If

                                If Math.Abs(CDbl(ingresosRow("precio")) - CDbl(fila("precio"))) > 0.99 Then
                                    ServidorSQl.InsertTabla($"UPDATE ComprobantesProveedores SET MarcaAcumulado='P' WHERE NroInterno={NuevoComprobantePrincipal}")
                                    tipoAutoriza = 1
                                End If
                            End If
                        Next
                    End If




                    If Not (ds Is Nothing) Then
                        If json <> "" Then
                        Else
                            If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                            Else
                                With recc
                                    .Columns.Add("idDetalle", GetType(Double))
                                    .Columns.Add("idMaterial", GetType(Double))
                                    .Columns.Add("Descripcion", GetType(String))
                                    .Columns.Add("Cantidad", GetType(Double))
                                    .Columns.Add("Precio", GetType(Decimal))
                                    .Columns.Add("codInsumo", GetType(String))
                                    .Columns.Add("codCentroCosto", GetType(Integer))
                                    .Columns.Add("NroComprobante", GetType(Integer))
                                    .Columns.Add("Total", GetType(Double))
                                End With

                                Dim items As New List(Of ItemLista)()
                                For Each orden As ModeloOrdenDeCompra In ordenesCompra
                                    ' Obtener el número de la orden de compra
                                    Dim number As Int32 = CInt(orden.Number)
                                    Dim tipocomp As String = orden.VoucherType
                                    Dim codinsumo As String
                                    Dim codCentroCosto As Integer

                                    ' Iterar sobre cada detalle de la orden de compra
                                    For Each detalle As ModeloDetalleOrdenCompra In orden.Details
                                        ' Obtener los datos del detalle de la orden de compra
                                        Dim detalleId As Integer = detalle.Id
                                        Dim supplyId As Integer = detalle.SupplyId
                                        Dim supply As String = detalle.Supply
                                        Dim supplyKey As String = detalle.SupplyKey
                                        Dim quantity As Double = detalle.Quantity
                                        Dim cost As Double = detalle.Cost
                                        Dim idsubrubro As Integer = detalle.SubKindId
                                        controlInsumo.ObtenerCodInsumoBySubRubro(detalle.SubKindId, codinsumo, codCentroCosto)

                                        ' Crear un objeto ItemLista y agregarlo a la lista de items
                                        Dim listItem As New ItemLista()
                                        listItem.Text = $"Tipo Comprobante: {orden.VoucherType}; Número: {orden.Number}; ID: {codinsumo}; Producto: {supply}; Cantidad: {quantity}; Costo: {cost}; Centro Costo: {codCentroCosto}"
                                        listItem.Value = orden.Number
                                        items.Add(listItem)
                                    Next
                                Next
                                If recc.Rows.Count = 0 Then
                                Else
                                    For Each fila As DataRow In recc.Rows
                                        If ItemsIngresos.Rows.Count > 0 AndAlso ItemsIngresos.Rows.Cast(Of DataRow)().Any(Function(x) CInt(x("nroingreso")) = CInt(fila("idDetalle")) AndAlso CInt(x("idMaterial")) <> 0) Then
                                            sql = $"INSERT INTO ComprobanteOrdenesPorDetalleConsuman (idDetalle, Cantidad, Precio, Numero, idMaterial, tipoingreso) " &
                                                            $"OUTPUT inserted.id VALUES ({FormatoSQL(Trim(fila("idDetalle")))}, {fila("cantidad")}, {FormatoSQL(Trim(fila("precio")))}, {fila("nroComprobante")}, {row("idMaterial")}, 1)"
                                            RstAuxCons = ServidorSQl.GetTabla(sql)

                                            If CDbl(ItemsIngresos.Rows(0)("cantidad")) <> CDbl(fila("cantidad")) Then
                                                ServidorSQl.InsertTabla($"Update ComprobantesProveedores set MarcaAcumulado='P' where NroInterno={NuevoComprobantePrincipal}")
                                                tipoAutoriza = 7
                                            End If

                                            If Math.Abs(CDbl(ItemsIngresos.Rows(0)("precio")) - CDbl(fila("precio"))) > 0.99 Then
                                                ServidorSQl.InsertTabla($"Update ComprobantesProveedores set MarcaAcumulado='P' where NroInterno={NuevoComprobantePrincipal}")
                                                tipoAutoriza = 1
                                            End If
                                        End If
                                    Next
                                End If

                            End If
                        End If
                    End If
                End If
                If comprobante.DescComp = 1 Then

                    '***************************************************

                    If ItemsIngresos.Rows(0)("idMaterial") = 0 Then

                        '***************************************************
                        'SI ES UNA FACTURA ENTRA A CONTROLAR DIFERENCIAS
                        tipoAutoriza = 0
                        sql = "SELECT OcomDetalle.Preciopactado, DetalleIngresoInsumo.Cantefectiva,DetalleIngresoInsumo.CantidadReal, OrdenCompra.CondPago, OrdenCompra.codmoneda FROM NrosIngresoNrosOC 
                                   INNER JOIN DetalleIngresoInsumo ON NrosIngresoNrosOC.CodInsumo = DetalleIngresoInsumo.CodInsumo 
                                   AND NrosIngresoNrosOC.NroIngreso = DetalleIngresoInsumo.NroIngreso INNER JOIN OcomDetalle 
                                   ON NrosIngresoNrosOC.NroOC = OcomDetalle.codOrdenCompra AND NrosIngresoNrosOC.CodInsumo = OcomDetalle.codInsumo 
                                   INNER JOIN OrdenCompra  ON OcomDetalle.codOrdenCompra = OrdenCompra.codOrdenCompra 
                                   Where NrosIngresoNrosOC.NroIngreso =" & ItemsIngresos.Rows(0)("nroingreso")

                        Record = ServidorSQl.GetTabla(sql)
                        If Record Is Nothing Then
                        ElseIf Record.Rows.Count = 0 Then

                        Else
                            If ItemsIngresos.Rows(0)("idMaterial") = 0 Then
                                ' SI ES UNA FACTURA ENTRA A CONTROLAR DIFERENCIAS
                                tipoAutoriza = 0

                                sql = "SELECT OcomDetalle.Preciopactado, DetalleIngresoInsumo.Cantefectiva, DetalleIngresoInsumo.CantidadReal, OrdenCompra.CondPago, OrdenCompra.codmoneda FROM NrosIngresoNrosOC INNER JOIN DetalleIngresoInsumo ON NrosIngresoNrosOC.CodInsumo = DetalleIngresoInsumo.CodInsumo AND NrosIngresoNrosOC.NroIngreso = DetalleIngresoInsumo.NroIngreso INNER JOIN OcomDetalle ON NrosIngresoNrosOC.NroOC = OcomDetalle.codOrdenCompra AND NrosIngresoNrosOC.CodInsumo = OcomDetalle.codInsumo INNER JOIN OrdenCompra ON OcomDetalle.codOrdenCompra = OrdenCompra.codOrdenCompra WHERE NrosIngresoNrosOC.NroIngreso =" & ItemsIngresos.Rows(0)("nroingreso")
                                Record = ServidorSQl.GetTabla(sql)

                                If Record.Rows.Count > 0 Then
                                    Dim precioItemsIngresos As Double = Convert.ToDouble(ItemsIngresos.Rows(0)("precio"))
                                    Dim precioPactado As Double = Convert.ToDouble(Record.Rows(0)("Preciopactado"))

                                    If Math.Abs(precioItemsIngresos - precioPactado) > 0.01 Then
                                        If Record.Rows(0)("codMoneda") = 2 Then
                                            ' Es en dólares, verifica si coincide el precio más o menos

                                            Cotiza = String.Empty
                                            Do Until Val(Cotiza) <> 0
                                                Cotiza = comprobante.CotizacionDolar ' Puedes cambiar esto según tus necesidades
                                                If Val(Cotiza) <> 0 Then
                                                    If IsNumeric(Cotiza) Then
                                                    Else
                                                        MsgBox("No existe un valor válido para la cotización del dólar. La acción de registro de los datos se cancelará.", MsgBoxStyle.Critical, "Grabando Nuevo Comprobante")
                                                    End If
                                                End If
                                            Loop

                                            If Math.Abs(precioItemsIngresos - (precioPactado * Val(Replace(Cotiza, ",", ".")))) > 0.01 Then
                                                ServidorSQl.InsertTabla("Update ComprobantesProveedores SET MarcaAcumulado='P' WHERE NroInterno=" & NuevoComprobantePrincipal)
                                                tipoAutoriza = 1
                                            End If

                                        Else
                                            ServidorSQl.InsertTabla("Update ComprobantesProveedores SET MarcaAcumulado='P' WHERE nrointerno=" & NuevoComprobantePrincipal)
                                            tipoAutoriza = 1
                                        End If
                                    End If
                                End If
                            End If
                            If Not IsDBNull(comprobante.CondicionPago) AndAlso Not IsDBNull(Record("CondPago")) AndAlso comprobante.CondicionPago <> Convert.ToInt32(Record("CondPago")) Then
                                ServidorSQl.InsertTabla("Update ComprobantesProveedores set MarcaAcumulado='P' where nrointerno=" & NuevoComprobantePrincipal)
                                tipoAutoriza = tipoAutoriza + 3
                            End If

                            Dim cantidadRegistro As Double

                            If Record("cantefectiva") Is DBNull.Value OrElse Not IsNumeric(Record("cantefectiva")) Then
                                cantidadRegistro = Convert.ToDouble(Record("cantidadreal"))
                            Else
                                cantidadRegistro = Convert.ToDouble(Record("cantefectiva"))
                            End If

                            If ItemsIngresos.Rows.Count > 0 AndAlso CDbl(ItemsIngresos.Rows(0)("cantidad")) <> cantidadRegistro Then
                                ServidorSQl.InsertTabla("Update ComprobantesProveedores set MarcaAcumulado='P' where nrointerno=" & NuevoComprobantePrincipal)
                                If tipoAutoriza = 1 Then
                                    ' PRECIO + CANTIDAD
                                    tipoAutoriza = 7
                                Else
                                    ' CANTIDAD + ALGO (O NO)
                                    tipoAutoriza = tipoAutoriza + 2
                                End If
                            End If

                        End If
                    End If
                End If



                If ItemsIngresos.Rows.Count > 0 Then
                    If ItemsIngresos.Rows(0)("Iva") Is DBNull.Value OrElse ItemsIngresos.Rows(0)("Iva").ToString() = "" Then
                        oiva = "NULL"
                    Else
                        oiva = FormatoSQL(ItemsIngresos.Rows(0)("Iva").ToString())
                    End If

                    If ItemsIngresos.Rows(0)("Gravado") Is DBNull.Value OrElse ItemsIngresos.Rows(0)("Gravado").ToString() = "" Then
                        oGravado = "NULL"
                    Else
                        oGravado = FormatoSQL(ItemsIngresos.Rows(0)("Gravado").ToString())
                    End If
                Else
                    oiva = "NULL"
                    oGravado = "NULL"
                End If


                If ItemsIngresos.Rows(0)("Exento") = "" Then
                    oExento = "NULL"
                Else
                    oExento = FormatoSQL(ItemsIngresos.Rows(0)("Exento"))
                End If

                If Pantalla = "PRINCIPAL" Or Pantalla = "CREDITODEBITO" Then
                    If ItemsIngresos.Rows(0)("idMaterial") = "" Then
                        oIdMaterialConsuman = "NULL"
                    Else
                        oIdMaterialConsuman = FormatoSQL(ItemsIngresos.Rows(0)("idMaterial"))
                    End If
                    CadenaSQL = "insert into ComprobantesOrdenes(NroInterno, NroIngreso, CodInsumo, Cantidad, Precio, DescInsumo, Total, CCosto, codautoriza, Iva, Gravado, Exento,idMaterial) values (" & NuevoComprobantePrincipal & "," & ItemsIngresos.Rows(0)("nroingreso") & "," & ItemsIngresos.Rows(0)("codInsumo") & "," & FormatoSQL(ItemsIngresos.Rows(0)("cantidad") & "," & FormatoSQL(Trim(ItemsIngresos.Rows(0)("precio"))) & ",'" & Replace(Trim(FormatoSQL(Left(ItemsIngresos.Rows(0)("descinsumo"), 250))), "'", "") & "'," & FormatoSQL(ItemsIngresos.Rows(0)("total")) & ", " & ItemsIngresos.Rows(0)("cc") & ", " & tipoAutoriza & " , " & oiva & " , " & oGravado & ", " & oExento & "," & oIdMaterialConsuman & ")")
                Else
                    CadenaSQL = "insert into ComprobantesOrdenes(NroInterno, NroIngreso, CodInsumo, Cantidad, Precio, DescInsumo, Total, CCosto, codautoriza, Iva, Gravado, Exento) values (" & NuevoComprobantePrincipal & "," & ItemsIngresos.Rows(0)("nroingreso") & "," & ItemsIngresos.Rows(0)("codInsumo") & "," & FormatoSQL(ItemsIngresos.Rows(0)("cantidad") & "," & FormatoSQL(Trim(ItemsIngresos.Rows(0)("precio")) & ",'" & Replace(Trim(FormatoSQL(Left(ItemsIngresos.Rows(0)("descinsumo"), 250))), "'", "") & "'," & FormatoSQL(ItemsIngresos.Rows(0)("total")) & ", " & ItemsIngresos.Rows(0)("cc") & ", " & tipoAutoriza & " , " & oiva & " , " & oGravado & ", " & oExento & ")"))
                End If

                ServidorSQl.InsertTabla(CadenaSQL)


                RstAux = ServidorSQl.GetTabla("select top 1 id from ComprobantesOrdenes order by id desc")
                If RstAux Is Nothing OrElse RstAux.Rows.Count = 0 Then

                    If Pantalla = "PRINCIPAL" Or Pantalla = "CREDITODEBITO" Then

                        If ItemsIngresos.Rows(0)("idMaterial") <> 0 Then
                            CadenaSQL = "UPDATE ComprobanteOrdenesPorDetalleConsuman SET idComprobanteOrdenes = " & RstAux.Rows(0)("ID") & " 
                                            where id = " & RstAuxCons.Rows(0)("ID") & ""
                            ServidorSQl.InsertTabla(CadenaSQL)
                        End If
                    End If
                    Select Case ItemsIngresos.Rows(0)("codInsumo")
                        Case 2030040010001.0#, 2030040010002.0#, 2030040010003.0#, 2030030020001.0#, 2030030020002.0#, 2030030030001.0#, 2030030030002.0#, 2030030030003.0#, 2030050010001.0#, 2030050010002.0#, 2030050010003.0#, 2030050010004.0#
                            'hago el insert del encabezado
                            CadenaSQL = "INSERT INTO PROVEEDORES.DBO.INSUMOSDEGASTOS " &
                       " (codGestion,codMovGestion,impIva,impExento,impOtros,impTotal,codCaja,idgestionorigen) " &
                       " VALUES (2 ,'" & Grupo & "', " & FormatoSQL(comprobante.IvaProd) & "," & FormatoSQL(comprobante.ImporteNoImp) & "," & FormatoSQL(CDbl(comprobante.PercepGan) + CDbl(comprobante.PercepIva) + CDbl(comprobante.TotalPercepIB)) & ", " & FormatoSQL(comprobante.TotalComp) & ", 0," & NuevoComprobantePrincipal & ")"
                            ServidorSQl.InsertTabla(CadenaSQL)
                            'obteng la clave generada
                            rec = ServidorSQl.GetTabla("select top 1 coddetalle from PROVEEDORES.DBO.insumosdegastos order by coddetalle desc")
                            If rec Is Nothing OrElse rec.Rows.Count = 0 Then

                                'hago el insert del detalle de insumos

                                CadenaSQL = "INSERT INTO PROVEEDORES.DBO.INSUMOSDEGASTOSDETALLE " &
                               " (CODDETALLE,codInsumo,cantidad,precio,codCentroCosto) " &
                               " VALUES (" & rec.Rows(0)("coddetalle") & " ," & ItemsIngresos.Rows(0)("codInsumo") & " ," & FormatoSQL(ItemsIngresos.Rows(0)("cantidad")) & "," & FormatoSQL(Trim(ItemsIngresos.Rows(0)("precio"))) & "," & Val(ItemsIngresos.Rows(0)("cc")) & ")"
                                ServidorSQl.InsertTabla(CadenaSQL)
                            End If
                            rec = ServidorSQl.GetTabla("select top 1 coddetalle,codclave from PROVEEDORES.DBO.INSUMOSDEGASTOSDETALLE order by codclave desc")
                            If rec Is Nothing OrElse rec.Rows.Count = 0 Then


                                'REGISTRA MONEDA, IMPORTE Y COTIZACION DEL GASTO EN MONEDA EXTRANJERA
                                sql = "insert into Proveedores.dbo.GastosMonedaExt(coddetalle,codclavedetalle,codmoneda,importe,cotizacion,tipocomp,nrocomp,codcomprobante,codIngresoProveedores) values (" & rec.Rows(0)("coddetalle") & "," & rec.Rows(0)("codclave") & "," & Val(ItemsIngresos.Rows(0)("codMonedaExp")) & "," & FormatoSQL(ItemsIngresos.Rows(0)("ImporteExp")) & "," & FormatoSQL(comprobante.CotizacionDolar) & "," & Val(ItemsIngresos.Rows(0)("tipoCompExp")) & ",'" & Trim(ItemsIngresos.Rows(0)("numeroCompExp")) & "'," & ItemsIngresos.Rows(0)("codComprobanteexp") & "," & RstAux.Rows(0)("ID") & ")"
                                ServidorSQl.InsertTabla(sql)

                                oCodDetalleExp = rec.Rows(0)("coddetalle")


                            End If
                        Case 1010120010002.0#, 1010120020001.0#, 1010120020002.0#, 1010120030003.0#, 1010120030004.0#, 1010120030005.0#
                            'importaciones
                            'hago el insert del encabezado
                            CadenaSQL = "INSERT INTO PROVEEDORES.DBO.INSUMOSDEGASTOS " &
                               " (codGestion,codMovGestion,impIva,impExento,impOtros,impTotal,codCaja,idgestionorigen) " &
                               " VALUES (2 ,'" & Grupo & "', " & FormatoSQL(comprobante.IvaProd) & "," & FormatoSQL(comprobante.ImporteNoImp) & "," & FormatoSQL(CDbl(comprobante.PercepGan) + CDbl(comprobante.PercepIva) + CDbl(comprobante.TotalPercepIB)) & ", " & FormatoSQL(comprobante.TotalComp) & ", 0," & NuevoComprobantePrincipal & ")"
                            ServidorSQl.InsertTabla(CadenaSQL)
                            'obteng la clave generada
                            rec = ServidorSQl.GetTabla("select top 1 coddetalle from PROVEEDORES.DBO.insumosdegastos order by coddetalle desc")
                            If rec Is Nothing OrElse rec.Rows.Count = 0 Then

                                'hago el insert del detalle de insumos

                                CadenaSQL = "INSERT INTO PROVEEDORES.DBO.INSUMOSDEGASTOSDETALLE " &
                               " (CODDETALLE,codInsumo,cantidad,precio,codCentroCosto) " &
                               " VALUES (" & rec.Rows(0)("coddetalle") & " ," & ItemsIngresos.Rows(0)("codInsumo") & " ," & FormatoSQL(ItemsIngresos.Rows(0)("cantidad")) & "," & FormatoSQL(Trim(ItemsIngresos.Rows(0)("precio"))) & "," & Val(ItemsIngresos.Rows(0)("cc")) & ")"
                                ServidorSQl.InsertTabla(CadenaSQL)
                            End If
                            rec = ServidorSQl.GetTabla("select top 1 coddetalle,codclave from PROVEEDORES.DBO.INSUMOSDEGASTOSDETALLE order by codclave desc")
                            If rec Is Nothing OrElse rec.Rows.Count = 0 Then

                                'REGISTRA MONEDA, IMPORTE Y COTIZACION DEL GASTO EN MONEDA EXTRANJERA
                                sql = "insert into Proveedores.dbo.GastosMonedaExt(coddetalle,codclavedetalle,codmoneda,importe,cotizacion,tipocomp,nrocomp,codcomprobante,codIngresoProveedores) values (" &
                                        rec.Rows(0)("coddetalle") & "," & rec.Rows(0)("codclave") & "," & Val(ItemsIngresos.Rows(0)("codMonedaExp")) & "," &
                                        FormatoSQL(ItemsIngresos.Rows(0)("ImporteExp")) & "," & FormatoSQL(comprobante.CotizacionDolar) & "," &
                                        Val(ItemsIngresos.Rows(0)("tipoCompExp")) & ",'" & Trim(ItemsIngresos.Rows(0)("numeroCompExp")) & "'," &
                                        ItemsIngresos.Rows(0)("codComprobanteexp") & "," & RstAux.Rows(0)("ID") & ")"
                                ServidorSQl.InsertTabla(sql)

                                oCodDetalleExp = rec.Rows(0)("coddetalle")
                            End If
                    End Select

                    sumaTipoAutoriza = sumaTipoAutoriza + tipoAutoriza
                    tipoAutoriza = 0

                    If Pantalla = "PRINCIPAL" Or Pantalla = "CREDITODEBITO" Then
                        If Val(ItemsIngresos.Rows(0)("idMaterial")) <> 0 Then
                            ' Llamar a la función MarcarDetalleAsignadoConsuman de forma síncrona
                            model.PeticionPUTAsync(ItemsIngresos.Rows(0)("nroingreso"), token)
                        End If
                    Else

                    End If
                End If
            Next

            If sumaTipoAutoriza > 0 Then
                ServidorSQl.InsertTabla("Update ComprobantesProveedores set MarcaAcumulado='P' where NroInterno=" & NuevoComprobantePrincipal)
            End If
        End If
        Record = Nothing
        RstAux = Nothing
        RstAuxCons = Nothing
        rec = Nothing
        Exit Function

        NuevoComprobantePrincipal = -1
        Record = Nothing
        RstAux = Nothing
        RstAuxCons = Nothing
        rec = Nothing
        MsgBox("El Comprobante se generó, pero la imagen no se pudo guardar." & vbCrLf & "Modificar este comprobante y scanear nuevamente.", vbExclamation, "Comprobante Proveedor")
    End Function



    Public Function BuscarImagen(ByVal NroInterno As Long, ByRef dt As DataTable) As Integer
        '-----------------------------------------------------
        'Descripción: Obtiene imagen de Factura de Proveedores
        'Parámetros : Por referencia devuelve un recorset
        '             recordset rec por ref.
        'Output     :  -1 Error al buscar datos
        '               0 No se encontraron datos
        '               1 Encontró datos
        '-----------------------------------------------------

        On Error GoTo errores

        dt = ServidorSQl.GetTabla("select * from proveedores.dbo.ComprobantesProveedores where NroInterno = " & NroInterno & "")
        If dt.Rows.Count > 0 Then

            If IsDBNull(dt.Rows(0)("MesImputacion")) Then
                If dt.Rows(0)("TipoGrupo") = 1 Or dt.Rows(0)("TipoGrupo") = 3 Or dt.Rows(0)("TipoGrupo") = 5 Then
                    BuscarImagen = 1
                Else
                    BuscarImagen = 2
                End If
            Else
                BuscarImagen = 1
            End If
        Else
            BuscarImagen = 0
        End If
        Exit Function

errores:
        BuscarImagen = -1
    End Function


    Public Function NuevoProveedorCAI(ByRef dt As DataTable, ByVal NroProveedor As Long, ByVal CAI As String, ByVal FechaVto As Date, ByVal Tipocomp As Integer, ByVal DescCOmp As Integer) As Long

        Dim CadenaSql As String = "Insert into Proveedores.dbo.ProveedorCAI(NroProveedor,CAI,FechaVto,TipoComp,DescComp) values (" & NroProveedor & ",'" & Left(CAI, 14) & "','" & FechaVto & "'," & Tipocomp & "," & DescCOmp & ")"
        NuevoProveedorCAI = ServidorSQl.InsertTabla(CadenaSql)
        dt = ServidorSQl.GetTabla("Select * from Proveedores.dbo.ProveedorCAI where NroProveedor=" & NroProveedor)
        NuevoProveedorCAI = 1
        Exit Function
errores:
        NuevoProveedorCAI = -1
    End Function

    Public Function NuevaCondicionPago(ByRef tabla As DataTable, ByRef Descripcion As String) As Long
        'Descripción: guarda una nueva condición de pago
        '             para los Comprobantes
        'Parámetros : Descripción (string *30 max.)
        'Output     : 1 se guardó exitosamente
        '            -1 Error al guardar.
        On Error GoTo errores
        Dim CadenaSql As String = "Insert into Proveedores.dbo.CondicionPagoComprobantes(descripcion) values ('" & Left(Descripcion, 30) & "')"
        NuevaCondicionPago = ServidorSQl.InsertTabla(CadenaSql)
        tabla = ServidorSQl.GetTabla("Select * from Proveedores.dbo.CondicionPagoComprobantes")
        NuevaCondicionPago = 1
        Exit Function
errores:
        NuevaCondicionPago = -1
    End Function

    Public Function FormatoSQL(Cadena As String) As String
        FormatoSQL = Replace(Trim(Cadena), ",", ".")
    End Function
End Class
