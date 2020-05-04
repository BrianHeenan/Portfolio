using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [Tooltip("Place LargeMap from under GameUI here.")]
    public GameObject map;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (map.activeInHierarchy == false && Input.GetKeyDown(KeyCode.M))
        {
            map.SetActive(true);
        }
        else if  (map.activeInHierarchy == true && Input.GetKeyDown(KeyCode.M))
        {
                map.SetActive(false);
        }
       
    }

    
}
