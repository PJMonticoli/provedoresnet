Imports ClasesGlobal
Module ModuloGrillas
#Region "FRMPRINCIPAL"
    Public Sub ConfigurarEdicionColumnas(ByRef dgvListado As DataGridView)
        ' Habilite la edición solo en las columnas 3, 4 y 5
        For Each columna As DataGridViewColumn In dgvListado.Columns
            columna.ReadOnly = True
        Next
    End Sub
    Public Sub InicializarGrilla(ByRef dgvlistado As DataGridView, ByRef dgvExportacion As DataGridView)

        ' *****************************************
        ' GRILLA DE INGRESOS DE INSUMOS
        ' *****************************************
        InicializarGrillaExp(dgvExportacion)
        With dgvlistado
            .Rows.Clear()

            ' AllowEdit property is not directly available in DataGridView, use ReadOnly property instead
            .ReadOnly = False

            .ColumnCount = 11
            .Columns(0).HeaderText = "N° Ingreso"
            .Columns(0).Width = 85
            .Columns(0).DisplayIndex = 0

            .Columns(1).HeaderText = "Cod.Insumo"
            .Columns(1).Width = 135
            .Columns(1).DisplayIndex = 1

            .Columns(2).HeaderText = "Descripción"
            .Columns(2).Width = 210
            .Columns(2).DisplayIndex = 2

            .Columns(3).HeaderText = "Cantidad"
            .Columns(3).Width = 88
            .Columns(3).DisplayIndex = 3


            .Columns(4).HeaderText = "Precio"
            .Columns(4).Width = 80
            .Columns(4).DisplayIndex = 4


            .Columns(5).HeaderText = "Total"
            .Columns(5).ValueType = GetType(Decimal)
            .Columns(5).Width = 100
            .Columns(5).DisplayIndex = 5


            .Columns(6).HeaderText = "C.C."
            .Columns(6).Width = 60
            .Columns(6).DisplayIndex = 6
            .Columns(6).DefaultCellStyle.Format = "###"

            ' Operacion exportacion
            .Columns(7).HeaderText = "O.E."
            .Columns(7).Width = 50
            .Columns(7).DisplayIndex = 7
            .Columns(7).DefaultCellStyle.Font = New Font("Wingdings", 10)
            .Columns(7).DefaultCellStyle.ForeColor = Color.Red
            .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(7).ReadOnly = True
            For i As Integer = 0 To dgvlistado.Rows.Count - 1
                dgvlistado.Rows(i).Cells(7).Style.Font = New Font("Wingdings", 10)

            Next
            .Columns(8).HeaderText = "L.Entrega"
            .Columns(8).Width = 0
            .Columns(8).DisplayIndex = 8
            .Columns(8).Visible = False

            .Columns(9).HeaderText = "idMaterial"
            .Columns(9).Width = 0
            .Columns(9).DisplayIndex = 9
            .Columns(9).Visible = False

            .Columns(10).HeaderText = "N.Solic.Prov."
            .Columns(10).Width = 0
            .Columns(10).DisplayIndex = 10
            .Columns(10).Visible = False

            Dim botonModificar As New DataGridViewButtonColumn()
            With botonModificar
                .Name = "btnAccion"
                .HeaderText = "Acción"
                .UseColumnTextForButtonValue = True
                .HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                .Visible = True
            End With
            .Columns.Add(botonModificar)

            ' Configuración de la columna ELIMINAR (columna 12)
            Dim botonEliminar As New DataGridViewButtonColumn()
            With botonEliminar
                .Name = "btnEliminar"
                .HeaderText = ""
                .UseColumnTextForButtonValue = True
                .Visible = True
            End With
            .Columns.Add(botonEliminar)

            For Each col As DataGridViewColumn In dgvlistado.Columns
                If col.Name = "btnAccion" OrElse col.Name = "btnEliminar" Then
                    col.Width = 48
                End If
            Next
            .ReadOnly = True.ToString
            .ColumnHeadersHeight = 30
            .AllowUserToResizeRows = False
            .RowCount = 0
            .AllowUserToResizeRows = False ' Deshabilitar la modificación del tamaño de las filas
            .AllowUserToResizeColumns = False ' Deshabilitar la modificación del tamaño de las columnas
            .MultiSelect = True

            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            ' Ajustar la altura de la fila de encabezado (fila de títulos)
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True ' Permite que los encabezados se muestren en varias líneas
        End With
    End Sub
    Public Sub InicializarGrillaExp(ByRef dgvExportacion As DataGridView)
        With dgvExportacion
            .Columns.Clear()
            .Rows.Clear()

            ' Add columns
            .Columns.Add("CodComprobanteExp", "CodComprobanteExp")
            .Columns(0).Visible = False

            .Columns.Add("CodMonedaExp", "CodMonedaExp")
            .Columns(1).Visible = False

            .Columns.Add("TipoCompExp", "TipoCompExp")
            .Columns(2).Visible = False

            .Columns.Add("NumeroCompExp", "NumeroCompExp")
            .Columns(3).Visible = False

            .Columns.Add("Importe", "Importe")
            .Columns(4).Visible = False

            .Columns.Add("CodRowGrilla", "CodRowGrilla")
            .Columns(5).Visible = False
            .ReadOnly = True.ToString
            .ColumnHeadersHeight = 30
            .AllowUserToResizeRows = False ' Deshabilitar la modificación del tamaño de las filas
            .AllowUserToResizeColumns = False ' Deshabilitar la modificación del tamaño de las columnas
            .MultiSelect = True
            .EditMode = DataGridViewEditMode.EditOnEnter
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            ' Ajustar la altura de la fila de encabezado (fila de títulos)
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True ' Permite que los encabezados se muestren en varias líneas
            ' Clear any existing rows
            .Rows.Clear()
        End With
    End Sub
    Public Sub InicializarGrillaOrdenCarga(ByRef dgvOrdenDeCarga As DataGridView)
        With dgvOrdenDeCarga
            .Rows.Clear()
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = True
            .ReadOnly = False
            .ColumnCount = 1

            .Columns(0).HeaderText = "Orden Carga"
            .Columns(0).Width = 105
            .Columns(0).DisplayIndex = 0
            .ReadOnly = True.ToString
            .ColumnHeadersHeight = 30
            .AllowUserToResizeRows = False ' Deshabilitar la modificación del tamaño de las filas
            .AllowUserToResizeColumns = False ' Deshabilitar la modificación del tamaño de las columnas
            .MultiSelect = True
            .EditMode = DataGridViewEditMode.EditOnEnter
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            ' Ajustar la altura de la fila de encabezado (fila de títulos)
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True ' Permite que los encabezados se muestren en varias líneas
            .RowCount = 0
        End With
    End Sub

    Public Sub InicializarGrillaParteSalida(ByRef dgvOrdendeCarga As DataGridView)
        With dgvOrdendeCarga
            .Rows.Clear()
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = True
            .ReadOnly = False
            .ColumnCount = 2

            .Columns(0).HeaderText = "Parte Salida"
            .Columns(0).Width = 105
            .Columns(0).DisplayIndex = 0

            .Columns(1).HeaderText = "Valor"
            .Columns(1).Width = 105
            .Columns(1).DisplayIndex = 1
            '.ReadOnly = True.ToString
            .ColumnHeadersHeight = 30
            .AllowUserToResizeRows = False ' Deshabilitar la modificación del tamaño de las filas
            .AllowUserToResizeColumns = False ' Deshabilitar la modificación del tamaño de las columnas
            .MultiSelect = True
            .EditMode = DataGridViewEditMode.EditOnEnter
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            ' Ajustar la altura de la fila de encabezado (fila de títulos)
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True ' Permite que los encabezados se muestren en varias líneas
        End With
    End Sub

    Public Sub InicializarGrillaIB(ByRef dgvIb As DataGridView)
        '*****************************************
        ' GRILLA DE DETALLE DE PERCEPCIONES DE I.B
        '*****************************************

        With dgvIb
            .Columns.Clear()
            .Rows.Clear()

            ' Configuración de la DataGridView
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeRows = False
            .MultiSelect = False

            ' Definición de las columnas
            .Columns.Add("DescProvincia", "DescProvincia")
            .Columns.Add("BaseImponible", "Base Imponible")
            .Columns.Add("Percepcion", "Percepción")
            .Columns.Add("CodProvincia", "CodProvincia")
            .Columns("CodProvincia").Visible = False

            ' Ajuste de las propiedades de las columnas
            .Columns("DescProvincia").Width = 115
            .Columns("BaseImponible").Width = 122
            .Columns("Percepcion").Width = 105
            ' La columna CodProvincia se mantiene oculta
            .Columns("CodProvincia").Width = 150

            .Columns("DescProvincia").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns("BaseImponible").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("Percepcion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .ReadOnly = True.ToString
            .ColumnHeadersHeight = 30
            .AllowUserToResizeRows = False ' Deshabilitar la modificación del tamaño de las filas
            .AllowUserToResizeColumns = False ' Deshabilitar la modificación del tamaño de las columnas
            .MultiSelect = True
            .EditMode = DataGridViewEditMode.EditOnEnter
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            ' Ajustar la altura de la fila de encabezado (fila de títulos)
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True ' Permite que los encabezados se muestren en varias líneas
        End With
    End Sub

    Public Sub formatearcolumna7(ByRef dgvlistado As DataGridView)
        For i As Integer = 0 To dgvlistado.Rows.Count - 1

            Select Case CStr(dgvlistado.Rows(i).Cells(1).Value).Replace(".", "")
            ' Tu lista de códigos de insumos de exportación
                Case "2030040010001", "2030040010002", "2030040010003", "2030030020001", "2030030020002", "2030030030001", "2030030030002", "2030030030003", "2030050010001", "2030050010002", "2030050010003", "2030050010004", "3020010010002", "1010120010002", "1010120020001", "1010120020002", "1010120030003", "1010120030004", "1010120030005"
                    'dgvListado.Rows(i).Cells(7).Style.Font = New Font("Wingdings", 10)
                    'dgvListado.Rows(i).Cells(7).Style.ForeColor = Color.Green
                    If VariablesGlobales.banderaOE = False Then
                        dgvlistado.Rows(i).Cells(7).Style.Font = New Font("Wingdings", 10)
                        dgvlistado.Rows(i).Cells(7).Style.ForeColor = Color.Red
                    Else
                        dgvlistado.Rows(i).Cells(7).Style.Font = New Font("Wingdings", 10)
                        dgvlistado.Rows(i).Cells(7).Style.ForeColor = Color.Green
                    End If
                Case Else
                    dgvlistado.Rows(i).Cells(7).Style.Font = New Font("Wingdings", 10)
                    dgvlistado.Rows(i).Cells(7).Style.ForeColor = Color.Red
            End Select
        Next
    End Sub

#End Region
#Region "FrmCC"
    Public Sub InicializarGrillaCC(ByRef dgvProveedores As DataGridView)
        With dgvProveedores
            .Rows.Clear()
            .Columns.Clear()
            .ColumnCount = 5
            .RowCount = 2
            .RowCount = 1
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .Columns(0).HeaderText = "CODIGO"
            .Columns(1).HeaderText = "DESCRIPCION"
            .Columns(0).Width = 100
            .Columns(1).Width = 100
            .ReadOnly = True.ToString
            .ColumnHeadersHeight = 40
            .AllowUserToResizeRows = False
        End With
    End Sub

#End Region
#Region "FrmBuscarComprobante"
    Public Sub InicializarGrillaComprobante(ByRef dgvListadoComprobante As DataGridView)
        ' Configurar el control DataGridView
        With dgvListadoComprobante
            .ColumnCount = 4
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeRows = False
            .AllowUserToResizeColumns = True

            ' Agregar las columnas y configurar sus nombres
            .Columns(0).Name = "Razón Social"
            .Columns(1).Name = "N° Comprobante"
            .Columns(2).Name = "N° Interno"
            .Columns(3).Name = "Fecha Carga"

            ' Configurar el ancho de las columnas
            .Columns(0).Width = 130
            .Columns(1).Width = 120
            .Columns(2).Width = 100
            .Columns(3).Width = 255

            ' Configurar la alineación de las columnas
            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            .ReadOnly = True.ToString
            .AllowUserToResizeRows = False
            .ColumnHeadersHeight = 40
            ' Otras configuraciones según sea necesario
        End With
    End Sub
#End Region
#Region "FrmBuscarInsumos"
    Public Sub InicializarGrillaInsumos(ByRef dgvListadoInsumo As DataGridView)
        With dgvListadoInsumo
            .ColumnCount = 2
            .Columns(0).Frozen = False
            .RowCount = 2
            .Rows(0).Frozen = True
            .Rows(1).Frozen = False
            .AllowUserToOrderColumns = False
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect

            .Columns(0).HeaderText = "Cod.Insumo"
            .Columns(1).HeaderText = "Descripción"
            .Columns(0).Width = 160
            .Columns(1).Width = 485
            .ColumnHeadersHeight = 40
            .AllowUserToResizeRows = False
            .ReadOnly = True
        End With
    End Sub
#End Region
#Region "FrmBuscarProveedor"
    Public Sub InicializarGrillaProveedor(ByRef dgvProveedores As DataGridView)
        With dgvProveedores
            .Rows.Clear()
            .Columns.Clear()
            .ColumnCount = 5
            .RowCount = 2
            .RowCount = 1
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .Columns(0).HeaderText = "Razón Social"
            .Columns(1).HeaderText = "N° Proveedor"
            .Columns(2).HeaderText = "Direccion"
            .Columns(3).HeaderText = "Localidad"
            .Columns(4).HeaderText = "ConvMulti"
            .Columns(0).Width = 100
            .Columns(1).Width = 100
            .Columns(2).Visible = False
            .Columns(3).Visible = False
            .Columns(4).Visible = False
            .ReadOnly = True.ToString
            .ColumnHeadersHeight = 40
            .AllowUserToResizeRows = False
        End With
    End Sub

#End Region
#Region "FrmOperaciones"
    Public Sub InicializarGrillaOperaciones(ByRef dgvListado As DataGridView)
        ' Agrega las columnas al DataGridView
        Dim seleccionColumn As New DataGridViewCheckBoxColumn()
        seleccionColumn.Name = "Seleccion"
        seleccionColumn.HeaderText = "Seleccion"
        dgvListado.Columns.Add(seleccionColumn)
        'DgvListado.Columns.Add("Seleccion", "Seleccion")
        dgvListado.Columns.Add("NroInterno", "NroInterno")
        dgvListado.Columns.Add("InsumoDescripcion", "Insumo-Descripcion")
        dgvListado.Columns.Add("Cantidad", "Cantidad")
        dgvListado.Columns.Add("Precio", "Precio")
        dgvListado.Columns.Add("Total", "Total")
        dgvListado.ReadOnly = False
        dgvListado.Columns("Seleccion").ReadOnly = False
        dgvListado.Columns("NroInterno").ReadOnly = True
        dgvListado.Columns("InsumoDescripcion").ReadOnly = True
        dgvListado.Columns("Cantidad").ReadOnly = True
        dgvListado.Columns("Precio").ReadOnly = True
        dgvListado.Columns("Total").ReadOnly = True

        dgvListado.AllowUserToResizeRows = False
        dgvListado.ColumnHeadersHeight = 30

        dgvListado.AllowUserToResizeRows = False ' Deshabilitar la modificación del tamaño de las filas
        dgvListado.AllowUserToResizeColumns = False ' Deshabilitar la modificación del tamaño de las columnas
        dgvListado.MultiSelect = True
        dgvListado.EditMode = DataGridViewEditMode.EditOnEnter
        dgvListado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        ' Ajustar la altura de la fila de encabezado (fila de títulos)
        dgvListado.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        dgvListado.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True ' Permite que los encabezados se muestren en varias líneas
        ' Configura la columna de selección como una columna de casillas de verificación

        ' Configura otras propiedades según sea necesario
        dgvListado.AutoGenerateColumns = False ' Desactiva la generación automática de columnas basada en la fuente de datos
        dgvListado.AllowUserToAddRows = False ' Desactiva la fila de "nueva fila" al final del DataGridView
    End Sub
#End Region

End Module
