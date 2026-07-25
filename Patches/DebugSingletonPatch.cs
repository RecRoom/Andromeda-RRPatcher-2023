using HarmonyLib;

namespace JudePatch.Patches;
[HarmonyPatch(typeof(UnityEngine.Debug), nameof(UnityEngine.Debug.isDebugBuild), MethodType.Getter)]
public class DebugSingletonPatch2
{
    public static bool Prefix(bool __result)
    {
        __result = true;
        return false;
    }
}
[HarmonyPatch(typeof(UnityEngine.Debug), nameof(UnityEngine.Debug.developerConsoleVisible), MethodType.Setter)]
public class DebugSingletonPatch3
{
    public static bool Prefix(ref bool value)
    {
        value = true;
        return false;
    }
}
