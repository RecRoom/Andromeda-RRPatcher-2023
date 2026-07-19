#if DEBUG
using AndromedaEngine.RecRoom;
using HarmonyLib;
using Il2Cpp;
using Il2CppExitGames.Client.Photon;
using MelonLoader.Pastel;

namespace JudePatch.Patches.Developer.Debugging;

[HarmonyPatch(typeof(HAJIHGCNMAG), nameof(HAJIHGCNMAG.OnEvent))]
public class PhotonRealtimePatch
{
    public static void Postfix(EventData __0)
    {
        AndromedaEngine.RecRoom.CustomDebugger.Log($"{__0.Code.ToString().Pastel(CustomDebugger.ColorFlags.PhotonArgs.OnEventColor)}, {__0.sender.ToString().Pastel(CustomDebugger.ColorFlags.PhotonArgs.OnEventColor)} {__0.customData.ToString().Pastel(CustomDebugger.ColorFlags.PhotonArgs.OnEventColor)}\n",CustomDebugger.LogLevel.Photon);
    }
}
#endif