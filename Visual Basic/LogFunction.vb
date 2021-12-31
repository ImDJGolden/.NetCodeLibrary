Public Class Log

    Public Shared Sub Write(Byval msg As String)
        Dim path As String = $"{Application.StartupPath}\log.txt"
        Dim sw As StreamWriter = Nothing

        Try
            sw = File.AppendText(path)
            sw.WriteLine($"{Date.Now:dd-MM-yy HH:mm:ss} :: {msg}")
        Catch Ex as Exception
            'exception
        Finally
            sw.Close()
        End Try
    End Sub

End Class