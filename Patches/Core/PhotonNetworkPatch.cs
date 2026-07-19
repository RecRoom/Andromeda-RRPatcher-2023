using System;
using HarmonyLib;
using Il2Cpp;
using Il2CppPhoton.Realtime;
using MelonLoader;
using MelonLoader.Pastel;

namespace Patches;

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
                        AppIdRealtime = AppIdRealtime,
                        AppIdVoice = AppIdVoice,
                        AppVersion = AppVersion,
                        FixedRegion = ALENEHILMJK
                    };
                    AndromedaEngine.Debug.Console.Log($"[{"HarmonyPatch".Pastel("#FF3D00")}] PUNNetworkManager::OIMACPCFIKN -> (Photon Intercepted) \n");
                }
                catch (Exception e)
                {
                    AndromedaEngine.Debug.Console.Log(e);
                }
            }
        }
        [HarmonyPatch(typeof(LEALBOODIEE), nameof(LEALBOODIEE.GBNKOFMAJPA))]
        public class Unknown1
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
                    };
                    AndromedaEngine.Debug.Console.Log($"[{"HarmonyPatch".Pastel("#FF3D00")}] LEALBOODIEE::GBNKOFMAJPA -> (Photon Intercepted) \n");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    
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
    