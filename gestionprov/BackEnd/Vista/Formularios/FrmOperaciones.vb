Imports System.Runtime.InteropServices
Imports Controles
Imports Modelos
Imports TheArtOfDevHtmlRenderer.Adapters

Public Class FrmOperaciones
    Public NumeroProveedor As Integer
    Public PantallaMadre As String
    Dim rec As New DataTable
    Dim control As New ControlerProveedor
    Private frmPrincipal As FrmPrincipal
    Public frmcreddeb As FrmCreditoDebito


    Sub New(ByRef frm As FrmPrincipal)

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        frmPrincipal = frm
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        If Not HayAlMenosUnCheckBoxSeleccionado() Then
            MsgBox("Debe seleccionar al menos un item de la grilla", vbExclamation, "Advertencia")
            dgvListado.Focus()
            Exit Sub
        End If
        Dim Rst As DataTable = New DataTable()
        ' Configuración de la tabla DataTable
        Rst.Columns.Add("DescInsumo", GetType(String))
        Rst.Columns.Add("NroIngreso", GetType(Double))
        Rst.Columns.Add("CodInsumo", GetType(Long))
        Rst.Columns.Add("Cantidad", GetType(Double))
        Rst.Columns.Add("Precio", GetType(Double))
        Rst.Columns.Add("Total", GetType(Double))
        Rst.Columns.Add("CodCentroCosto", GetType(Double))

        ' Iterar a través de las filas seleccionadas en el DataGridView
        For Each row As DataGridViewRow In dgvListado.Rows
            ' Verificar si la columna "Seleccion" está marcada
            Dim seleccionada As Boolean = Convert.ToBoolean(row.Cells("Seleccion").Value)

            ' Si la fila está seleccionada, buscar en la DataTable "rec" por el NroInterno y agregarla al DataTable "Rst"
            If seleccionada Then
                Dim nroInternoSeleccionado As Integer = Convert.ToInt32(row.Cells("NroInterno").Value)

                ' Buscar la fila correspondiente en la DataTable "rec"
                Dim recRow As DataRow() = rec.Select("NroIngreso = " & nroInternoSeleccionado)

                ' Verificar si se encontró la fila
                If recRow.Length > 0 Then
                    Dim newRow = Rst.NewRow()
                    newRow("NroIngreso") = recRow(0)("nroingreso")
                    newRow("CodInsumo") = recRow(0)("codInsumo")
                    newRow("DescInsumo") = Trim(control.ObtenerDescripcion(recRow(0)("codInsumo")))
                    newRow("CodCentroCosto") = IIf(Trim(control.BuscarCentroCostoXInsumo(recRow(0)("codInsumo"))) = "", 0, Trim(control.BuscarCentroCostoXInsumo(recRow(0)("codInsumo"))))

                    If Not IsDBNull(recRow(0)("ImporteTotal")) Then
                        newRow("Precio") = recRow(0)("Preciopactado")
                        newRow("Total") = recRow(0)("ImporteTotal")
                        newRow("Cantidad") = recRow(0)("cantidad")
                    Else
                        newRow("Precio") = recRow(0)("OC_Precio")
                        newRow("Total") = recRow(0)("oc_total")
                        newRow("Cantidad") = recRow(0)("oc_cant")
                    End If

                    Rst.Rows.Add(newRow)
                End If
            End If
        Next


        ' Lógica para mostrar los datos en la grilla (adaptar según tu entorno y necesidades)
        If PantallaMadre = "CO" Then
            'frmPrincipal.InicializarGrilla()
            For Each row As DataRow In Rst.Rows
                Dim nroIngreso As String = Convert.ToInt32(row("nroingreso")).ToString("000000000")
                Dim codInsumo As String = $"{Mid(row("codInsumo").ToString(), 1, 1)}.{Mid(row("codInsumo").ToString(), 2, 2)}.{Mid(row("codInsumo").ToString(), 4, 3)}.{Mid(row("codInsumo").ToString(), 7, 3)}.{Mid(row("codInsumo").ToString(), 10, 4)}"
                Dim descInsumo As String = Trim(row("descinsumo").ToString())
                Dim cantidad As Double = Convert.ToDouble(row("cantidad"))
                Dim precio As Double = Convert.ToDouble(row("precio"))
                Dim total As Double = Convert.ToDouble(row("total"))
                Dim codCentroCosto As Double = Convert.ToDouble(row("codCentroCosto"))

                ' Construir la cadena de datos
                Dim sdata As String = $"{nroIngreso};{codInsumo};{descInsumo};{cantidad};{precio};{total};{codCentroCosto};u"

                Dim nroIngresoExistente As Boolean = False

                If frmPrincipal.dgvListado.Rows.Count > 0 Then
                    For Each fila As DataGridViewRow In frmPrincipal.dgvListado.Rows
                        ' Obtener el valor de la celda "nroIngreso" de la fila actual
                        Dim valorNroIngreso As String = fila.Cells(0).Value.ToString()

                        ' Verificar si el nroIngreso ya existe en la grilla
                        If valorNroIngreso = nroIngreso Then
                            ' El nroIngreso ya existe, no agregar la nueva fila
                            nroIngresoExistente = True
                            MsgBox("Este ingreso pendiente ya se encuentra en la grilla.", vbInformation, "Atención")
                            Exit For
                        End If
                    Next
                End If

                If Not nroIngresoExistente Then
                    ' Agregar fila a la grilla solo si el nroIngreso no existe
                    frmPrincipal.dgvListado.Rows.Add(sdata.Split(";"))
                End If

            Next

        Else
            frmcreddeb.InicializarGrilla()
            For Each row As DataRow In Rst.Rows
                Dim nroIngreso As String = row("nroingreso").ToString("000000000")
                Dim codInsumo As String = $"{Mid(row("codInsumo").ToString(), 1, 1)}.{Mid(row("codInsumo").ToString(), 2, 2)}.{Mid(row("codInsumo").ToString(), 4, 3)}.{Mid(row("codInsumo").ToString(), 7, 3)}.{Mid(row("codInsumo").ToString(), 10, 4)}"
                Dim descInsumo As String = Trim(row("descinsumo").ToString())
                Dim cantidad As Double = Convert.ToDouble(row("cantidad"))
                Dim precio As Double = Convert.ToDouble(row("precio"))
                Dim total As Double = Convert.ToDouble(row("total"))
                Dim codCentroCosto As Double = Convert.ToDouble(row("codCentroCosto"))

                ' Construir la cadena de datos
                Dim sdata As String = $"{nroIngreso};{codInsumo};{descInsumo};{cantidad};{precio};{total};{codCentroCosto};u"

                ' Agregar fila a la grilla
                frmcreddeb.dgvListado.Rows.Add(sdata.Split(";"))
            Next
        End If
        Me.Close()
    End Sub

    Private Function HayAlMenosUnCheckBoxSeleccionado() As Boolean
        For Each fila As DataGridViewRow In dgvListado.Rows
            ' Asegurarse de que la fila no sea nula y de que la celda del CheckBox existe
            If fila IsNot Nothing AndAlso Not fila.IsNewRow Then
                Dim celdaCheckBox As DataGridViewCheckBoxCell = TryCast(fila.Cells("Seleccion"), DataGridViewCheckBoxCell)
                If celdaCheckBox IsNot Nothing AndAlso Convert.ToBoolean(celdaCheckBox.Value) Then
                    Return True ' Al menos un CheckBox está seleccionado
                End If
            End If
        Next
        Return False ' Ningún CheckBox está seleccionado
    End Function

    Private Function GetCodInsumoFromDescription(description As String) As Long
        ' Suponemos que la estructura es "CodInsumo - DescInsumo"
        Dim parts As String() = description.Split(New String() {" - "}, StringSplitOptions.None)

        If parts.Length > 0 AndAlso Long.TryParse(parts(0).Trim(), Nothing) Then
            Return Convert.ToInt64(parts(0).Trim())
        End If

        Return 0 ' Valor predeterminado si no se encuentra la información esperada o no se puede convertir a Long
    End Function


    Private Function GetDescInsumoFromDescription(description As String) As String
        ' Suponemos que la estructura es "CodInsumo - DescInsumo"
        Dim parts As String() = description.Split(" - ")

        If parts.Length > 1 Then
            Return parts(1)
        End If

        Return String.Empty ' Valor predeterminado si no se encuentra la información esperada
    End Function



    Private Sub FrmOperaciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'LlenarListBox(NumeroProveedor, chkProv)
        ModuloGrillas.InicializarGrillaOperaciones(dgvListado)
        LlenarDataGridView(NumeroProveedor)
    End Sub



    Private Sub LlenarDataGridView(ByRef NroProveedor As Integer)
        Dim tabla As New DataTable
        Dim separador As String
        Dim items As New List(Of ItemLista)()
        separador = Chr(124) & " "

        Try
            control.LlenarListBox(NroProveedor, tabla)
            rec = tabla
            ' Limpia las filas existentes en el DataGridView
            dgvListado.Rows.Clear()

            If tabla Is Nothing OrElse tabla.Rows.Count = 0 Then
                MsgBox("No existen datos para este proveedor.", MsgBoxStyle.Information)
                ' Puedes manejar la activación y visibilidad del botón CAceptar aquí según tus necesidades.
                Exit Sub
            Else
                For Each row As DataRow In tabla.Rows
                    Dim codInsumo As String = row("codInsumo").ToString()

                    ' Asegúrate de que 'separador' sea un carácter único
                    Dim charSeparador As Char = If(String.IsNullOrEmpty(separador), " "c, separador(0))

                    Dim nroIngreso As String = Format(row("nroingreso"), "000000000")
                    Dim insumoDescripcion As String = Strings.Space(1) & codInsumo & " - " & Trim(control.ObtenerDescripcion(codInsumo)) & Strings.Space(5)
                    Dim ocCant As String = If(Not IsDBNull(row("oc_cant")), row("oc_cant").ToString(), "0")
                    Dim ocPrecio As String = If(Not IsDBNull(row("OC_Precio")), Format(row("OC_Precio"), "0.00"), "0.00")
                    Dim ocTotal As String = If(Not IsDBNull(row("oc_total")), Format(row("oc_total"), "0.00"), "0.00")
                    Dim centroCosto As String = row("codCentroCosto").ToString()

                    dgvListado.Rows.Add(False, nroIngreso, insumoDescripcion, ocCant, ocPrecio, ocTotal, centroCosto)
                Next
            End If
        Catch ex As Exception
            MsgBox($"Se ha producido un error: {ex.Message}", MsgBoxStyle.Critical)
        End Try
    End Sub




    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Me.Close()
    End Sub

    Private Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Me.Close()
    End Sub

    Private Sub SeleccionarTodasLasFilas()
        For Each fila As DataGridViewRow In dgvListado.Rows
            ' Asegurarse de que la fila no sea nula y de que la celda del CheckBox existe
            If fila IsNot Nothing AndAlso Not fila.IsNewRow Then
                Dim celdaCheckBox As DataGridViewCheckBoxCell = TryCast(fila.Cells("Seleccion"), DataGridViewCheckBoxCell)
                If celdaCheckBox IsNot Nothing Then
                    celdaCheckBox.Value = True
                End If
            End If
        Next
    End Sub

    Private Sub QuitarSeleccionDeTodasLasFilas()
        For Each fila As DataGridViewRow In dgvListado.Rows
            ' Asegurarse de que la fila no sea nula y de que la celda del CheckBox existe
            If fila IsNot Nothing AndAlso Not fila.IsNewRow Then
                Dim celdaCheckBox As DataGridViewCheckBoxCell = TryCast(fila.Cells("Seleccion"), DataGridViewCheckBoxCell)
                If celdaCheckBox IsNot Nothing Then
                    celdaCheckBox.Value = False
                End If
            End If
        Next
    End Sub

    Private Sub btnSeleccionarTodas_Click(sender As Object, e As EventArgs) Handles btnSeleccionarTodas.Click
        SeleccionarTodasLasFilas()
    End Sub

    Private Sub btnQuitar_Click(sender As Object, e As EventArgs) Handles btnQuitar.Click
        QuitarSeleccionDeTodasLasFilas()
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
