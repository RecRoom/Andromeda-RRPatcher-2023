using Il2CppRRUI;

namespace AndromedaEngine.RecRoom.RRUI.Ultimate;

public class PageBase
{
    public static PageWrapper? PageDebugUI()
    {
        foreach (PageWrapper DevPage in UnityEngine.Object.FindObjectsOfType<PageWrapper>())
        {
            if (DevPage.name.StartsWith("Page: (DebugCommandsDevToolsPage)") && DevPage.name.EndsWith("(Clone)"))
            {
                return DevPage;
            }
        }
        return null;
    }
}