using HarmonyLib;
using Il2CppCodeStage.AntiCheat.Detectors;
using JudePatch.Patches.Developer.Debugging;
using UnityEngine;

namespace JudePatch.Patches.Core;

[HarmonyPatch(typeof(RRCheatDetector), nameof(RRCheatDetector.Update))]
public class OnUpdatePatch
{
    
    public static bool Prefix(ref RRCheatDetector __instance)
    {
        if (__instance != null)
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                    PhotonPeerPatch.Enable = !PhotonPeerPatch.Enable;
                    AndromedaEngine.Debug.Console.Log($"IPhotonPeer set: {PhotonPeerPatch.Enable}\n");
            }
            return false;
        }
        return false;
    }
}