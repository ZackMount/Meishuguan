using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIButtonDraw : MonoBehaviour
{
    void Start()
    {
        Button button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(Changescene);
    }
    private void Changescene()
    {
        GameManager.ChangeScene("SampleScene");
    }

    void Update()
    {

    }
}
