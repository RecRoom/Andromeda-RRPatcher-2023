using MelonLoader.Pastel;

namespace AndromedaEngine.RecRoom;

public class CustomDebugger
{
    public class ColorFlags 
    {
      
        public const string RecNet = "#FF4F00";
        public const string MasterServerColor = "#CC0089";
        public const string GameServerColor = "#153EB8";
        public const string BestHttpColor = "#00B386";

        public const string PhotonRealtimeColor = "#FFFFFF";
        public const string PhotonPeerColor = "#D3EC68";
        public const string PhotonViewColor = "#f451a6";
        
       public class PhotonArgs
        {
            public const string OnEventColor = "#c8a162";
            public const string RPCEventColor = "#f451a6";

        }
       
        
     
        
    }
 
    public enum LogLevel
    {
        None,
        RecNet,
        MasterServer,
        GameServer,
        BestHttp,
        Photon,
        PhotonView,
        PhotonPeer,
        
    }
    public static void Log(string message, LogLevel levels =  LogLevel.None)
    {
        switch (levels)
        {
            case LogLevel.RecNet:
                AndromedaEngine.Debug.Console.Base($"[{"RecNet".PastelBg(ColorFlags.RecNet)}] {message}");
                break;
            case LogLevel.MasterServer:
                AndromedaEngine.Debug.Console.Base($"[{"MasterServer".PastelBg(ColorFlags.MasterServerColor)}] {message}");
                break;
            case LogLevel.GameServer:
                AndromedaEngine.Debug.Console.Base($"[{"GameServer".PastelBg(ColorFlags.GameServerColor)}]  {message}");
                break;
            case LogLevel.BestHttp:
                AndromedaEngine.Debug.Console.Base($"{"Server".Pastel(ColorFlags.BestHttpColor)} {message}");
                break;
            case LogLevel.Photon:
                AndromedaEngine.Debug.Console.Base($"{"PhotonRealtime".Pastel(ColorFlags.PhotonRealtimeColor)} {message.Pastel(ColorFlags.PhotonRealtimeColor)}");
                break;
            case LogLevel.PhotonPeer:
                AndromedaEngine.Debug.Console.Base($"{"PhotonPeer".Pastel(ColorFlags.PhotonPeerColor)} {message}");
                break;
            case LogLevel.PhotonView:
                AndromedaEngine.Debug.Console.Base($"[{"PhotonView".Pastel(ColorFlags.PhotonViewColor)}] {message}");
                break;
        }
    }
}