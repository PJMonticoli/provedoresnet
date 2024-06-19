
Imports System
Imports System.IdentityModel.Tokens.Jwt
Imports System.Security.Claims
Imports System.Security.Cryptography
Imports Microsoft.IdentityModel.Tokens
Imports System.Text
Imports System.Net.Http
Imports System.Text.Json.Serialization
Imports Newtonsoft.Json

Public Class TokenService

    Private Const ExistingSecretKey As String = "sisjg2018"

    ' Extiende la clave a 256 bits si es necesario
    Private Shared ReadOnly SecretKey As String = EnsureMinimumLength(ExistingSecretKey, 256)


    Private Shared Function EnsureMinimumLength(key As String, minLengthInBits As Integer) As String
        Dim hasher As New SHA256Managed()

        ' Si la clave actual es demasiado corta, hashearla hasta alcanzar la longitud mínima en bits
        While key.Length * 8 < minLengthInBits
            key = Convert.ToBase64String(hasher.ComputeHash(Encoding.UTF8.GetBytes(key)))
        End While

        ' Devuelve la clave extendida
        Return key
    End Function


    Public Shared Async Function GenerateToken(username As String, password As String, tokenUrl As String) As Task(Of String)
        Dim token As String = String.Empty

        ' Construir los datos que se enviarán en el cuerpo de la solicitud
        Dim postData As String = $"grant_type=password&username={Uri.EscapeDataString(username)}&password={Uri.EscapeDataString(password)}"

        ' Configurar el cliente HTTP
        Using httpClient As New HttpClient()
            ' Configurar los encabezados
            httpClient.DefaultRequestHeaders.Accept.Clear()
            httpClient.DefaultRequestHeaders.Accept.Add(New Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"))

            Try
                ' Enviar la solicitud POST
                Dim response As HttpResponseMessage = Await httpClient.PostAsync(tokenUrl, New StringContent(postData, Encoding.UTF8, "application/x-www-form-urlencoded"))

                ' Verificar si la solicitud fue exitosa
                If response.IsSuccessStatusCode Then
                    ' Leer el contenido de la respuesta
                    Dim responseBody As String = Await response.Content.ReadAsStringAsync()

                    ' Analizar el JSON para obtener el token
                    Dim tokenResponse As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(responseBody)
                    token = tokenResponse.GetValue("access_token").ToString()


                Else
                    ' Manejar errores de solicitud
                    Console.WriteLine("Error al obtener el token: " & response.ReasonPhrase)
                End If
            Catch ex As Exception
                ' Manejar excepciones
                Console.WriteLine("Error al enviar la solicitud HTTP: " & ex.Message)
            End Try
        End Using

        Return token
    End Function
    '    Dim apiUrl As String = "http://192.168.1.22:81/token"
    '    Dim access_token As String = ""

    '    Dim parametros As New List(Of KeyValuePair(Of String, String))()
    '    parametros.Add(New KeyValuePair(Of String, String)("grant_type", "password"))
    '    parametros.Add(New KeyValuePair(Of String, String)("username", username))
    '    parametros.Add(New KeyValuePair(Of String, String)("password", password))

    '    Dim contenido As New FormUrlEncodedContent(parametros)

    '    Using client As New HttpClient()
    '        Try
    '            Dim response As HttpResponseMessage = Await client.PostAsync(apiUrl, contenido)
    '            If response.IsSuccessStatusCode Then
    '                Dim json As String = Await response.Content.ReadAsStringAsync()
    '                Dim tokenResponse As TokenResponse = JsonConvert.DeserializeObject(Of TokenResponse)(json)
    '                access_token = tokenResponse.access_token

    '                ' Leer el token existente
    '                Dim handler = New JwtSecurityTokenHandler()
    '                Dim jsonToken = handler.ReadToken(access_token)

    '                ' Obtener los claims del token existente
    '                Dim existingClaims = DirectCast(jsonToken, JwtSecurityToken).Claims

    '                ' Agregar el nuevo claim del time zone
    '                Dim newClaim = New Claim("timezone", "GMT")
    '                Dim updatedClaims = New List(Of Claim)(existingClaims) From {newClaim}

    '                ' Crear un nuevo ClaimsIdentity con los claims actualizados
    '                Dim claimsIdentity As New ClaimsIdentity(updatedClaims, "Bearer")

    '                ' Crear un nuevo token con los claims actualizados
    '                Dim securityToken As JwtSecurityToken = handler.CreateToken(New SecurityTokenDescriptor With {
    '                    .Subject = claimsIdentity,
    '                    .Expires = DateTime.UtcNow.AddMinutes(120), ' Define la expiración del token según tus necesidades
    '                    .SigningCredentials = New SigningCredentials(New SymmetricSecurityKey(Encoding.UTF8.GetBytes("tu_clave_secreta")), SecurityAlgorithms.HmacSha256Signature)
    '                })

    '                ' Escribir el token modificado como un string
    '                access_token = handler.WriteToken(securityToken)
    '            Else
    '                ' Manejar errores de la solicitud de token
    '            End If
    '        Catch ex As Exception
    '            ' Manejar otras excepciones
    '            MsgBox(ex.Message)
    '        End Try
    '    End Using

    '    Return access_token
    'End Function
End Class

    Public Class TokenResponse
        Public Property access_token As String
        Public Property token_type As String
        Public Property expires_in As Integer
        Public Property UserID As String
        Public Property DeviceID As String
        Public Property Version As String
        Public Property issued As String
        Public Property expires As String
    End Class



