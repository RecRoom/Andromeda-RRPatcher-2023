using System.Reflection;
using AndromedaEngine;
using AndromedaEngine.RecRoom;
using HarmonyLib;
using Il2CppBestHTTP;
using Il2CppOrg.BouncyCastle.Crypto.Tls;

namespace JudePatch.Patches.Core;

[Obfuscation(Exclude = true, ApplyToMembers =  true)]
public static class BestHttpPatches
{
    [HarmonyPatch(typeof(HTTPManager), nameof(HTTPManager.SendRequest), new System.Type[] { typeof(HTTPRequest) })]
    internal class NameServer
    {
        private static void Prefix(ref HTTPRequest request)
        {
            try
            {
                if (request.Uri.ToString().Contains("ns.rec.net"))
                {
                    AndromedaEngine.Debug.Console.Log("Connecting To Andromeda NameServer\n", Debug.Console.LogLevel.Debug);
                    request.Uri = new Il2CppSystem.Uri("https://gameauth.ddns.net");
                    
                }
#if DEBUG
                AndromedaEngine.RecRoom.CustomDebugger.Log($"Caught Request: {request.Uri.AbsoluteUri}\n", CustomDebugger.LogLevel.BestHttp);
#endif

            }
            catch (Exception e)
            {
                AndromedaEngine.Debug.Console.Exception("HTTPManagerPatch", e);
            }
        }
    }

    [HarmonyPatch(typeof(LegacyTlsAuthentication), nameof(LegacyTlsAuthentication.NotifyServerCertificate))]
    internal class AlwaysVerifyTLS
    {
        private static bool Prefix()
        {
            return false;
        }
    }
}
