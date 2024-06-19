Public Class ModeloOrdendeCompraSeleccion

    Public Property PrimaryKey As Integer 'NroOrden
    Public Property Id As Integer ' IdDetalle
    Public Property Number As Integer 'NroOrden
    Public Property SupplyId As String 'IdInsumo COnsuman
    Public Property Supply As String 'Descripcion insumo 
    Public Property Quantity As Double ' Cantidad
    Public Property Cost As Double ' Costo
    Public Property Total As Double ' TOTAL = COSTO * Cantidad
    Public Property KindId As Integer 'Rubro MAterial
    Public Property CostCenter As String 'Centro Costo
    Public Property InternalMaterialCode As String ' idinsumo interno

    Public Sub New()
        ' Constructor vacío
    End Sub

    ' Constructor con argumentos
    Public Sub New(primarykey As Integer, id As Integer, number As Integer, supplyId As String, supply As String, quantity As Double, cost As Double, total As Double, kindId As Integer, costCenter As String, InternalMaterialCode As String)
        Me.PrimaryKey = primarykey
        Me.Id = id
        Me.Number = number
        Me.SupplyId = supplyId
        Me.Supply = supply
        Me.Quantity = quantity
        Me.Cost = cost
        Me.Total = total
        Me.KindId = kindId
        Me.CostCenter = costCenter
        Me.InternalMaterialCode = InternalMaterialCode
    End Sub

End Class
