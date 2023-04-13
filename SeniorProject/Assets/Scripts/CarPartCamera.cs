using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarPartCamera : MonoBehaviour
{
    public Camera TopCamera;
    public Camera LeftCamera;
    public Camera RightCamera;

    private void Start()
    {
       EnableTopCamera();
    }


    public void EnableLeftCamera()
    {
        LeftCamera.enabled = true;
        RightCamera.enabled = false;
        TopCamera.enabled = false;
    }

    public void EnableRightCamera()
    {
        LeftCamera.enabled = false;
        RightCamera.enabled = true;
        TopCamera.enabled = false;
    }

    public void EnableTopCamera()
    {
        LeftCamera.enabled = false;
        RightCamera.enabled = false;
        TopCamera.enabled = true;
    }
}
