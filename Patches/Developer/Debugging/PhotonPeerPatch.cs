#if DEBUG
using System.Reflection;
using AndromedaEngine.RecRoom;
using HarmonyLib;
using Il2CppExitGames.Client.Photon;
using MelonLoader.Pastel;

namespace JudePatch.Patches.Developer.Debugging;

[Obfuscation(Exclude = true, ApplyToMembers =  true)]
[HarmonyPatch(typeof(PhotonPeer), nameof(PhotonPeer.SendOperation))]
public class PhotonPeerPatch
{
   public static bool Enable = false;

   public static bool Prefix(ref byte __0, ref Il2CppSystem.Collections.Generic.Dictionary<byte, Il2CppSystem.Object> __1, ref SendOptions __2)
   {
       if (Enable)
       {
           AndromedaEngine.RecRoom.CustomDebugger.Log($"│ {$"OpCode: {__0}".Pastel(CustomDebugger.ColorFlags.PhotonPeerColor)} Data: {__1}, SendOptions: {__2.DeliveryMode.ToString().Pastel(CustomDebugger.ColorFlags.PhotonPeerColor)}\n", CustomDebugger.LogLevel.PhotonPeer);
       }
       return true;
   }
   

}
#endif