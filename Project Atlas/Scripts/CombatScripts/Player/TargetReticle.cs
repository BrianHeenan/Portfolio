/*
 * Created by: Leslie Gunsolus
 * Start Date: 1/23/19
 * 
 * Contributions: Hunter Duncan-1/25/19
 * edited by Lloyd Jarrell on 1/27/2019 (adjusted Instantiate to have skills spawn at spawn point. commented out the inputkeys.)
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetReticle : MonoBehaviour
{    
    public new Camera camera;         //Camera to drag into inspector to draw the ray from.
    //public float distance = 1.0f;
    public bool initCamDist = false;  //camera distance
    public LayerMask hitLayers;
    public GameObject[] objToSpawn;
    public Transform topspawnPoint;
    
    private float actualDistance;    //actual distance 
    
    // Update is called once per frame
    void Update()
    {
        RaycastHit rayHit;

       

        Vector3 mousePosition = Input.mousePosition;
       
        Ray ray = camera.ScreenPointToRay(mousePosition);  //Ray from camera to mouse

        if (Physics.Raycast(ray, out rayHit, Mathf.Infinity,hitLayers))
        {
            //Vector3 objectHit = hit.transform.position;
            this.transform.position = rayHit.point;
        }

        
    }

}
