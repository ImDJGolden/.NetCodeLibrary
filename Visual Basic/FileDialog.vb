'Code snippet to acces file manager and select a file to use in the application

'On Button Click
Dim dialog as OpenFileDialog = new OpenFileDialog()

dialog.Filter = ""  'add a filter on which type of file(s) you want to select
dialog.ShowDialog()

If dialog.FileName IsNot "" Then
    'code here
End If


'rename file to .OK
Dim file As String = "" 'path to file
Dim newfile As String = file + "-" + DateTime.Now:yyyyMMddHHmmss + ".OK"
File.Move(file, newfile)