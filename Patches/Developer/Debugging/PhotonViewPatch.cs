#if  DEBUG
using System.Reflection;
using System.Text;
using AndromedaEngine.RecRoom;
using HarmonyLib;
using Il2Cpp;
using MelonLoader.Pastel;
namespace JudePatch.Patches.Developer.Debugging;

[Obfuscation(Exclude = true, ApplyToMembers =  true)]
[HarmonyPatch(typeof(Il2Cpp.IMEBNJHGJBJ), nameof(IMEBNJHGJBJ.OBGCIMIGCHP))]
public class PhotonViewPatch
{


    public static void Postfix(Il2CppPhoton.Pun.PhotonView __0, string __1, Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray<Il2CppSystem.Object> __2, string __3)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("────────────────────");
        sb.AppendLine("static void Il2Cpp.IMEBNJHGJBJ::OBGCIMIGCHP(Il2CppPhoton.Pun.PhotonView FKGNAFCFFNM, string ANCOFDIMJCE, Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray<Il2CppSystem.Object> BOCHPOPGOII, string KLCFNFHCDAI)");
        sb.Append($" ─ {"PhotonView".Pastel(CustomDebugger.ColorFlags.PhotonArgs.RPCEventColor)} : ").AppendLine(__0?.ToString() ?? "null");
        sb.Append($" ─ {"RPCName".Pastel(CustomDebugger.ColorFlags.PhotonArgs.RPCEventColor)}: ").AppendLine(__1?.ToString() ?? "null");
        sb.Append($" ─ {"ObjectData".Pastel(CustomDebugger.ColorFlags.PhotonArgs.RPCEventColor)}: ").AppendLine(__2?.ToString() ?? "null");
        sb.Append($" ─ {"Player".Pastel(CustomDebugger.ColorFlags.PhotonArgs.RPCEventColor)}: ").AppendLine(__3?.ToString() ?? "null");
        CustomDebugger.Log(sb.ToString(), CustomDebugger.LogLevel.PhotonView);

    }

}
#endif