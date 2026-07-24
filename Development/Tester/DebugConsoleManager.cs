using Il2CppRecRoom.Debugging;
using UnityEngine;

namespace JudePatch.Development.Tester;

public class DebugConsoleManager : MonoBehaviour
{
    private DebugConsoleCommandConfig? Config;
    
    public DebugConsoleManager? Instance;
    public static Canvas? rootCanvas { get; set; }

    public void Awake()
    {
        if (Instance == null)
        {
            new GameObject("DebugConsoleManager").AddComponent<DebugConsoleManager>();
            Instance = this;
        }
    }

    public void Update()
    {
        
    }
    
    public static void Search()
    {
        
    }

    public static Action OnClickButton => (() =>
    {

    });
    
    public static void Execute(string command)
    {
        
    }
}