using System.Reflection;
using HarmonyLib;
using Il2CppRecRoom;
using JudePatch.Utils;

namespace JudePatch.Patches.Misc;
[Obfuscation(Exclude = true, ApplyToMembers =  true)]
[HarmonyPatch(typeof(Radio), nameof(Radio.Start))]
public class RadioPatch
{
    public static void Postfix(Radio __instance)
    {
        try
        {
            GameUtils.Radio.AddTrack(__instance, "https://files.mia7z.win/unlisted/songs/12%20Windows%2096%20-%20Landscaping.flac");
            GameUtils.Radio.AddTrack(__instance, "https://github.com/furrychiefkeef/rr/raw/refs/heads/master/02%20-%20Sport%20Funk.wav");
        }
        catch (Exception e)
        {
            
        }
       
    }
}