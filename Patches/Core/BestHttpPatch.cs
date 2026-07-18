using MelonLoader;
using HarmonyLib;
using Il2CppBestHTTP;
using Il2CppOrg.BouncyCastle.Crypto.Tls;
using Newtonsoft.Json;

namespace Patches;

public static class BestHttpPatch
{
    
    [HarmonyPatch(typeof(HTTPManager), nameof(HTTPManager.SendRequest), new System.Type[] { typeof(HTTPRequest) })]
    internal class NameServer
    {
        private static void Prefix(ref HTTPRequest request)
        {

            try
            {
                if(request.Uri.ToString().Contains("ns.rec.net"))    
                {
                    MelonLogger.Msg("Connecting To Jude Servers");
                    request.Uri = new Il2CppSystem.Uri("https://gameauth.ddns.net");
                }
                MelonLogger.Msg($"Caught Request: {request.Uri.AbsoluteUri}");
            }
            catch (Exception e)
            {
                MelonLogger.Error($"Caught Exception: {e}");
            }
        }
    }
    
    [HarmonyPatch(typeof (LegacyTlsAuthentication), nameof(LegacyTlsAuthentication.NotifyServerCertificate))]
    internal class AlwaysVerifyTLS
    {
        private static bool Prefix()
        {
            return false;
        }
    }
}