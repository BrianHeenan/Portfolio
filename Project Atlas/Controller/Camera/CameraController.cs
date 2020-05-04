using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float stickMinZoom, stickMaxZoom;

    public float swivelMinZoom, swivelMaxZoom;

    public float smoothSpeed = 10f;

    public float rotationSpeed;

    Transform swivel, stick;

    public Transform player;

    public Vector3 offset;

    float zoom = 1f;

    float rotationAngle;

    void Awake()
    {
        swivel = transform.GetChild(0);
        stick = swivel.GetChild(0);
    }

    void Start()
    {
        transform.position = player.position;
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            float zoomDelta = Input.GetAxis("Mouse ScrollWheel");
            if (zoomDelta != 0f)
            {
                AdjustZoom(zoomDelta);
            }

            float rotationDelta = Input.GetAxis("Mouse X");
            if (rotationDelta != 0f)
            {
                AdjustRotation(rotationDelta);
            }
        }
    }

    void FixedUpdate()
    {
        AdjustPosition();
        LookAt();
    }

    void AdjustZoom(float delta)
    {
        zoom = Mathf.Clamp01(zoom + delta);

        float distance = Mathf.Lerp(stickMinZoom, stickMaxZoom, zoom);
        stick.localPosition = new Vector3(0f, 0f, distance);

        float angle = Mathf.Lerp(swivelMinZoom, swivelMaxZoom, zoom);
        swivel.localRotation = Quaternion.Euler(angle, 0f, 0f);
    }

    void AdjustRotation(float delta)
    {
        rotationAngle += delta * rotationSpeed * Time.deltaTime;
        if (rotationAngle < 0f)
        {
            rotationAngle += 360f;
        }
        else if (rotationAngle >= 360f)
        {
            rotationAngle -= 360f;
        }
        transform.localRotation = Quaternion.Euler(0f, rotationAngle, 0f);
    }

    void AdjustPosition()
    {
        //Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, player.position, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }

    void LookAt()
    {
        Camera.main.transform.LookAt(player);
    }
}
