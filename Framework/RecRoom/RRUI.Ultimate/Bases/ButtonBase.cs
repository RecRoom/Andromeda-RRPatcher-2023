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
        foreach (var VARIABLE in UnityEngine.Object.FindObjectsOfType<Transform>(true))
        {
            if (VARIABLE.name == "Debug" && VARIABLE.transform.parent.name == "Dev Tools")
            {
                return VARIABLE.gameObject;
            }

          
        }
        return null;
    }
}