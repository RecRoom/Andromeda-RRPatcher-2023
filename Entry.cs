
using MelonLoader;

[assembly: MelonInfo(typeof(JudePatch.Entry),"JudePatch","1.0.0","Romance (Mostly Romance) & Puck",null)]

namespace JudePatch;
public class Entry : MelonMod
{
  
  HarmonyLib.Harmony Hook = new ("JudeJudeJudeJudeJudeJude");
  public override void OnInitializeMelon()
  {
      Hook.PatchAll();
  }
  public override void OnApplicationQuit()
  {
      Hook.UnpatchSelf();
  }
}