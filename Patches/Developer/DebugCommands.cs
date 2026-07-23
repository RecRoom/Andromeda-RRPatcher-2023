#if DEBUG

using HarmonyLib;
using Il2CppAGUI.StackedUI;
using Il2CppRecRoom.Core;
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
                            if (ColorVaultPatch.SkinColorVault != null)
                                GameUtils.Avatar.CreateAvatarColor(ColorVaultPatch.SkinColorVault, guid, color);
                            GameUtils.Chatbox.MessagePlayerLocal(0,"<color=#7e9efc>[Andromeda]</color>","Skin created!");
                            break;

                        case "hair":
                            if (ColorVaultPatch.HairColorVault != null)
                                GameUtils.Avatar.CreateAvatarColor(ColorVaultPatch.HairColorVault, guid, color);
                            GameUtils.Chatbox.MessagePlayerLocal(0,"<color=#7e9efc>[Andromeda]</color>","Hair created!");
                            break;
                    }
                }
                
            }
            if (__0.StartsWith("/radio beta.customtracks"))
            {
                /*string data = __0.Replace("/radio allow_customtracks", "");
                string[] args = data.Split(',');
                string status = args[0].Trim();*/
                
                
            }
            if (__0.Equals("/help"))
            {
                GameUtils.Chatbox.MessagePlayerLocal(0,"<color=#7e9efc>[Andromeda]</color>","<color=red>DebugConsole</color>");
            }
            if (__0.Equals("/c avatar"))
            {
                WatchUI.CKJDMNFGDPD.HPLKAJMLDCC.TryCast<RRUIRootScreen>().ShowScreenAndGoToAvatarCustomization();
            }
            #endregion
           
        }
    }
}
#endif
