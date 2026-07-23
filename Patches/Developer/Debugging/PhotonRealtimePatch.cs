#if DEBUG
using System;
using System.Reflection;
using System.Text;
using AndromedaEngine;
using AndromedaEngine.RecRoom;
using HarmonyLib;
using Il2Cpp;
using Il2CppExitGames.Client.Photon;
using MelonLoader.Pastel;

namespace JudePatch.Patches.Developer.Debugging;
[Obfuscation(Exclude = true, ApplyToMembers =  true)]
[HarmonyPatch(typeof(HAJIHGCNMAG), nameof(HAJIHGCNMAG.OnEvent))]
public class PhotonRealtimePatch
{
    public static void Postfix(ref EventData __0)
    {
        try
        {
            StringBuilder sb = new();
            sb.AppendLine("");
            sb.AppendLine("────────────────────");
            sb.AppendLine($" ─ Code: {(__0?.Code.ToString() ?? "null").Pastel(CustomDebugger.ColorFlags.PhotonArgs.OnEventColor)}");
            sb.AppendLine($" ─ Sender: {(__0?.sender.ToString() ?? "null").Pastel(CustomDebugger.ColorFlags.PhotonArgs.OnEventColor)}");
            sb.AppendLine($" ─ CustomData: {(__0?.customData?.ToString() ?? "null").Pastel(CustomDebugger.ColorFlags.PhotonArgs.OnEventColor)}");
            sb.AppendLine("────────────────────");

            CustomDebugger.Log(sb.ToString(), CustomDebugger.LogLevel.Photon);
        }
        catch (Exception e)
        {
            AndromedaEngine.Debug.Console.Log(
                $"[{nameof(PhotonRealtimePatch)}]\n{e}",
                Debug.Console.LogLevel.Error);
        }
    }
}
#endif