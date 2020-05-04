using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FindCameraConfines : MonoBehaviour
{
    CinemachineVirtualCamera virtualCamera;
    CinemachineConfiner confiner;

    private void Start()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        confiner = virtualCamera.GetComponent<CinemachineConfiner>();
        confiner.m_BoundingVolume = FindObjectOfType<CameraConfines>().GetComponent<Collider>();
    }
}
