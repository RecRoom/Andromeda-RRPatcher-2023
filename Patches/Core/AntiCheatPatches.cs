using System;
using HarmonyLib;
using Il2Cpp;
using Il2CppRecRoom.AntiCheat;
using MelonLoader;
using MelonLoader.Pastel;

namespace Patches;

public class AntiCheatPatches
{
    [HarmonyPatch(typeof(EACManager), nameof(EACManager.GenerateChallengeResponse))]
    public class EAC
    {
        public static bool Prefix(ref string __result)
        {
            __result = "e";
            AndromedaEngine.Debug.Console.Log($"[{"HarmonyPatch".Pastel("#FF3D00")}] EACManager::GenerateChallengeResponse -> (Intercepted)\n");
            return false;
        }
    }
    
    [HarmonyPatch(typeof(CheatManager), nameof(CheatManager.Awake))]
    internal class CheatPatch
    {
        private static bool Prefix()
        {
            AndromedaEngine.Debug.Console.Log($"[{"HarmonyPatch".Pastel("#FF3D00")}] CheatManager::Awake -> (returned to false)\n");
            return false;
        }
    }

}