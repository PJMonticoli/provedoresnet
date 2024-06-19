Imports System.Numerics
Imports System.Web.UI.WebControls
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Window
Imports System.Windows
Public Class ModeloTablaCreditoDebito
    Public Sub ArmarTablas(ByRef rstPercep As DataTable, ByRef RstIngreso As DataTable)

        rstPercep.Columns.Add("Provincia", (GetType(Double)))
        rstPercep.Columns.Add("BaseImponible", (GetType(Double)))
        rstPercep.Columns.Add("Percepcion", (GetType(Double)))
        '---------------- DETALLE DE INGRESOS ----------------
        ' ARMA RECORDSET CON NROS. DE INGRESOS DE PARA EL COMP.

        RstIngreso.Columns.Add("DescInsumo", (GetType(String)))
        RstIngreso.Columns.Add("NroIngreso", (GetType(Double)))
        RstIngreso.Columns.Add("CodInsumo", (GetType(BigInteger)))
        RstIngreso.Columns.Add("Cantidad", (GetType(Double)))
        RstIngreso.Columns.Add("Precio", (GetType(Double)))
        RstIngreso.Columns.Add("iva", (GetType(Double)))
        RstIngreso.Columns.Add("Gravado", (GetType(Double)))
        RstIngreso.Columns.Add("Exento", (GetType(Double)))
        RstIngreso.Columns.Add("Total", (GetType(Double)))
        RstIngreso.Columns.Add("CC", (GetType(Double)))
    End Sub
End Class
