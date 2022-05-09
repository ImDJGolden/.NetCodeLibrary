//This code snippet is a  function to check if a file you want to import is already used by another process.

//Main code
FileInfo file = new FileInfo(dialog.FileName);
if (!IsFileLocked(file)) {
    //Code here
}
else {
    //File is used by another Process
}

//Function
protected virtual bool IsFileLocked(FileInfo file)
{
    try {
        using (FileStream stream = file.Open(Filemode.Open, FileAccess.Read, FileShare.None)) {
            stream.Close();
        }
    }
    catch (Exception ex) {
        return true;
    }

    return false;
}