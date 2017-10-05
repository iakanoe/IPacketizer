Imports System.IO.File
Imports System.Net
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading
Public Class inicio
    Dim ip As String
    Dim mensajehex As String
    Dim mensajefinal As Byte()
    Dim cliente As New UdpClient
    Dim puerto As Integer
    Dim queue(2, -1) As Object
    Sub iniciar()
        If Exists("paquetes.txt") = False Then
            MsgBox("Se debe crear un archivo ""paquetes.txt"" el cual contenga por cada línea con formato ""[IP DESTINO]:[PUERTO DESTINO] [MENSAJE HEXADECIMAL]"". Gracias.", vbExclamation, "ERROR")
            Close()
        Else
            Dim thdUDPServer = New Thread(New ThreadStart(AddressOf serverThread))
            thdUDPServer.Start()
            loopp()
        End If
    End Sub
    Sub serverThread()
        'Try
        cliente = New UdpClient(44844)
            Do While activo
                Dim RemoteIpEndPoint As New IPEndPoint(IPAddress.Any, 0)
                Dim receiveBytes As Byte()
                Try
                    receiveBytes = cliente.Receive(RemoteIpEndPoint)

                    Dim recibido As String = byte2hex(receiveBytes)
                    Dim bq As Object() = buscarqueue(RemoteIpEndPoint.Address.ToString, RemoteIpEndPoint.Port)
                    If bq IsNot Nothing Then
                        If Exists("respuestas.txt") = False Then
                            Create("respuestas.txt")
                        End If
                        WriteAllLines("respuestas.txt", {Now.ToString("[dd/MM/yyyy HH:mm:ss]: ") & "RECIBIDO OK DE " & RemoteIpEndPoint.Address.ToString & ":" & RemoteIpEndPoint.Port & " " & recibido})
                    End If
                Catch ex As Exception
                    MsgBox(ex.ToString)
                    Exit Do
                End Try
            Loop
        'Catch excep As Exception
        'MsgBox("error")
        'End Try
    End Sub
    Function byte2hex(byte_ As Byte()) As String
        Dim returnData As New StringBuilder(byte_.Length * 2)
        For Each b As Byte In byte_
            Dim part As String
            part = Hex(b)
            If part.Length = 1 Then part = "0" & part
            returnData.Append(part)
        Next
        Return returnData.ToString
    End Function
    Function buscarqueue(ippp As String, porttt As Integer) As Object()
        Dim a(1) As Object
        Dim b As Boolean = False
        For i As Integer = 0 To UBound(queue, 2)
            If queue(1, i) = ippp Then
                a(0) = queue(1, i)
                a(1) = queue(2, i)
                DeleteItem(i)
                b = True
            End If
        Next
        If b = True Then Return a Else Return Nothing
    End Function
    Private Sub DeleteItem(ByVal Index As Long)
        Dim i As Long
        Dim Count As Long
        Count = UBound(queue, 2)
        If Index <= Count And Index >= LBound(queue, 2) Then
            For i = Index To Count - 1
                queue(0, i) = queue(0, i + 1)
                queue(1, i) = queue(1, i + 1)
                queue(2, i) = queue(2, i + 1)
            Next
            ReDim Preserve queue(2, Count - 1)
        End If
    End Sub
    Sub cargarqueue(paquete As String, ipp As String, portt As Integer)
        ReDim Preserve queue(2, UBound(queue, 2) + 1)
        queue(0, UBound(queue, 2)) = paquete
        queue(1, UBound(queue, 2)) = ipp
        queue(2, UBound(queue, 2)) = portt
    End Sub
    Function hex2byte(string_ As String) As Byte()
        string_ = string_.Replace(" "c, "")
        Dim nBytes = string_.Length \ 2
        Dim a(nBytes - 1) As Byte
        For i As Integer = 0 To nBytes - 1
            a(i) = Convert.ToByte(string_.Substring(i * 2, 2), 16)
        Next
        Return a
    End Function
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Button2.Text = "Activar" Then
            activo = True
            iniciar()
            Button2.Text = "Desactivar"
        Else
            Dim thdUDPServer = New Thread(New ThreadStart(AddressOf serverThread))
            activo = False
            thdUDPServer.Abort()
            cliente.Close()
            Button2.Text = "Activar"
        End If
    End Sub
    Private Sub inicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Exists("config.txt") Then
            Dim file As String() = ReadAllLines("config.txt")
            minutosinicial = CInt(file(0))
            minutosfinal = CInt(file(1))
            mins.Text = (minutosinicial + minutosfinal) / 2
        Else
            config_Click()
        End If
    End Sub
    Dim minutosinicial As Integer
    Dim minutosfinal As Integer
    Private Sub config_Click() Handles Button1.Click
        If Button2.Text = "Desactivar" Then
            Dim thdUDPServer = New Thread(New ThreadStart(AddressOf serverThread))
            activo = False
            thdUDPServer.Abort()
            cliente.Close()
            Button2.Text = "Activar"
        End If
        Dim config1 As New config
        config1.ShowDialog()
        Dim file As String() = ReadAllLines("config.txt")
        minutosinicial = file(0)
        minutosfinal = file(1)
        mins.Text = (minutosinicial + minutosfinal) / 2
    End Sub
    Dim activo As Boolean
    Sub loopp()
        Dim numerodelinea As Integer = 0
        Dim lineas As String() = ReadAllLines("paquetes.txt")
        Do While activo
            Dim linea As String = lineas(numerodelinea)
            Dim lineadividida As String() = linea.Split(" "c)
            ip = lineadividida(0).Split(":"c)(0)
            puerto = lineadividida(0).Split(":"c)(1)
            mensajehex = lineadividida(1)
            mensajefinal = hex2byte(mensajehex)
            cliente = New UdpClient
            cliente.Connect(ip, puerto)
            cliente.Send(mensajefinal, mensajefinal.Length)
            cargarqueue(mensajehex, Dns.GetHostAddresses(ip)(0).ToString, puerto)
            iniciar()
            Dim milis As Integer = (CInt(Math.Floor((minutosfinal - minutosinicial + 1) * Rnd())) + minutosinicial) * 60 * 1000
            Thread.Sleep(milis)
            If numerodelinea = UBound(lineas) Then
                numerodelinea = 0
            Else
                numerodelinea = numerodelinea + 1
            End If
        Loop
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim thdUDPServer = New Thread(New ThreadStart(AddressOf serverThread))
        thdUDPServer.Abort()

        cliente.Close()
    End Sub
End Class