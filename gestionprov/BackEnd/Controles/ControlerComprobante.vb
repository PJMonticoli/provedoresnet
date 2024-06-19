Imports System.Data.SqlClient

Public Class ControlerComprobante
    Inherits ServidorSQl

    Public Function PermitirModificarComprobante(ByVal NroInterno As Double) As Long
        Dim parametros As SqlParameter() = {New SqlParameter("@NroInterno", NroInterno)}
        Dim query As String = "SELECT mesimputacion, codestadopago, NroProveedor FROM ComprobantesProveedores WHERE nrointerno = @NroInterno"

        Dim tabla As DataTable = GetTablaParam(query, parametros)

        If tabla Is Nothing Then
            Return -1 ' Error al buscar comprobante
        ElseIf tabla.Rows.Count = 0 Then
            Return 0 ' No está imputado a un mes cerrado, se puede modificar
        Else
            If Not IsDBNull(tabla.Rows(0)("mesimputacion")) Then
                Return 1 ' Está imputado a un mes cerrado, NO se puede modificar
            Else
                Select Case CInt(tabla.Rows(0)("codestadopago"))
                    Case 2, 4, 1, 3, 5
                        Return 0 ' No está imputado a un mes cerrado, se puede modificar
                End Select
            End If
        End If

        Return -1 ' Error al evaluar el comprobante
    End Function


    Public Function Modificar(NroInterno As Long, Proveedor As Long, DescCOmp As Long, Tipocomp As Long, NroComp As String, FechaComp As String,
                              FechaCarga As String, FechaVtoComp As String, CondPago As Long, Observacion As String, IvaProd As String,
                              ImporteProd As String, PercepIva As String, PercepGan As String, TotalPercepIB As String, ImporteNoImp As String,
                              totalComp As String, ByVal CAI As String, ByVal VtoCAI As Date, ByVal CodBarra As String, ItemsIB As DataTable,
                              ItemsIngresos As DataTable, ByRef RstOC As DataTable, RstPS As DataTable, ByVal cotizacionDolar As String,
                              FechaIngresoProv As String, ByVal Iva21 As String, ByVal Iva105 As String, ByVal Iva27 As String,
                              Iva25 As String, ByVal Imp21 As String, ByVal Imp105 As String, ByVal Imp27 As String, Imp25 As String,
                              ChkPorCuentaTercero As Integer) As Long
        Dim sql As String
        Dim Cotiza As String
        Dim recTipoCompAnt As New DataTable
        Dim Record As New DataTable
        Dim RstAux As New DataTable
        Dim rec As New DataTable
        Dim tipoAutoriza As Integer = 0
        Dim sumaTipoAutoriza As Integer
        Dim Grupo As Integer
        Dim CadenaSQL As String
        sumaTipoAutoriza = 0

        ''colocar aca los tipos de grupo
        Select Case DescCOmp
            Case 1
                Grupo = 1
            Case 2
                Grupo = 2
   'debitos
            Case 3, 4, 5, 6, 13, 14, 17, 19 'debitos
                ''es Guma
                If Len(CStr(NroComp)) = 12 And Left(NroComp, 4) = 4000 Then
                    Grupo = 6
                Else
                    Grupo = 5
                End If
   'creditos
            Case 7, 8, 9, 10, 11, 12, 18, 20
                ''es Guma
                If Len(CStr(NroComp)) = 12 And Left(NroComp, 4) = 4000 Then
                    Grupo = 4
                Else
                    Grupo = 3
                End If
            Case 15
                Grupo = 7
            Case 16
                Grupo = 8
            Case 23, 24
                Grupo = 11
        End Select
        sql = "select desccomp,marcaacumulado from comprobantesproveedores where nrointerno=" & NroInterno
        recTipoCompAnt = ServidorSQl.GetTabla(sql)
        If recTipoCompAnt IsNot Nothing Then

            sql = "UPDATE ComprobantesProveedores set CotizacionDolar=" & Replace(cotizacionDolar, ",", ".") & ", TipoGrupo=" & Grupo & ", NroProveedor=" & Proveedor & ",DescComp=" & DescCOmp & ",TipoComp= " & Tipocomp & ",NroComp='" & NroComp & "',FechaComp='" & FechaComp & "',FechaCarga='" & FechaCarga & "',FechaModificacion='" & Now & "',FechaVto='" & FechaVtoComp & "',CondicionPago=" & CondPago & ",Observacion='" & Observacion & "',IvaProd=" & IvaProd & ",ImporteProd=" & ImporteProd & ",PercepIva=" & PercepIva & ",PercepGan=" & PercepGan & ",TotalPercepIB=" & TotalPercepIB & ",ImporteNoImp=" & ImporteNoImp & ",TotalComprobante=" & totalComp & ",cai='" & Left(CAI, 14) & "',vtocai= '" & VtoCAI & "',codbarra='" & Left(CodBarra, 40) & "', FechaIngresoProveedores ='" & FechaIngresoProv & "', " _
            & " Iva21 = " & Trim(Iva21) & ", " _
            & " Iva105 = " & Trim(Iva105) & ", " _
            & " Iva27 = " & Trim(Iva27) & ", " _
            & " Imp21 = " & Trim(Imp21) & ", " _
            & " Imp105 = " & Trim(Imp105) & ", " _
            & " Imp27 = " & Trim(Imp27) & ", " _
            & " Imp25 = " & Trim(Imp25) & ", " _
            & " porcuentadetercero = " & ChkPorCuentaTercero & " " _
            & " WHERE NroInterno=" & NroInterno

            If ServidorSQl.InsertTabla(sql) = -1 Then
                MsgBox("Error al intentar actualizar Comprobantes Proveedores")
                Exit Function
            Else
                'Modifico Ordenes de Carga
                If RstOC.Rows.Count > 0 Then
                    sql = "DELETE ComprobanteXOrdenCarga WHERE NroInterno = " & NroInterno
                    ServidorSQl.InsertTabla(sql)
                    For Each row As DataRow In RstOC.Rows
                        If Not IsDBNull(row("NroOrdenCarga")) AndAlso (row("NroOrdenCarga") <> 0 OrElse row("NroOrdenCarga").ToString() <> "") Then
                            sql = "INSERT INTO ComprobanteXOrdenCarga (NroComp, NroInterno, NroOrdenCarga, Observacion, Fecha, NroProveedor) VALUES (" & NroComp & ", " & NroInterno & ", " & row("NroOrdenCarga") & " ,'' , '" & Format(Now, "dd/MM/yyyy") & "', " & Proveedor & ")"
                            ServidorSQl.InsertTabla(sql)
                        End If
                    Next
                End If
            End If


            If RstPS.Rows.Count > 0 Then
                ' Delete existing records related to NroInterno
                sql = "DELETE ComprobanteXParteSalida WHERE NroInterno = " & NroInterno
                ServidorSQl.GetTabla(sql)

                ' Insert Partes Salida
                For Each row As DataRow In RstPS.Rows
                    If Not IsDBNull(row("NroParteSalida")) AndAlso (row("NroParteSalida") <> 0 OrElse row("NroParteSalida").ToString() <> "") Then
                        sql = "INSERT INTO ComprobanteXParteSalida (NroInterno, NroParteSalida, NroProveedor, valor) VALUES (" & NroInterno & ", " & row("NroParteSalida") & "," & Proveedor & ", " & Replace(row("Valor"), ",", ".") & " )"
                        ServidorSQl.InsertTabla(sql)
                    End If
                Next
            End If


            '   Borro el detalle de Percepciones de I.B.
            'Delete existing records related to NroInterno
            ServidorSQl.InsertTabla("DELETE FROM ComprobantesPercepcionesIB WHERE NroInterno=" & NroInterno)

            ' Insert new details
            For Each row As DataRow In ItemsIB.Rows
                ServidorSQl.InsertTabla("INSERT INTO ComprobantesPercepcionesIB (NroInterno, Provincia, BaseImponible, Percepcion) VALUES (" & NroInterno & ", " & row("Provincia") & ", " & FormatoSQL(Trim(row("BaseImponible"))) & ", " & FormatoSQL(Trim(row("Percepcion"))) & ")")
            Next


            'Borro Detalle de ComprobantesOrdenes
            rec = ServidorSQl.GetTabla("SELECT coddetalle FROM PROVEEDORES.DBO.insumosdegastos WHERE codgestion = 2 AND idgestionorigen = " & NroInterno)

            If rec.Rows.Count > 0 Then
                For Each row As DataRow In rec.Rows
                    ServidorSQl.InsertTabla("DELETE FROM PROVEEDORES.DBO.insumosdegastos WHERE coddetalle = " & row("coddetalle"))
                    ServidorSQl.InsertTabla("DELETE FROM PROVEEDORES.DBO.insumosdegastosdetalle WHERE coddetalle = " & row("coddetalle"))
                    ServidorSQl.InsertTabla("DELETE FROM PROVEEDORES.DBO.GastosMonedaExt WHERE coddetalle = " & row("coddetalle"))
                Next
            End If

            rec = Nothing


            ''Ingreso el detalle de nuevo
            If ItemsIngresos IsNot Nothing AndAlso ItemsIngresos.Rows.Count > 0 Then
                For Each row As DataRow In ItemsIngresos.Rows
                    tipoAutoriza = 0
                    If ItemsIngresos.Rows(0)("nroingreso") > 0 Then
                        If DescCOmp = 1 Then
                            'SI ES UNA FACTURA ENTRA A CONTROLAR DIFERENCIAS
                            tipoAutoriza = 0
                            sql = "SELECT OcomDetalle.Preciopactado, DetalleIngresoInsumo.CantidadReal, DetalleIngresoInsumo.Cantefectiva,OrdenCompra.CondPago, OrdenCompra.codmoneda FROM NrosIngresoNrosOC INNER JOIN DetalleIngresoInsumo ON NrosIngresoNrosOC.CodInsumo = DetalleIngresoInsumo.CodInsumo AND NrosIngresoNrosOC.NroIngreso = DetalleIngresoInsumo.NroIngreso INNER JOIN OcomDetalle ON NrosIngresoNrosOC.NroOC = OcomDetalle.codOrdenCompra AND NrosIngresoNrosOC.CodInsumo = OcomDetalle.codInsumo INNER JOIN OrdenCompra ON OcomDetalle.codOrdenCompra = OrdenCompra.codOrdenCompra Where NrosIngresoNrosOC.NroIngreso =" & ItemsIngresos.Rows(0)("nroingreso")
                            Record = ServidorSQl.GetTabla(sql)
                            If Record IsNot Nothing AndAlso Record.Rows.Count > 0 Then
                                If Math.Abs(Convert.ToDouble(ItemsIngresos.Rows(0)("precio")) - Convert.ToDouble(Record.Rows(0)("Preciopactado"))) > 0.01 Then
                                    If Convert.ToInt32(Record.Rows(0)("codMoneda")) = 2 Then
                                        ' Check if it's in dollars, then check the price approximately
                                        Do Until Val(Cotiza) <> 0
                                            Cotiza = cotizacionDolar 'InputBox("Ingrese la cotización del dólar para el comprobante que esta por guardar", "Cotización de Dólar Para la factura")
                                            If Val(Cotiza) <> 0 Then
                                                If IsNumeric(Cotiza) Then
                                                Else
                                                    MsgBox("No se introdujo un valor válido para la cotización, la operación de registro de las modificaciones será cancelada.", vbCritical, "Grabando Nuevo Comprobante")
                                                    recTipoCompAnt = Nothing
                                                    Record = Nothing
                                                    Exit Function
                                                End If
                                            End If
                                        Loop

                                        If Math.Abs(Convert.ToDouble(ItemsIngresos.Rows(0)("precio")) - (Convert.ToDouble(Record.Rows(0)("Preciopactado")) * Val(Cotiza))) > 0.01 Then
                                            If Convert.ToInt32(recTipoCompAnt.Rows(0)("DescCOmp")) = 2 And DescCOmp = 1 Then
                                                ServidorSQl.InsertTabla("Update ComprobantesProveedores set MarcaAcumulado='P' where NroInterno=" & NroInterno)
                                            End If
                                            tipoAutoriza = 1
                                        End If
                                    Else
                                        If Convert.ToInt32(recTipoCompAnt.Rows(0)("DescCOmp")) = 2 And DescCOmp = 1 Then
                                            ServidorSQl.InsertTabla("Update ComprobantesProveedores set MarcaAcumulado='P' where nrointerno=" & NroInterno)
                                        End If
                                        tipoAutoriza = 1
                                    End If
                                End If

                                If (Convert.ToInt32(CondPago) <> Convert.ToInt32(Record.Rows(0)("CondPago"))) Then
                                    If Convert.ToInt32(recTipoCompAnt.Rows(0)("DescCOmp")) = 2 And DescCOmp = 1 Then
                                        ServidorSQl.InsertTabla("Update ComprobantesProveedores set MarcaAcumulado='P' where nrointerno=" & NroInterno)
                                    End If
                                    tipoAutoriza = tipoAutoriza + 3
                                End If

                                If (Convert.ToDouble(ItemsIngresos.Rows(0)("cantidad")) <> IIf(Convert.ToDouble(Record.Rows(0)("cantefectiva")) = 0 Or Convert.ToDouble(Record.Rows(0)("cantefectiva")) <= 0, Convert.ToDouble(Record.Rows(0)("cantidadreal")), Convert.ToDouble(Record.Rows(0)("cantefectiva")))) Then
                                    If Convert.ToInt32(recTipoCompAnt.Rows(0)("DescCOmp")) = 2 And DescCOmp = 1 Then
                                        ServidorSQl.InsertTabla("Update ComprobantesProveedores set MarcaAcumulado='P' where nrointerno=" & NroInterno)
                                    End If
                                    If tipoAutoriza = 1 Then
                                        'PRECIO+CANTIDAD
                                        tipoAutoriza = 7
                                    Else
                                        'CANTIDAD + ALGO (O NO)
                                        tipoAutoriza = tipoAutoriza + 2
                                    End If
                                End If
                            End If

                        End If
                    End If
                    'INSERTA EL DETALLE  CON EL CODIGO DE AUTORIZACION YA SETEADO
                    If tipoAutoriza > 0 Then
                        ServidorSQl.InsertTabla("Update ComprobantesProveedores set Observacion= 'ACTUALIZACION DE REM. A FACT.' where nrointerno=" & NroInterno)
                    End If


                    sumaTipoAutoriza = sumaTipoAutoriza + tipoAutoriza
                    ServidorSQl.InsertTabla("insert into ComprobantesOrdenes(NroInterno,NroIngreso,CodInsumo,Cantidad,Precio,DescInsumo,Total,Ccosto,codautoriza) values (" & NroInterno & "," & ItemsIngresos.Rows(0)("nroingreso") & "," & ItemsIngresos.Rows(0)("codInsumo") & "," & FormatoSQL(ItemsIngresos.Rows(0)("cantidad")) & "," & FormatoSQL(Trim(ItemsIngresos.Rows(0)("precio"))) & ",'" & Trim(Left(stringSQL(ItemsIngresos.Rows(0)("descinsumo")), 50)) & "'," & FormatoSQL(ItemsIngresos.Rows(0)("total")) & "," & ItemsIngresos.Rows(0)("cc") & "," & tipoAutoriza & ")")


                    'obteng la clave del ingreso
                    RstAux = ServidorSQl.GetTabla("select top 1 id from ComprobantesOrdenes order by id desc")
                    If RstAux Is Nothing OrElse RstAux.Rows.Count = 0 Then

                        ' me fijo si corresponde ingresar el dato como gasto de exportaciones/importaciones para los códigos especificados
                        Select Case ItemsIngresos.Rows(0)("codInsumo")
                            Case 2030040010001.0#, 2030040010002.0#, 2030040010003.0#, 2030030020001.0#, 2030030020002.0#, 2030030030001.0#, 2030030030002.0#, 2030030030003.0#, 2030050010001.0#, 2030050010002.0#, 2030050010003.0#, 2030050010004.0#

                                'hago el insert del encabezado
                                CadenaSQL = "INSERT INTO PROVEEDORES.DBO.INSUMOSDEGASTOS " &
                                   " (codGestion,codMovGestion,impIva,impExento,impOtros,impTotal,codCaja,idgestionorigen) " &
                                   " VALUES (2 ,'" & Grupo & "', " & FormatoSQL(IvaProd) & "," & FormatoSQL(ImporteNoImp) & "," & FormatoSQL(CDbl(PercepGan) + CDbl(PercepIva) + CDbl(TotalPercepIB)) & ", " & FormatoSQL(totalComp) & ", 0," & NroInterno & ")"
                                ServidorSQl.InsertTabla(CadenaSQL)

                                'obteng la clave generada
                                rec = ServidorSQl.GetTabla("select top 1 coddetalle from PROVEEDORES.DBO.insumosdegastos order by coddetalle desc")
                                If rec Is Nothing OrElse rec.Rows.Count = 0 Then

                                    'hago el insert del detalle de insumos

                                    CadenaSQL = "INSERT INTO PROVEEDORES.DBO.INSUMOSDEGASTOSDETALLE " &
                                   " (CODDETALLE,codInsumo,cantidad,precio,codCentroCosto) " &
                                   " VALUES (" & rec.Rows(0)("coddetalle") & " ," & ItemsIngresos.Rows(0)("codInsumo") & " ," & FormatoSQL(ItemsIngresos.Rows(0)("cantidad")) & "," & FormatoSQL(Trim(ItemsIngresos.Rows(0)("precio"))) & "," & Val(ItemsIngresos.Rows(0)("cc")) & ")"
                                    ServidorSQl.GetTabla(CadenaSQL)
                                End If
                                rec = ServidorSQl.GetTabla("select top 1 coddetalle,codclave from PROVEEDORES.DBO.INSUMOSDEGASTOSDETALLE order by codclave desc")
                                If rec Is Nothing OrElse rec.Rows.Count = 0 Then

                                    'REGISTRA MONEDA, IMPORTE Y COTIZACION DEL GASTO EN MONEDA EXTRANJERA
                                    sql = "insert into Proveedores.dbo.GastosMonedaExt(coddetalle,codclavedetalle,codmoneda,importe,cotizacion,tipocomp,nrocomp,codcomprobante,codIngresoProveedores) values (" & rec.Rows(0)("coddetalle") & "," & rec.Rows(0)("codclave") & "," & Val(ItemsIngresos.Rows(0)("codMonedaExp")) & "," & FormatoSQL(ItemsIngresos.Rows(0)("ImporteExp")) & "," & FormatoSQL(cotizacionDolar) & "," & Val(ItemsIngresos.Rows(0)("tipoCompExp")) & ",'" & Trim(ItemsIngresos.Rows(0)("numeroCompExp")) & "'," & ItemsIngresos.Rows(0)("codComprobanteexp") & "," & RstAux.Rows(0)("ID") & ") "
                                    ServidorSQl.InsertTabla(sql)

                                End If
                            Case 1010120010002.0#, 1010120020001.0#, 1010120020002.0#, 1010120030003.0#, 1010120030004.0#, 1010120030005.0#
                                'importaciones
                                'hago el insert del encabezado
                                CadenaSQL = "INSERT INTO PROVEEDORES.DBO.INSUMOSDEGASTOS " &
                                   " (codGestion,codMovGestion,impIva,impExento,impOtros,impTotal,codCaja,idgestionorigen) " &
                                   " VALUES (2 ,'" & Grupo & "', " & FormatoSQL(IvaProd) & "," & FormatoSQL(ImporteNoImp) & "," & FormatoSQL(CDbl(PercepGan) + CDbl(PercepIva) + CDbl(TotalPercepIB)) & ", " & FormatoSQL(totalComp) & ", 0," & NroInterno & ")"
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
                                    sql = "insert into Proveedores.dbo.GastosMonedaExt(coddetalle,codclavedetalle,codmoneda,importe,cotizacion,tipocomp,nrocomp,codcomprobante,codIngresoProveedores) values (" & rec.Rows(0)("coddetalle") & "," & rec.Rows(0)("codclave") & "," & Val(ItemsIngresos.Rows(0)("codMonedaExp")) & "," & FormatoSQL(ItemsIngresos.Rows(0)("ImporteExp")) & "," & FormatoSQL(cotizacionDolar) & "," & Val(ItemsIngresos.Rows(0)("tipoCompExp")) & ",'" & Trim(ItemsIngresos.Rows(0)("numeroCompExp")) & "'," & ItemsIngresos.Rows(0)("codComprobanteexp") & "," & RstAux.Rows(0)("ID") & ") "
                                    ServidorSQl.InsertTabla(sql)

                                End If
                        End Select
                    End If
                Next
            End If
            If UCase(Trim(recTipoCompAnt.Rows(0)("marcaacumulado"))) = "P" And sumaTipoAutoriza = 0 Then
                ServidorSQl.InsertTabla("Update ComprobantesProveedores set MarcaAcumulado='N' where NroInterno=" & NroInterno)
            End If
        End If
        '    recTipoCompAnt = Nothing
        'Record = Nothing
        'RstAux = Nothing
        'rec = Nothing
        If recTipoCompAnt IsNot Nothing Then recTipoCompAnt.Dispose()
        If Record IsNot Nothing Then Record.Dispose()
        If RstAux IsNot Nothing Then RstAux.Dispose()
        If rec IsNot Nothing Then rec.Dispose()
        Modificar = 1
        Exit Function
        If recTipoCompAnt IsNot Nothing Then recTipoCompAnt.Dispose()
        If Record IsNot Nothing Then Record.Dispose()
        If RstAux IsNot Nothing Then RstAux.Dispose()
        If rec IsNot Nothing Then rec.Dispose()
        'recTipoCompAnt = Nothing
        'Record = Nothing
        'RstAux = Nothing
        'rec = Nothing
        Modificar = -1
    End Function

    Public Function ValidarComprobanteExportacion(ByRef TipoComprobante As Integer, ByRef numero As String) As Long
        Dim rs As New DataTable
        Dim cadsql As String


        Select Case TipoComprobante
            Case 1 'factura
                If IsNumeric(numero) = False Then
                    ValidarComprobanteExportacion = 0
                    Exit Function
                End If
                cadsql = "select codcomprobante from ctasctessql.dbo.comprobante where " &
            " codtipocomprobante = 19 and prefijo = " & Val(Left(numero, 4)) & " and numero = " & Val(Right(numero, 8))
            Case 2 'permiso de embarque
                cadsql = "select codcomprobante from ventas.dbo.datosxfacturaexp  " &
            " where replace(replace(upper(ltrim(rtrim(permisoembarque))),'-',''),'/','') like '" & UCase(Trim(numero)) & "'"
            Case 3 'instr. de cobranza
                cadsql = "select codcomprobante from ventas.dbo.DatosXFacturaDetalle " &
            " where upper(ltrim(rtrim(nroinscobranza))) like '" & UCase(Trim(numero)) & "'"
            Case 4 'Comp. de despacho
                cadsql = "select codcomprobante from ventas.dbo.datosxfacturaexp " &
            " where replace(replace(upper(ltrim(rtrim(permisoembarque))),'-',''),'/','') like '" & UCase(Trim(numero)) & "'"
            Case 5 'Fact. Proforma
                cadsql = "select codcomprobante from ventas.dbo.datosxfacturaexp " &
            " where replace(replace(upper(ltrim(rtrim(proforma))),'-',''),'/','') like '" & UCase(Trim(numero)) & "'"
        End Select

        rs = ServidorSQl.GetTabla(cadsql)

        If rs.Rows.Count > 0 Then
            ValidarComprobanteExportacion = rs.Rows(0)("codComprobante")
        Else
            ValidarComprobanteExportacion = 0
        End If
        Exit Function
        ValidarComprobanteExportacion = -1
    End Function

    Public Function FormatoSQL(Cadena As String) As String
        FormatoSQL = Replace(Trim(Cadena), ",", ".")
    End Function

    Public Function stringSQL(Palabra As String) As String
        stringSQL = Replace(Trim(Palabra), "'", "´")
    End Function
End Class
