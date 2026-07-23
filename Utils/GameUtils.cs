using Il2Cpp;
using Il2CppRecRoom;
using Il2CppRecRoom.Audio;
using Il2CppRecRoom.Avatars;
using Il2CppRecRoom.Avatars.Outfit;
using Il2CppRecRoom.Core.Studio;
using Il2CppRecRoom.DataStructures;
using Il2CppRecRoom.Players;
using JudePatch.Utils.Wrappers;
using Silly18.RUltimateSDK.Templates.Utils;
using UnityEngine;

namespace JudePatch.Utils;

public class GameUtils
{
    public static class Player
    {
        public static Il2Cpp.Player GetLocalPlayer => Il2Cpp.Player.NFIBBCBDIND;

        public static PhotonPlayer GetPlayerPhoton(Il2Cpp.Player player)
        {
            PhotonPlayer p = new();

            return p;
        }
        public static PhotonPlayer GetPlayerPhoton(PEOADAHMPGD player)
        {
           return new()
           {
               Name = player.LGPGHKCEEPD,
               PlayerId = player.FPJLDBHDLFP,
               PhotonViewId = "Failure",
           };

        }
    }
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
                AndromedaEngine.Debug.Console.Exception(e);
            }
        #if DEBUG
                AndromedaEngine.Debug.Console.Log($"[{vault.GetType()}] {guid} Added!\n");   
        #endif
        }
    }

    public static class Radio
    {
        public static void AddTrack(Il2CppRecRoom.Radio radio, string? path)
        {
            if (path != null)
            {
                try
                {
                    AudioClip audioClip = EngineUtils.Assets.LoadAsset<AudioClip>(new Uri(path));
                    List<SFXTrack> sfxTracks = radio.tracks.ToList();
                    SFXTrack? track = ScriptableObject.CreateInstance<SFXTrack>();

                    track.clip = audioClip;
                    track.friendlyName = audioClip.name;
                    track.clipType = SFXTrack.LCLANDIBHAB.Music;
                    
                    sfxTracks.Add(track);
                    radio.tracks = sfxTracks.ToArray();

                }
                catch (Exception e)
                {
                    AndromedaEngine.Debug.Console.Exception("SFXTrackAdder", e);
                }
            }

        }
        
    }

    public static class Chatbox
    {
        public static void MessagePlayerLocal(int playerId, string username, string text) =>
            Il2Cpp.Player.NFIBBCBDIND.playerEmotes.ReceiveBroadcastRoomChat(playerId, username,PlayerEmotes.GDAPDNFPNAL.None, text);
      
    }
}