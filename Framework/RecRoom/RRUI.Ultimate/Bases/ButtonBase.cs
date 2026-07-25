using Il2CppAGUI.StackedUI;
using Il2CppRecRoom.Players.Watch;
using Il2CppRRUI;
using UnityEngine;


namespace AndromedaEngine.RecRoom.RRUI.Ultimate;

public class ButtonBase
{
    public static ButtonBase Instance { get; private set; }

    public static GameObject? DebugButton()
    {
        foreach (var DebugButton in UnityEngine.Object.FindObjectsOfType<Transform>(true))
        {
            if (DebugButton.name == "Debug" && DebugButton.transform.parent.name == "Dev Tools")
            {
                DebugButton.gameObject.SetActive(true);
                return DebugButton.gameObject;
            }

          
        }
        return null;
    }
}