using JudePatch.Utils;
using MelonLoader;
using MelonLoader.Pastel;

[assembly: MelonInfo(typeof(Entry), "RR.XPatch", "1.0.0", "Various Devs", null)]

public class Entry : MelonMod
{
    private HarmonyLib.Harmony harmony = new("com.halo.xpatch");
    
    public override void OnInitializeMelon()
    {
        try
        {
            AndromedaEngine.Debug.Console.Log(
                "Initialized!\n",
                AndromedaEngine.Debug.Console.LogLevel.Debug
            );
        }
        catch (Exception e)
        {
            AndromedaEngine.Debug.Console.Exception(e);
        }
    }
    
    public override void OnSceneWasLoaded(int buildIndex, string sceneName)
    {
        /*switch (buildIndex, sceneName)
        {
            
            case (1,"2"): 
                return;
        }*/
        AndromedaEngine.Debug.Console.Base($"" + 
        $"[{"SceneManager".Gradient(System.Drawing.Color.Red, System.Drawing.Color.Blue)}]" +
        $"{$" [{buildIndex}]".Gradient(System.Drawing.Color.Red, System.Drawing.Color.Blue)} " +
        $" {sceneName} Loaded!\n");
    }

    public override void OnSceneWasUnloaded(int buildIndex, string sceneName)
    {
        
    }
    
    public override void OnApplicationQuit() =>
        harmony.UnpatchSelf();
   
}