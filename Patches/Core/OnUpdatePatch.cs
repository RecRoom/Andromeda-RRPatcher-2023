using System.Reflection;
using HarmonyLib;
using Il2CppCodeStage.AntiCheat.Detectors;
using UnityEngine;

using JudePatch.Patches.Developer.Debugging;
using JudePatch.Patches.Misc;
using JudePatch.Utils;
using Debug = AndromedaEngine.Debug;

namespace JudePatch.Patches.Core;

[Obfuscation(Exclude = true, ApplyToMembers =  true)]
[HarmonyPatch(typeof(RRCheatDetector), nameof(RRCheatDetector.Update))]
public class OnUpdatePatch
{
    
    public static void Postfix(RRCheatDetector __instance)
    {
        if (__instance != null)
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                    PhotonPeerPatch.Enable = !PhotonPeerPatch.Enable;
                    AndromedaEngine.Debug.Console.Log($"IPhotonPeer set: {PhotonPeerPatch.Enable}\n");
            }
            if (Input.GetKeyDown(KeyCode.F2))
            {
                DebugUtils.TitleScreen.RetryScreen("<color=red>Auth Failed.</color>");
            }
            if (Input.GetKeyDown(KeyCode.Equals))
                FovPatch.value += 5f;

            if (Input.GetKeyDown(KeyCode.Minus))
                FovPatch.value -= 5f;

            FovPatch.value = Mathf.Clamp(FovPatch.value, 1f, 179f);
        }

    }
}