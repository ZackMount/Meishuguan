using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSwitchLight : MonoBehaviour {

    public bool isStartOn;

    public GameObject lightObj;

    public GameObject emissionObj;

    private Material emissionMaterial;

    public float switchTime;

    public float delayTime;

    private bool isOn;

    void Awake()
    {
        Init();
    }

    void Init()
    {
        if (emissionObj != null)
            emissionMaterial = emissionObj.GetComponent<MeshRenderer>().material;
    }

    private void Start()
    {
        ChangeEnvLight(isStartOn);
        InvokeRepeating("SwitchEnvLight", delayTime, switchTime);
    }

    void ChangeEnvLight(bool bRet)
    {
        if (!bRet)
            CloseLight();
        else
            OpenLight();
    }

    void SwitchEnvLight()
    {
        if (isOn)
            CloseLight();
        else
            OpenLight();
    }

    void CloseLight()
    {
        lightObj.SetActive(false);
        isOn = false;
        if (emissionMaterial != null)
            emissionMaterial.SetColor("_EmissionColor", Color.black);
    }

    void OpenLight()
    {
        lightObj.SetActive(true);
        isOn = true;
        if (emissionMaterial != null)
        {
            emissionMaterial.SetColor("_EmissionColor", Color.white);
        }
    }
}
