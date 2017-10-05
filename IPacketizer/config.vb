Public Class config
    Private Sub config_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If IO.File.Exists("config.txt") Then
            Dim file As String() = IO.File.ReadAllLines("config.txt")
            Dim minutosinicial = file(0)
            Dim minutosfinal = file(1)
            desde.Text = minutosinicial
            hasta.Text = minutosfinal
        Else
            desde.Text = ""
            hasta.Text = ""
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If IsNumeric(desde.Text) = False Then
            MsgBox("""" & desde.Text & """ no es un número válido. Intente otra vez.", vbExclamation, "ERROR")
        ElseIf IsNumeric(hasta.Text) = False Then
            MsgBox("""" & hasta.Text & """ no es un número válido. Intente otra vez.", vbExclamation, "ERROR")
        Else
            IO.File.WriteAllLines("config.txt", {desde.Text, hasta.Text})
            Close()
        End If
    End Sub
End Class