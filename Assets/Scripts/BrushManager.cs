using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class BrushManager : MonoBehaviour
{
    static BrushManager instance;

    public GameObject ColorPalette;

    public GameObject StartPoint;

    public GameObject StrokePrefabs;

    private GameObject cur_stroke;

    private List<GameObject> strokeList = new List<GameObject>();

    private Color InitColor = Color.white;

    void Start()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        instance = this;
        DontDestroyOnLoad(this);

    }
    public static void ShowDrawTools(bool state)
    {
        instance.ColorPalette.SetActive(state);
        instance.StartPoint.SetActive(state);
    }
    public static void PickUpColor(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        Interactable interactable = Player.instance.rightHand.hoveringInteractable;
        if (interactable != null && interactable.CompareTag("Pigment"))
        {
            instance.InitColor = interactable.transform.GetComponent<PickUpColorPC>().strokeColor;
        }
    }

    public static void StopDraw(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        if (instance.cur_stroke != null)
        {
            Destroy(instance.cur_stroke.GetComponent<StrokePC>());
        }
    }

    public static void StartDraw(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        if (instance.cur_stroke != null)
        {
            Destroy(instance.cur_stroke.GetComponent<StrokePC>());
        }

        instance.cur_stroke = Instantiate(instance.StrokePrefabs, instance.StartPoint.transform.position, Quaternion.identity);
        instance.strokeList.Add(instance.cur_stroke);
        instance.cur_stroke.GetComponent<StrokePC>().Target = instance.StartPoint.transform;
        instance.cur_stroke.GetComponent<TrailRenderer>().material.color = instance.InitColor;
    }
    public static void ClearStroke(SteamVR_Action_Boolean fromAction, SteamVR_Input_Sources fromSource)
    {
        foreach (var item in instance.strokeList)
        {
            Destroy(item);
        }
        instance.strokeList.Clear();
    }
}
