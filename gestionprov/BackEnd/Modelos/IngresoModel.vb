Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Public Class IngresoModel
    Private _tcpListener As TcpListener
    Private Const _port As Integer = 12345

    Public Sub New()
        ' Inicializar el servidor TCP/IP
        _tcpListener = New TcpListener(IPAddress.Any, _port)
        _tcpListener.Start()
        Console.WriteLine("Servidor TCP/IP iniciado en el puerto " & _port)
    End Sub

    Public Sub EsperarConexion()
        ' Esperar la conexión de un cliente
        Dim client As TcpClient = _tcpListener.AcceptTcpClient()
        Console.WriteLine("Cliente conectado")

        ' Manejar la comunicación con el cliente
        ManejarComunicacion(client)
    End Sub

    Private Sub ManejarComunicacion(client As TcpClient)
        Try
            ' Obtener el flujo de datos del cliente
            Dim stream As NetworkStream = client.GetStream()

            ' Buffer para los datos recibidos
            Dim data(256) As Byte

            ' Leer los datos del cliente
            Dim bytesRead As Integer = stream.Read(data, 0, data.Length)
            Dim mensaje As String = Encoding.ASCII.GetString(data, 0, bytesRead)
            Console.WriteLine("Mensaje recibido: " & mensaje)

            ' Procesar el mensaje recibido, por ejemplo, enviar una respuesta al cliente
            Dim respuesta As String = "Mensaje recibido correctamente"
            Dim responseData As Byte() = Encoding.ASCII.GetBytes(respuesta)
            stream.Write(responseData, 0, responseData.Length)
            Console.WriteLine("Respuesta enviada: " & respuesta)
        Catch ex As Exception
            Console.WriteLine("Error al manejar la comunicación: " & ex.Message)
        Finally
            ' Cerrar la conexión con el cliente
            client.Close()
        End Try
    End Sub


End Class
