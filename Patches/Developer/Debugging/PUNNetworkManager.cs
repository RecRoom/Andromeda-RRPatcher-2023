using HarmonyLib;
using Il2Cpp;
using JudePatch.Utils;

namespace JudePatch.Patches.Developer.Debugging;

[HarmonyPatch]
public class PUNNetworkManagerPatch
{
    [HarmonyPostfix, HarmonyPatch(typeof(PUNNetworkManager), nameof(PUNNetworkManager.OnPhotonPlayerConnected))]
    public static void OnPlayerJoined(ref PEOADAHMPGD __0)
    {
        try
        { 
            PEOADAHMPGD _player = __0;
            var player = GameUtils.Player.GetPlayerPhoton(__0);
           GameUtils.Chatbox.MessagePlayerLocal(0,"Server", $"{player.Name} <color=green>Connected!</color>");
        }
        catch
        {
            
        }
    }
    [HarmonyPostfix, HarmonyPatch(typeof(PUNNetworkManager),nameof(PUNNetworkManager.OnPhotonPlayerDisconnected))]
    public static void OnPlayerLeft(ref PEOADAHMPGD __0)
    {
        try
        {
            PEOADAHMPGD _player = __0;
            var player = GameUtils.Player.GetPlayerPhoton(__0);
            GameUtils.Chatbox.MessagePlayerLocal(0,"Server", $"{player.Name} <color=red>Disconnected</color>");
        }
        catch
        {
            
        }
    }
}