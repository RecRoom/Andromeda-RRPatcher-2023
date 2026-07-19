using System.Reflection;
using AndromedaEngine;
using MelonLoader;

[assembly: MelonInfo(typeof(JudePatch.Entry),"XPatch","1.0.0","Romance (Mostly Romance) & Puck",null)]

namespace JudePatch;
public class Entry : MelonMod
{
  
  
  public override void OnInitializeMelon()
  {
      MelonLoader.Pastel.ConsoleExtensions.Enable();
      AndromedaEngine.Debug.Console.Log("Initialized! \n", Debug.Console.LogLevel.Debug);
     
      try
      {
          HarmonyLib.Harmony.CreateAndPatchAll(Assembly.GetExecutingAssembly());
      }
      catch (Exception e)
      {
          AndromedaEngine.Debug.Console.Log(e);
      }
  }

  public override void OnApplicationQuit()
  {
      HarmonyLib.Harmony.UnpatchAll();
  }
}