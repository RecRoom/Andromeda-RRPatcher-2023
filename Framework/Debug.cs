using MelonLoader.Pastel;


namespace AndromedaEngine;

public class Debug
{
    public static class Config
    {
        /*private string ServerName = "";*/
        
    }
    
    public class Console
    {
        public enum LogLevel
        {
            None,
            Info,
            Warning,
            Error,
            Debug,
        }

        public static void Base(string output)
        {
            System.Console.Write($"[{DateTime.UtcNow.ToString("HH:mm:ss").Pastel("#86e888")}] {output} ");
        }
        public static void Log(string message = "", LogLevel level = LogLevel.None)
        {
            string ApplicationId = "Andromeda";
            switch (level)
            {
                case LogLevel.None:
                    Base($"[{ApplicationId}] {message}");
                    break;
                case LogLevel.Info:
                    Base($"[{"Info".PastelBg("#1E4AFF")}] [{ApplicationId}] {message}");
                    break;
                case LogLevel.Warning:
                    Base($"[{"Warning".PastelBg("#FFCB00")}] [{ApplicationId}] {message}");
                    break;
                case LogLevel.Error:
                    Base($"[{"Error".PastelBg("#FF0044")}] [{ApplicationId}] {message}");
                    System.Console.Beep(356, 433);
                    break;
                case LogLevel.Debug:
                    Base($"{"Debug".Pastel("#B47CFF").PastelBg("#300071")} [{ApplicationId}] {message}");
                    break;
            }
        }
        public static void Exception(string id, Exception e)
        {
            Log( $"[{id}] "+ e.Message + "\n", LogLevel.Error);
           
            System.Console.Beep(356, 433);
        }
        public static void Exception(Exception e)
        {
            Log(e.Message + "\n", LogLevel.Error);
           
            System.Console.Beep(356, 433);
        }

    }
  
}