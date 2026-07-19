using HarmonyLib;
using Il2CppTMPro;

using JudePatch.Utils;


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