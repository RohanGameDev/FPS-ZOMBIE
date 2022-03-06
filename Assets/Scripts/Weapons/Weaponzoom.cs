using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Weaponzoom : MonoBehaviour
{

    [SerializeField] Camera fpscamera;
    [SerializeField] RigidbodyFirstPersonController fpsController;
    [SerializeField] float ZoomedOut = 60f;
    [SerializeField] float ZoomedIn = 20f;
    [SerializeField] float zoomOutSensitivity = 2f;
    [SerializeField] float zoomInSensitivity = 0.5f;

    bool zoomInToggle = false;

    private void OnDisable()
    {
        ZoomOut();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (zoomInToggle == false)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }
        }
    }

    private void ZoomOut()
    {
        zoomInToggle = false;
        fpscamera.fieldOfView = ZoomedOut;
        fpsController.mouseLook.XSensitivity = zoomOutSensitivity;
        fpsController.mouseLook.YSensitivity = zoomOutSensitivity;
    }

    private void ZoomIn()
    {
        zoomInToggle = true;
        fpscamera.fieldOfView = ZoomedIn;
        fpsController.mouseLook.XSensitivity = zoomInSensitivity;
        fpsController.mouseLook.YSensitivity = zoomInSensitivity;
    }
}
