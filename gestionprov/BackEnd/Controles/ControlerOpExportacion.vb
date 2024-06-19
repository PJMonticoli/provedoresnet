Imports GrapeCity.Enterprise.Data.DataEngine.DataProcessing

Public Class ControlerOpExportacion
    Inherits ServidorSQl

    Public Function BuscarTipoCompEXP(ByRef dt As DataTable) As Long
        On Error GoTo errores
        dt = ServidorSQl.GetTabla("Select * from ctasctessql.dbo.tipoComprobanteExportaciones where estado=1 order by desctipocompexp")
        If dt Is Nothing Then
            GoTo errores
        ElseIf dt Is Nothing OrElse dt.Rows.Count = 0 Then
            BuscarTipoCompEXP = 0
        Else
            BuscarTipoCompEXP = 1
        End If
        Exit Function
errores:
        BuscarTipoCompEXP = -1
    End Function

    Public Function BuscarMonedas(ByRef dt As DataTable) As Long
        On Error GoTo errores
        dt = ServidorSQl.GetTabla("Select * from proveedores.dbo.Moneda order by codmoneda")
        If dt Is Nothing Then
            GoTo errores
        ElseIf dt Is Nothing OrElse dt.Rows.Count = 0 Then
            BuscarMonedas = 0
        Else
            BuscarMonedas = 1
        End If
        Exit Function
errores:
        BuscarMonedas = -1
    End Function
End Class
