using AndromedaEngine;
using HarmonyLib;
using Il2CppCodeStage.AntiCheat.ObscuredTypes;
using Il2CppRecRoom.Debugging;
using Il2CppRecRoom.Systems.PlayerRoles;
using Il2CppRecRoom.Tools;
using Il2CppRRUI.Data;

namespace JudePatch.Patches;
/*[HarmonyPatch(typeof(DebugSingleton), nameof(DebugSingleton.INJIGLBOGBI))]
public class DebugSingletonPatch
{
    public static bool Prefix(ref bool __result)
    {
        __result = true;
        return false;
    }
}*/
[HarmonyPatch(typeof(GlobalModel), nameof(GlobalModel.IsDebugBuild), MethodType.Getter)]
public class DebugSingletonPatch1
{
    public static bool Prefix(ref bool __result)
    {
        return false;
    }
}
[HarmonyPatch(typeof(MakerPen), nameof(MakerPen.CanPlayerCreateWithMakerPen))]
public class DebugSingletonPatch2
{
    public static bool Prefix(ref bool __result)
    {
        Debug.Console.Log($"[MP] -> {__result}", Debug.Console.LogLevel.Info);
        __result = true;
        return false;
    }
}