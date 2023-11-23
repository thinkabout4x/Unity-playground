using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLock : MonoBehaviour
{
    public enum RotationAxis 
    {
        MouseXandY = 0,
        MouseX = 1, 
        MouseY = 2
    }
    public RotationAxis axis = RotationAxis.MouseXandY;
    public float sensitivityhor = 9.0f;
    public float sensitivityver = 9.0f;

    public float vertmin = -45.0f;
    public float vertmax = 45.0f;
    private float vertrot = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (axis == RotationAxis.MouseX) {
            transform.Rotate(0, Input.GetAxis("Mouse X")*sensitivityhor, 0);
        }
        else if (axis == RotationAxis.MouseY) {
            vertrot -= Input.GetAxis("Mouse Y")*sensitivityver;
            vertrot = Math.Clamp(vertrot, vertmin, vertmax);
            float horizrot = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(vertrot,horizrot,0 );
        }
        else {
            vertrot -= Input.GetAxis("Mouse Y")*sensitivityver;
            vertrot = Math.Clamp(vertrot, vertmin, vertmax);

            float delta = Input.GetAxis("Mouse X")*sensitivityhor;
            float horizrot = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(vertrot, horizrot,0);
        }
    }
}
