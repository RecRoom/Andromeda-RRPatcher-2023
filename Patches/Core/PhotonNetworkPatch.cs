using System;
using System.Reflection;
using System.Text;
using HarmonyLib;
using Il2Cpp;
using Il2CppExitGames.Client.Photon;
using Il2CppPhoton.Realtime;
using MelonLoader;
using MelonLoader.Pastel;

namespace JudePatch.Patches.Core;

    [Obfuscation(Exclude = true, ApplyToMembers =  true)]
    public static class PhotonNetworkPatch
    {
        private const string AppIdRealtime = "1c61579b-7da7-41a6-99ba-33df60f3fafd";
        private const string AppIdVoice = "2f0fac1b-e91a-4271-8e95-8aee7fd67360";
        private const string AppVersion = "20230406_prod";
        
       
        [HarmonyPatch(typeof(PUNNetworkManager), nameof(PUNNetworkManager.OIMACPCFIKN))]
        public class AppSettingsPatch
        {
            private static void Postfix(string ALENEHILMJK, ref AppSettings __result)
            {
                try
                {
                    __result = new AppSettings()
                    {
                        #region PhotonServerApp

                        AppIdRealtime = AppIdRealtime,
                        AppIdVoice = AppIdVoice,
                        AppVersion = AppVersion,
                        FixedRegion = ALENEHILMJK,

                        #endregion
                        
                        NetworkLogging = DebugLevel.ALL
                    };
                    AndromedaEngine.Debug.Console.Log($"[{"HarmonyPatch".Pastel("#FF3D00")}] PUNNetworkManager::OIMACPCFIKN -> (Photon Intercepted) \n");
                }
                catch (Exception e)
                {
                    AndromedaEngine.Debug.Console.Exception(nameof(AppSettingsPatch), e);
                }
            }
        }
        [HarmonyPatch(typeof(LEALBOODIEE), nameof(LEALBOODIEE.GBNKOFMAJPA))]
        public class AppSettingsPatch2
        {
            private static void Postfix(ref AppSettings __result)
            {
                try
                {
                    __result = new AppSettings()
                    {
                        AppIdRealtime = AppIdRealtime,
                        AppIdVoice = AppIdVoice,
                        AppVersion = AppVersion,
                        /*UseNameServer = false,
                        AuthMode = DAKGKMNIHHL.AuthOnce,
                        Port = 5055,*/
                        NetworkLogging = DebugLevel.ALL
                        
                        
                    };
                    StringBuilder sb = new();
                    sb.AppendLine("");
                    sb.AppendLine("-----------------");
                    sb.AppendLine($@"AppSetings:  
                        AppIdRealtime: {__result.AppIdRealtime}, 
                        AppIdVoice: {__result.AppIdVoice}, 
                        AppVersion: {__result.AppVersion},  
                        UseNameServer: {__result.UseNameServer},
                        AuthMode: {__result.AuthMode},
                        Port: {__result.Port}");
                    AndromedaEngine.Debug.Console.Log($"[{"HarmonyPatch".Pastel("#FF3D00")}] LEALBOODIEE::GBNKOFMAJPA -> (Photon Intercepted) \n");
                }
                catch (Exception e)
                {
                    AndromedaEngine.Debug.Console.Exception(nameof(AppSettingsPatch2), e);
                    
                }
            }
        }

        /*[HarmonyPatch(typeof(HDEJKABEHLO), nameof(HDEJKABEHLO.GBNKOFMAJPA))]
        public class Unknown2
        {
            private static void Postfix(ref AppSettings __result)
            {
                MelonLogger.Msg("Trying to fix: HDEJKABEHLO.GBNKOFMAJPA");
                try
                {
                    __result = new AppSettings()
                    {
                        AppIdRealtime = AppIdRealtime,
                        AppIdVoice = AppIdVoice,
                        AppVersion = AppVersion,
                        UseNameServer = false
                    };
                    MelonLogger.Msg("Fixed: HDEJKABEHLO.GBNKOFMAJPA");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                 
                }
            }
        }*/
    }
    