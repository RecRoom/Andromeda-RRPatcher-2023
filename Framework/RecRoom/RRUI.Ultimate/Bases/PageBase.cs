using Il2CppRRUI;

namespace AndromedaEngine.RecRoom.RRUI.Ultimate;

public class PageBase
{
    public static PageWrapper? PageDebugUI()
    {
        foreach (var VARIABLE in UnityEngine.Object.FindObjectsOfType<PageWrapper>())
        {
            if (VARIABLE.name.StartsWith("Page: (DebugCommandsDevToolsPage)") && VARIABLE.name.EndsWith("(Clone)"))
            {
                return VARIABLE;
            }
        }
        return null;
    }
}