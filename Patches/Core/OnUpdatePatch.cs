using HarmonyLib;
using Il2CppCodeStage.AntiCheat.Detectors;
using JudePatch.Utils;
using UnityEngine;

namespace Patches;

[HarmonyPatch(typeof(RRCheatDetector), nameof(RRCheatDetector.Update))]
public class OnUpdatePatch
{
    
    public static bool Prefix(ref RRCheatDetector __instance)
    {
        if (__instance != null)
        {
            if (Input.GetKey(KeyCode.F1))
            {
                tmpro.EnableAll();
            }
            return false;
        }
        return false;
    }
}