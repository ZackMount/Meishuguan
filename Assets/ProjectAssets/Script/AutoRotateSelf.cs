using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotateSelf : MonoBase {

    public Vector3 rotateDirection;

    private void Awake()
    {
        m_transform = transform;
    }

    private void FixedUpdate()
    {
        m_transform.Rotate(rotateDirection);
    }
}
