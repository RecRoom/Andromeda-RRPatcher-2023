using AndromedaEngine.RecRoom;
using Harmony;
using Il2Cpp;
using Il2CppTMPro;
using UnityEngine;
using Il2CppInterop.Runtime;
using JudePatch.Utils;
using UnityEngine.UI;

namespace JudePatch.Patches.Misc;

[HarmonyPatch(typeof(TextMeshPro), nameof(TextMeshPro.Awake))]
public class TextMeshProGUI 
{
    public static void Postfix(TextMeshPro __instance)
    {
        if (__instance != null)
        {
           tmpro.EnableAll();
        }   
    }
}