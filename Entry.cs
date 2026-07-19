using HarmonyLib;
using MelonLoader;

[assembly: MelonInfo(typeof(JudePatch.Entry), "XPatch", "1.0.0", "Romance (Mostly Romance) & Puck", null)]

namespace JudePatch;

public class Entry : MelonMod
{
    private HarmonyLib.Harmony harmony = new("com.romance.xpatch");

    public override void OnInitializeMelon()
    {
        try
        {
            MelonLoader.Pastel.ConsoleExtensions.Enable();
            AndromedaEngine.Debug.Console.Log(
                "Initialized!\n",
                AndromedaEngine.Debug.Console.LogLevel.Debug
            );
        }
        catch (Exception e)
        {
            AndromedaEngine.Debug.Console.Log(e);
        }
    }

    public override void OnApplicationQuit()
    {
        harmony.UnpatchSelf();
    }
}