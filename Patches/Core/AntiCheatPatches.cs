using System;
using HarmonyLib;
using Il2Cpp;
using Il2CppRecRoom.AntiCheat;
using MelonLoader;

namespace Patches;

public class AntiCheatPatches
{
    [HarmonyPatch(typeof(EACManager), nameof(EACManager.GenerateChallengeResponse))]
    public class EAC
    {
        public static bool Prefix(ref string __result)
        {
            __result = "e";
            MelonLogger.Msg("HIT!!! EACManager.GenerateChallengeResponse");
            return false;
        }
    }
    
    [HarmonyPatch(typeof(CheatManager), nameof(CheatManager.Awake))]
    internal class CheatPatch
    {
        private static bool Prefix()
        {
            MelonLogger.Msg("fuck you: CheatManager.Awake");
            return false;
        }
    }

}