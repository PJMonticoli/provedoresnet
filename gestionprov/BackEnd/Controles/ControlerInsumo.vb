Imports System.ServiceModel
Imports System.Web.UI.WebControls

Public Class ControlerInsumo
    Inherits ServidorSQl
    Dim CadenaSql As String
    Public Function BuscarDatos(ByRef CadAux As String, ByRef tabla As DataTable) As Integer
        Try
            If Not String.IsNullOrEmpty(CadAux) Then
                If IsNumeric(CadAux) Then
                    CadenaSql = "SELECT Insumos.codInsumo, Insumos.Descripcion, SubRubros.descSubRubro FROM Insumos INNER JOIN SubRubros ON Insumos.codSubRubro = SubRubros.codSubRubro AND Insumos.codRubro = SubRubros.codRubro AND Insumos.CodArea = SubRubros.CodArea And Insumos.CodSubarea = SubRubros.CodSubarea WHERE insumos.estado='S' and codInsumo LIKE '%" & CadAux & "%' ORDER BY codinsumo"
                Else
                    CadenaSql = "SELECT Insumos.codInsumo, Insumos.Descripcion, SubRubros.descSubRubro FROM Insumos INNER JOIN SubRubros ON Insumos.codSubRubro = SubRubros.codSubRubro AND Insumos.codRubro = SubRubros.codRubro AND Insumos.CodArea = SubRubros.CodArea And Insumos.CodSubarea = SubRubros.CodSubarea WHERE insumos.estado='S' and DESCRIPCION LIKE '%" & CadAux & "%' ORDER BY codinsumo"
                End If
            End If
            tabla = ServidorSQl.GetTabla(CadenaSql)

            If tabla Is Nothing Then
                Return -1
            ElseIf tabla.Rows.Count = 0 Then
                Return 0
            Else
                Return 1
            End If
        Catch ex As Exception
            Throw ex
            Return -1
        End Try
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
            Dim query As String = "SELECT * FROM Insumos WHERE CodInsumo = " & insumo & " And Estado = 'S'"
            Dim tabla As DataTable = ServidorSQl.GetTabla(query)

            If tabla IsNot Nothing AndAlso tabla.Rows.Count > 0 Then
                Return Trim(tabla.Rows(0)("codCentroCosto").ToString())
            Else
                Return ""
            End If
        Catch ex As Exception
            Return "DIE"
        End Try
    End Function
    Public Function ObtenerCodInsumoBySubRubro(idSubRubro As Integer, ByRef codInsumo As String, ByRef codCentroCosto As String) As Integer

        Try
            Dim query As String = "SELECT im.codInsumo, i.codcentrocosto FROM InsumoPorMaterialConsuman im INNER JOIN Insumos i ON i.codinsumo = im.codinsumo WHERE idSubRubroConsuman = " & idSubRubro
            Dim tabla As DataTable = ServidorSQl.GetTabla(query)

            If tabla IsNot Nothing AndAlso tabla.Rows.Count > 0 Then
                codInsumo = Trim(tabla.Rows(0)("codInsumo").ToString())
                codCentroCosto = Convert.ToInt32(tabla.Rows(0)("codCentroCosto"))
                Return 1 ' Éxito, se encontraron datos
            Else
                Return 0 ' No se encontraron datos
            End If
        Catch ex As Exception
            Return -1 ' Error durante la ejecución
        End Try
    End Function

End Class
