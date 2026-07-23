using HarmonyLib;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace JudePatch.Patches.Misc;

[HarmonyPatch(typeof(Camera), nameof(Camera.fieldOfView), MethodType.Setter)]
public class FovPatch
{
    public static float value = 90;
    public static void Prefix(ref float value)
    {
        if(SceneManager.GetActiveScene().name == "TitleScreen") return;
        value = FovPatch.value;
    }
}