using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public GameObject ResetBtn;
    public GameObject BackBtn;
    private GameObject CurBtn;
    public GameObject SystemMenu;
    private bool isMenuShow = false;
    private bool isTextHintShow = false;
    void Start()
    {
        DontDestroyOnLoad(this);
        SystemMenu.SetActive(false);
        Invoke("ShowAllButtonHints", 5.0f);
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneUnloaded += OnSceneUnLoaded;
    }

    private void OnSceneUnLoaded(Scene arg0)
    {
        HideAllButtonHints();
        SteamVR_Actions.default_ShowMenu.RemoveOnStateUpListener(SetControlerButtonHint, SteamVR_Input_Sources.RightHand);
        SteamVR_Actions.default_ShowMenu.RemoveOnStateUpListener(LeftMenuActionHandler, SteamVR_Input_Sources.LeftHand);

    }

    private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        if (arg0.name == "Night")
        {
            ShowAllButtonHints();
            SteamVR_Actions.default_ShowMenu.AddOnStateUpListener(LeftMenuActionHandler, SteamVR_Input_Sources.LeftHand);
        }
        SteamVR_Actions.default_ShowMenu.AddOnStateUpListener(SetControlerButtonHint, SteamVR_Input_Sources.RightHand);
    }

    private void LeftMenuActionHandler(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        if (!isMenuShow)
        {
            ShowMenu();
        }
        else
        {
            HideMenu();
        }
    }

    private void HideMenu()
    {
        SystemMenu.SetActive(false);
        isMenuShow = false;
        SteamVR_Actions.default_MenuMoveDown.RemoveOnStateUpListener(MenuMoveDownActionHandler, SteamVR_Input_Sources.LeftHand);
        SteamVR_Actions.default_MenuMoveUp.RemoveOnStateUpListener(MenuMoveUpActionHandler, SteamVR_Input_Sources.LeftHand);
        SteamVR_Actions.default_GrabPinch.RemoveOnStateUpListener(LeftGranbPinchActionHandler, SteamVR_Input_Sources.LeftHand);


    }

    private void ShowMenu()
    {
        SystemMenu.SetActive(true);
        isMenuShow = true;
        SteamVR_Actions.default_MenuMoveDown.AddOnStateUpListener(MenuMoveDownActionHandler, SteamVR_Input_Sources.LeftHand);
        SteamVR_Actions.default_MenuMoveUp.AddOnStateUpListener(MenuMoveUpActionHandler, SteamVR_Input_Sources.LeftHand);
        SteamVR_Actions.default_GrabPinch.AddOnStateUpListener(LeftGranbPinchActionHandler, SteamVR_Input_Sources.LeftHand);
    }

    private void LeftGranbPinchActionHandler(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        throw new NotImplementedException();
    }

    private void MenuMoveUpActionHandler(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        if (CurBtn == null)
        {
            CurBtn = BackBtn;
        }
        else
        {
            Selectable sel = CurBtn.GetComponent<Button>().FindSelectableOnDown();
            CurBtn = sel.gameObject;
        }
        EventSystem.current.SetSelectedGameObject(CurBtn);
    }

    private void MenuMoveDownActionHandler(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        if (CurBtn == null)
        {
            CurBtn = ResetBtn;
        }
        else
        {
            Selectable sel = CurBtn.GetComponent<Button>().FindSelectableOnUp();
            CurBtn = sel.gameObject;
        }
        EventSystem.current.SetSelectedGameObject(CurBtn);
    }

    public void SetControlerButtonHint(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        if (!isTextHintShow)
        {
            ShowAllButtonHints();
        }
        else
        {
            HideAllButtonHints();
        }
    }

    private void HideAllButtonHints()
    {
        ControllerButtonHints.HideAllTextHints(Player.instance.rightHand);
        ControllerButtonHints.HideAllTextHints(Player.instance.leftHand);
        isTextHintShow = false;
    }

    private void ShowAllButtonHints()
    {
        ControllerButtonHints.ShowTextHint(Player.instance.rightHand, SteamVR_Actions.default_ShowMenu, "打开/关闭操作说明");
        ControllerButtonHints.ShowTextHint(Player.instance.rightHand, SteamVR_Actions.default_Teleport, "移动");


        ControllerButtonHints.ShowTextHint(Player.instance.leftHand, SteamVR_Actions.default_GrabPinch, "交互");
        ControllerButtonHints.ShowTextHint(Player.instance.leftHand, SteamVR_Actions.default_Teleport, "移动");
        if (SceneManager.GetActiveScene().name == "Night")
        {
            ControllerButtonHints.ShowTextHint(Player.instance.rightHand, SteamVR_Actions.default_GrabPinch, "笔刷");
            ControllerButtonHints.ShowTextHint(Player.instance.rightHand, SteamVR_Actions.default_GrabGrip, "选取颜色");
            ControllerButtonHints.ShowTextHint(Player.instance.leftHand, SteamVR_Actions.default_ShowMenu, "打开/关闭操作说明");
            ControllerButtonHints.ShowTextHint(Player.instance.rightHand, SteamVR_Actions.default_Teleport, "移动");
            ControllerButtonHints.ShowTextHint(Player.instance.leftHand, SteamVR_Actions.default_Teleport, "移动");
            ControllerButtonHints.ShowTextHint(Player.instance.leftHand, SteamVR_Actions.default_GrabGrip, "清空笔刷");

        }
        else if (SceneManager.GetActiveScene().name == "SampleScene")
        {
            ControllerButtonHints.ShowTextHint(Player.instance.rightHand, SteamVR_Actions.default_GrabPinch, "交互");
        }

        isTextHintShow = true;
    }
}
