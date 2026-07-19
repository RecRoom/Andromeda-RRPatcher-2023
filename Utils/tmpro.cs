using Il2CppInterop.Runtime;
using Il2CppTMPro;
using UnityEngine;
namespace JudePatch.Utils;

public class tmpro
{

    public static void EnableAll()
    {
        var objects = Resources.FindObjectsOfTypeAll(Il2CppType.Of<TMP_Text>());

        AndromedaEngine.RecRoom.CustomDebugger.Log($"Found: {objects.Length}");

        for (int i = 0; i < objects.Length; i++)
        {
            var text = objects[i].Cast<TMP_Text>();

            if (text == null)
                continue;
            
            text.richText = true;
            if (text.text.Contains("Saija"))
            {
                text.SetText("<color=red>Saija</color>");
            }
            AndromedaEngine.RecRoom.CustomDebugger.Log(
                $"Caught TMPro::{text.gameObject.name}"
            );
        }
    }
}