using System.Reflection;
using HarmonyLib;
using Il2Cpp;
using Il2CppCodeStage.AntiCheat.Detectors;
using Il2CppRecRoom.AntiCheat;

using MelonLoader.Pastel;

namespace JudePatch.Patches.Core;

 [Obfuscation(Exclude = true, ApplyToMembers =  true)]
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
    [HarmonyPatch(typeof(CheatManager), nameof(RRCheatDetector.Awake))]
    internal class CheatPatch1
    {
        private static bool Prefix()
        {
            AndromedaEngine.Debug.Console.Log($"[{"HarmonyPatch".Pastel("#FF3D00")}] RRCheatDetector::Awake -> (returned to false)\n");
            return false;
        }
    }
    [HarmonyPatch(typeof(CheatManager), nameof(CheatManager.CheckForDUIDMismatch))]
    internal class CheatPatch2
    {
        private static bool Prefix(bool __result)
        {
            AndromedaEngine.Debug.Console.Log($"[{"HarmonyPatch".Pastel("#FF3D00")}] CheatManager::Awake -> (returned to false)\n");
            __result = false;
            return false;
        }
    }
    [HarmonyPatch(typeof(CheatManager), nameof(ObscuredCheatingDetector.Awake))]
    internal class CheatPatch3
    {
        private static bool Prefix()
        {
            AndromedaEngine.Debug.Console.Log($"[{"HarmonyPatch".Pastel("#FF3D00")}] ObscuredCheatingDetector::Awake -> (returned to false)\n");
            return false;
        }
    }
}