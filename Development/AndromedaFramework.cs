using UnityEngine;

namespace JudePatch.Development;

public class AndromedaFramework : MonoBehaviour
{
    public void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "<color=green>DEBUG</color>");
    }
}