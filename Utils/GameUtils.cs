using Il2CppRecRoom.Avatars;
using Il2CppRecRoom.Avatars.Outfit;

namespace JudePatch.Utils;

public class GameUtils
{
    public static class Avatar
    {
        public static void CreateAvatarColor(ColorVault vault, string guid, UnityEngine.Color color)
        {
            ColorVault.DDPMPGINCGI colorData;
            try
            {
                colorData = new ColorVault.DDPMPGINCGI
                {
                    NKJGAOKLDJG = new ColorToGuidSerializable { GuidString = guid, Color = color }
                };

                vault.JKGNLFNJMAB.Add(guid, colorData);
                vault.HKLJNJGPIMA.Add(colorData);
            }
            catch (Exception e)
            {
                AndromedaEngine.Debug.Console.Log(e);
            }
        #if DEBUG
                AndromedaEngine.Debug.Console.Log($"[SkinColor] {guid} Added!\n");   
        #endif
        }
    }
}