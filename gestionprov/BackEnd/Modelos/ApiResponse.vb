Public Class ApiResponse
    Public Property Result As String
    Public Property Data As List(Of ModeloOrdenDeCompra)
    Public Property ErrorMessage As String
    Public Property Log As Object ' Tipo de datos adecuado para Log, ajusta según tus necesidades
    Public Property Stack As Object ' Tipo de datos adecuado para Stack, ajusta según tus necesidades
    Public Property Alerts As Object ' Tipo de datos adecuado para Alerts, ajusta según tus necesidades
End Class
