//Class to write error / information to a log file

public static string dir = $@"";
public static string path = Path.Combine(dir, "log.txt");

//Log Error
public void Log(string err)
{
    StreamWriter sw = null;
    try {
        if (!Directory.Exists(dir)) {
            Directory.CreateDirectory(dir);
        }
        sw = File.AppendText(path);
        sw.WriteLine($"{DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")} :: {err}");
    }
    catch (Exception) {
        throw;
    }   
    finally {
        sw.Close();
    }
}