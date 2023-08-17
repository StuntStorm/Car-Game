using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public List<Camera> cameras = new List<Camera>();
    private int currentCameraIndex = 0;

    private void Start()
    {
        // Make sure at least one camera is active at the beginning
        if (cameras.Count > 0)
        {
            cameras[currentCameraIndex].gameObject.SetActive(true);
            SetOtherCamerasInactive(currentCameraIndex);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            // Toggle cameras
            currentCameraIndex = (currentCameraIndex + 1) % cameras.Count;
            cameras[currentCameraIndex].gameObject.SetActive(true);
            SetOtherCamerasInactive(currentCameraIndex);
        }
    }

    private void SetOtherCamerasInactive(int activeIndex)
    {
        for (int i = 0; i < cameras.Count; i++)
        {
            if (i != activeIndex)
            {
                cameras[i].gameObject.SetActive(false);
            }
        }
    }
}
