using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCullingCamera : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float distance = 10.0f;
    [SerializeField]
    private float height = 5.0f;
    public LayerMask cullingLayers;
    public Transform player;
    public Material transparencyMat;
    public Material originalMat;
    public Transform cullObject;
   
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<CullingPlaceHolder>().transform;
        target = player;
    }
    
    void LateUpdate()
    {
        if (!target)
        {
            return;
        }
        CameraClippingDetect();
    }

    public void UseTransparencyMat (Transform mat)
    {
        Renderer matRenderer;
        matRenderer = mat.GetComponent<Renderer>();
        matRenderer.sharedMaterial = transparencyMat;
    }

    public void UseNormalMat(Transform mat)
    {
        Renderer matRenderer;
        matRenderer = mat.GetComponent<Renderer>();
        matRenderer.sharedMaterial = originalMat;
    }

    public void CameraClippingDetect()
    {
        RaycastHit hit;
        Debug.DrawLine(target.position, transform.position, Color.red, 0.1f);

        if(Physics.Linecast(target.position,transform.position, out hit, cullingLayers, QueryTriggerInteraction.Ignore))
        {
            if(cullObject == null)
            {
                cullObject = hit.transform;
                if (originalMat == null)
                {
                    originalMat = cullObject.GetComponent<Renderer>().material;
                    UseTransparencyMat(hit.transform);
                }
                
            }
            else if (hit.transform != cullObject)
            {
                UseNormalMat(cullObject);
                cullObject = hit.transform;
                originalMat = cullObject.GetComponent<Renderer>().material;
                UseTransparencyMat(hit.transform);
                
            }

        }
        else
        {
            if (cullObject)
            {
                UseNormalMat(cullObject);
                cullObject = null;
                originalMat = null;
            }
        }
    }
}
