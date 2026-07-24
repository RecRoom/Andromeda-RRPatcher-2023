using AndromedaEngine.RecRoom.RRUI.Ultimate;
using Il2Cpp;
using Il2CppRecRoom.Debugging;
using Il2CppRRUI;
using Il2CppTMPro;
using JudePatch.Utils.Wrappers;
using UnityEngine;
using Action = Il2CppSystem.Action;
using Debug = AndromedaEngine.Debug;

namespace JudePatch.Development.Tester;

public class DebugConsoleManager : MonoBehaviour
{
    private DebugConsoleCommandConfig? Config;
    
    public static DebugConsoleManager Instance { get; private set; }
    public static Canvas? rootCanvas { get; set; }
    public TMP_InputField TargetInputField { get; set; }
    public MultiGraphicButton ExecuteButton { get; set; } = new();
   

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void Start()
    {
        ExecuteButton.onClick.AddListener(new System.Action(() =>
        {
            if (TargetInputField.text != null)
            {
               Tool.PhotonInstantiate(TargetInputField.text, Player.NFIBBCBDIND.trackingSpace.transform.position, Player.NFIBBCBDIND.trackingSpace.transform.rotation, 1f); 
            }
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
    
    public static void Execute(string command)
    {
        
    }
}