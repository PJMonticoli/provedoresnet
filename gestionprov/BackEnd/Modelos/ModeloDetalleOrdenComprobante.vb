Public Class ModeloDetalleOrdenComprobante
    Public Shared Property Id As Integer
    Public Shared Property NroInterno As Integer
    Public Shared Property NroIngreso As Integer
    Public Shared Property CodInsumo As String
    Public Shared Property Cantidad As Integer
    Public Shared Property Precio As Decimal
    Public Shared Property DescInsumo As String
    Public Shared Property CCosto As Decimal

    Public Shared Property CodAutoriza As Integer
    Public Shared Property Iva As Decimal
    Public Shared Property Total As Decimal
    Public Shared Property Gravado As Decimal

    Public Shared Property Exento As Decimal
    Public Shared Property IdMaterial As Integer
    Public Shared Property LugarEntrega As String
End Class
