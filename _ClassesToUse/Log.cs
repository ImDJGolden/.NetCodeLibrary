public class Log
{
    public static string dir = Application.StartupPath;
    public static string pathLog = Path.Combine(dir, "Log.txt");
        
    public static void Write(string msg)
    {
        StreamWriter sw = null;
            
        try
        {
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            sw = File.AppendText(pathLog);
            sw.WriteLine($"{Environment.MachineName} :: {DateTime.Now:dd-MM-yyyy HH:mm:ss} :: {msg}");
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            sw.Close();
        }
    }
}