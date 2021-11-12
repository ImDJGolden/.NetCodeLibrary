'This code snippet is a  function to check if a file you want to import is already used by another process.

'Main code
Dim fileOpen As FileInfo = New FileInfo(dialog.FileName)
If Not IsFileLocked(fileOpen) Then
    'Code here
Else
    'file is used by another process
End If

'Function
Protected Overridable Function IsFileLocked(ByVal file As FileInfo) As Boolean
    Try
        Using stream As FileStream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None)
            stream.Close()
        End Using
    Catch ex As Exception
            Return True
    End Try

    Return False
End Function