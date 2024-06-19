Public Class ModeloOrdenDeCompra
    Public Property Id As Integer
    Public Property Number As Integer
    Public Property VoucherTypeId As Integer
    Public Property VoucherType As String
    Public Property ResponsibleId As Integer
    Public Property Responsible As String
    Public Property ClientId As Integer?
    Public Property Client As Object ' Tipo de datos adecuado para Client, ajusta según tus necesidades
    Public Property SupplierId As Integer
    Public Property Supplier As String
    Public Property SupplierKey As String
    Public Property CreatedDate As Date
    Public Property DateRequired As Date?
    Public Property Details As List(Of ModeloDetalleOrdenCompra)
End Class
