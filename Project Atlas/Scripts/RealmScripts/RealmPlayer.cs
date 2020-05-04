/*
 * Created by: Hunter Duncan
 * Start date: 1/10/2019
 * Edits: Hunter Duncan-1/11/2019, Hunter Duncan-1/12/2019, Hunter Duncan-1/14/2019
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealmPlayer : MonoBehaviour
{
    Color startColor;
    [SerializeField]
    Color endColor = new Color(0, 0, 0);

    bool realmSwap = false;

    RealmManager rM;

    private void Start()
    {
        startColor = GetComponent<Renderer>().material.color;
        rM = FindObjectOfType<RealmManager>();
    }

    private void Update()
    {
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
            rM.ColorLerp(gameObject, startColor, endColor);
        }
        else
        {
            rM.ColorLerp(gameObject, startColor, endColor);
        }
    }
}