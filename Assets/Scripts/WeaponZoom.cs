using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{

    [SerializeField] float mouseSensivity=2f;
    [SerializeField] float zoomFOV = 30f;
    [SerializeField] float zoomSensivity = 1f;
    float defaultFOV=60f;
    [SerializeField] RigidbodyFirstPersonController FPSController;
    
    /*private void OnEnable()
    {   
        Camera.main.fieldOfView = defaultFOV;           //Its working too with Static FOB
    }*/

        
    private void Start()
    {
        defaultFOV = Camera.main.fieldOfView;
        FPSController.mouseLook.XSensitivity = mouseSensivity;
        FPSController.mouseLook.YSensitivity = mouseSensivity;
        
        
    }
    private void OnDisable()
    {
        ReturnFOV();
    }


    private void Update()
    {
        if (Input.GetMouseButton(1))
            Zoom();
        else
            ReturnFOV();
    }
    public void ReturnFOV()
    {
        Camera.main.fieldOfView = defaultFOV;
        FPSController.mouseLook.XSensitivity = mouseSensivity;
        FPSController.mouseLook.YSensitivity = mouseSensivity;

    }


    private void Zoom()
    {
        Camera.main.fieldOfView = zoomFOV;
        FPSController.mouseLook.XSensitivity = zoomSensivity;
        FPSController.mouseLook.YSensitivity = zoomSensivity;

    }
}
