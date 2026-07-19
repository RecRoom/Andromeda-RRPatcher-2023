#if DEBUG

using HarmonyLib;
using Il2CppRecRoom.Players;
using JudePatch.Patches.Misc;
using JudePatch.Utils;
using UnityEngine;

namespace JudePatch.Patches.Developer;

[HarmonyPatch(typeof(PlayerEmotes), nameof(PlayerEmotes.LocalSendChatMessage))]
public class DebugCommands
{
    public static void Postfix(PlayerEmotes __instance, string __0, bool __1, bool __2)
    {
        if (__instance != null)
        {
            #region AvatarColorAddCmd
            if (__0.StartsWith("/avatar.addcolor("))
            {
                string data = __0
                    .Replace("/avatar.addcolor(", "")
                    .Replace(");", "");

                string[] args = data.Split(',');

                string type = args[0].Trim();
                string guid = args[1].Trim();
                string hex = args[2].Trim();

                if (ColorUtility.TryParseHtmlString(hex, out Color color))
                {
                    switch (type)
                    {
                        case "skin":
                            GameUtils.Avatar.CreateAvatarColor(SkinColorPatch.Vault, guid, color);
                            break;

                        case "hair":
                            GameUtils.Avatar.CreateAvatarColor(HairColorPatch.Vault, guid, color);
                            break;
                    }
                }
            }
            #endregion
           
        }
    }
}
#endif
