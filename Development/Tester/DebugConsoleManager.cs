using AndromedaEngine.RecRoom.RRUI.Ultimate;
using Il2Cpp;
using Il2CppRecRoom.Debugging;
using Il2CppRRUI;
using Il2CppTMPro;
using JudePatch.Utils;
using JudePatch.Utils.Wrappers;
using UnityEngine;
using Action = Il2CppSystem.Action;
using Debug = AndromedaEngine.Debug;

namespace JudePatch.Development.Tester;

public class DebugConsoleManager : MonoBehaviour
{
    public static DebugCommandConfig? Config { get; set; }
    public static DebugConsoleManager Instance { get; private set; }

    #region UNITY_UI_ELEMENTS

    public static Canvas? rootCanvas { get; set; }
    public TMP_InputField TargetInputField { get; set; }
    public MultiGraphicButton ExecuteButton { get; set; } = new();

    #endregion
   

    private void Awake()
    {
        
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        Config = new();
        Config.commands = new();
        DontDestroyOnLoad(gameObject);
    }

   
    public void EnableCommands()
    {
        Config?.Register(new DebugCommand("Internal", "Internal"), () =>
        {
            Console.Beep(405, 203);
        });
    }
    public void Start()
    {
       ExecuteButton.onClick.AddListener(new System.Action(() =>
       {
           Execute(TargetInputField.text);
       }));

    }
    public void Update()
    {
        
    }
    
    public static void Search()
    {
        
    }

    /*
    public static Action OnClickButton => (() =>
    {

    });
    */
    
    public  void Execute(string command)
    {
        foreach (var variable in Config.commands)
        {
            if (variable.Key.Name == command)
                variable.Value.Invoke();
        }
    }
}