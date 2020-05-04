using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hidden_Event : MonoBehaviour
{
    public GameObject hiddenArea;    //walls to show
    public GameObject WallsToHide;   //walls to hide


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerHealth>())
        {
            WallsToHide.SetActive(false);
            hiddenArea.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
