using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppTMPro;
using UnityEngine;
using Object = UnityEngine.Object;

namespace JudePatch.Utils;

public class tmpro
{

    public static void EnableAll()
    {
        Il2CppReferenceArray<Object>? objects = Resources.FindObjectsOfTypeAll(Il2CppType.Of<TMP_Text>());

        AndromedaEngine.RecRoom.CustomDebugger.Log($"Found: {objects.Length}");

        for (int i = 0; i < objects.Length; i++)
        {
            var text = objects[i].Cast<TMP_Text>();

            if (text == null)
                continue;
            
            text.richText = true;
            AndromedaEngine.RecRoom.CustomDebugger.Log(
                $"Caught TMPro::{text.gameObject.name}"
            );
        }
    }
}