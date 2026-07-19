using HarmonyLib;

using Il2CppRecRoom.Avatars.Outfit;
using JudePatch.Utils;
using MelonLoader.Pastel;
using UnityEngine;

namespace JudePatch.Patches.Misc;

[HarmonyPatch(typeof(HairColorVault), nameof(HairColorVault.Awake))]
public class HairColorPatch
{
    public static HairColorVault Vault;
    public static void Postfix(HairColorVault? __instance)
    {
        try
        {
            if (__instance != null)
            {
                GameUtils.Avatar.CreateAvatarColor(__instance, "4b351cbd-138e-412c-8644-d787b9177288", Color.black);
                GameUtils.Avatar.CreateAvatarColor(__instance, "19aca043-002b-4cd0-8ee3-1538eef50e57", Color.blue);
                Vault = __instance;
            }
            AndromedaEngine.Debug.Console.Log($"[{"HarmonyPatch".Pastel("#FF3D00")}] SkinColorVault::Awake -> (Patched) \n");
        }
        catch (Exception e)
        {
            AndromedaEngine.Debug.Console.Log(e);
        }
        
    }
}