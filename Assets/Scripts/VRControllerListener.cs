using UnityEngine.SceneManagement;
using Valve.VR;

public class VRControllerListener : Singleton<VRControllerListener>
{

    void Start()
    {
        DontDestroyOnLoad(this);
        BrushManager.ShowDrawTools(false);
    }
    public static void SceneChanged(string name)
    {
        if (name == "Night")
        {
            BrushManager.ShowDrawTools(true);

            SteamVR_Actions.default_GrabPinch.AddOnStateDownListener(BrushManager.StartDraw, SteamVR_Input_Sources.RightHand);

            SteamVR_Actions.default_GrabPinch.AddOnStateUpListener(BrushManager.StopDraw, SteamVR_Input_Sources.RightHand);

            SteamVR_Actions.default_GrabGrip.AddOnStateUpListener(BrushManager.PickUpColor, SteamVR_Input_Sources.RightHand);

            SteamVR_Actions.default_GrabGrip.AddOnStateUpListener(BrushManager.ClearStroke, SteamVR_Input_Sources.LeftHand);
        }
        else
        {
            BrushManager.ShowDrawTools(false);
        }


    }
}
