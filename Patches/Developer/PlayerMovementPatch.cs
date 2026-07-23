using HarmonyLib;
using Il2Cpp;
using Il2CppRecRoom.Core.Locomotion;

namespace JudePatch.Patches.Developer;

#if DEBUG

[HarmonyPatch(typeof(PlayerMovement), nameof(PlayerMovement.AddFlyEnabled))]
public class PlayerMovementPatch
{
    public static bool Prefix(ref bool __0, ref object __1, ref int __2)
    {
        __0 = true;
        __1 = Player.NFIBBCBDIND.trackingSpace;
        __2 = 9999;
        return true;
    }
}
#endif