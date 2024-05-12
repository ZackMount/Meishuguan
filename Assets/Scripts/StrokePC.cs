using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrokePC : MonoBehaviour
{
    public Transform Target;
    private Transform _transform;
    // Start is called before the first frame update
    void Start()
    {
        _transform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        _transform.position= Target.position;
        _transform.localEulerAngles= Target.localEulerAngles;
    }
}