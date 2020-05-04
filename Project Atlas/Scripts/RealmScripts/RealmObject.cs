/*
 * Created by: Hunter Duncan
 * Start date: 1/10/2019
 * Edits: Hunter Duncan-1/11/2019, Hunter Duncan-1/12/2019, Hunter Duncan-1/14/2019
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealmObject : MonoBehaviour
{
    [Tooltip("The object visible in the normal realm")]
    public GameObject normalObject;
    [Tooltip("The object visible in other realm")]
    public GameObject realmObject;
    public GameObject RealmEnemy;
    Vector3 startPos;
    public Vector3 offsetPos; // amount the object is offset
    Vector3 startScale;
    Vector3 endPos = new Vector3(0, 0, 0);
    Vector3 endScale = new Vector3(1, 1, 1);
    public Vector3 offsetScale; // amount object is scaled by.

    bool realmSwap = false;
    
    RealmManager rM;

    private void Start()
    {
         
        startPos = transform.position;
        startScale = transform.localScale;
        rM = FindObjectOfType<RealmManager>();
        endPos = startPos + offsetPos;
        endScale = startScale + offsetScale;
    }

    private void Update()
    {
        //Debug Key
        if (Input.GetKeyDown(KeyCode.Space))
        {
            realmSwap = !realmSwap;           
        }

        RealmSwap();
    }

    void RealmSwap()
    {
        if (realmSwap)
        {           
            rM.PositionLerp(gameObject, startPos, endPos);
            rM.ShapeScale(gameObject, startScale, endScale);
            if (normalObject && realmObject !=null)
            {
                normalObject.SetActive(false);
                realmObject.SetActive(true);               
            }
            if (RealmEnemy != null) 
            {
                RealmEnemy.SetActive(true); // set enemies active
            }
        }
        else
        {
            rM.PositionLerp(gameObject, startPos, endPos);
            rM.ShapeScale(gameObject, startScale, endScale);
            if (normalObject && realmObject != null)
            {
                normalObject.SetActive(true);
                realmObject.SetActive(false);
            }
            if ( RealmEnemy != null)
            {
                RealmEnemy.SetActive(false);  //set enemies to inactive
            }
        }
    }
   
}