using System.Reflection;
using HarmonyLib;
using Il2CppRecRoom.Avatars;
using Il2CppRecRoom.Avatars.Outfit;
using JudePatch.Development;
using JudePatch.Utils;
using MelonLoader.Pastel;
using Newtonsoft.Json;
using UnityEngine;

namespace JudePatch.Patches.Misc;

[Obfuscation(Exclude = true, ApplyToMembers =  true)]
public class ColorVaultPatch
{
    public static SkinColorVault? SkinColorVault;
    public static HairColorVault? HairColorVault;

    [HarmonyPatch(typeof(SkinColorVault), nameof(SkinColorVault.Awake))]
    public class SkinColorPatch
    {
        public static void Postfix(SkinColorVault? __instance)
        {
            try
            {
                if (__instance != null)
                {

                    var bytes = JudePatch.Properties.Resources.ColorVault; // already byte[]
                    var json = System.Text.Encoding.UTF8.GetString(bytes);
                    var dataModels = JsonConvert.DeserializeObject<List<ColorVaultDTO>>(json);

                    foreach (var data in dataModels)
                    {
                        if (data.Type.Contains("Skin"))
                        {
                            if (ColorUtility.TryParseHtmlString(data.Value, out var color))
                            {
                                GameUtils.Avatar.CreateAvatarColor(__instance, data.ColorGuid, color);
                            }
                        }
                    }
                    SkinColorVault = __instance;
                }
                AndromedaEngine.Debug.Console.Log($"[{"HarmonyPatch".Pastel("#FF3D00")}] {SkinColorVault?.GetType().Name}::Awake -> (Patched) \n");
            }
            catch (Exception e)
            {
                AndromedaEngine.Debug.Console.Exception(e);
            }

        }

    }
    [HarmonyPatch(typeof(HairColorVault), nameof(HairColorVault.Awake))]
    public class HairColorPatch
    {

        public static void Postfix(HairColorVault? __instance)
        {
            try
            {
                if (__instance != null)
                    HairColorVault = __instance;

                AndromedaEngine.Debug.Console.Log($"[{"HarmonyPatch".Pastel("#FF3D00")}] {HairColorVault?.GetType().Name})::Awake -> (Patched) \n");
            }
            catch (Exception e)
            {
                AndromedaEngine.Debug.Console.Exception(e);
            }

        }
    }

}
