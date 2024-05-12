using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoUVFlow : MonoBehaviour {
    public float ScrollSpeed = 5;

    private float offsetX = 0.0f;
    private float offsetY = 0.0f;

    public bool isMoveX;

    private Material flowMaterial;

    private void Awake()
    {
        flowMaterial = GetComponent<MeshRenderer>().material;
    }
    // Use this for initialization  
    void Start()
    {
        //float x_1 = 1.0f / countX;
        //float y_1 = 1.0f / countY;
        //flowMaterial.mainTextureScale = new Vector2(x_1, y_1);

    }

    // Update is called once per frame  
    void Update()
    {
        if(isMoveX)
        {
            offsetX+= ScrollSpeed/1000f;
            if (offsetX >= 1)
                offsetX = 0;
        }
        else
        {
            offsetY += ScrollSpeed / 1000f;
            if (offsetY >= 1)
                offsetY = 0;
        }
        flowMaterial.SetTextureOffset("_MainTex", new Vector2(offsetX, offsetY));

    }
}
