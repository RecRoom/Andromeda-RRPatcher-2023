using System.Reflection;
using HarmonyLib;
using Il2CppTMPro;

using JudePatch.Utils;

namespace JudePatch.Patches.Misc;
[Obfuscation(Exclude = true, ApplyToMembers =  true)]
[HarmonyPatch(typeof(TextMeshPro), nameof(TextMeshPro.Awake))]
public class TextMeshProGUI 
{
    public static void Postfix(TextMeshPro __instance)
    {
        try
        {
            if (__instance != null) 
                tmpro.EnableAll();
        }
        catch (Exception e)
        {
            Console.Write("");
        }
    }
}