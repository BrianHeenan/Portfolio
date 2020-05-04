using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrownPlacement : MonoBehaviour
{
    LevelProgression LP;

    // Start is called before the first frame update
    void Start()
    {
        LP = FindObjectOfType<LevelProgression>();
    }

    // Update is called once per frame
    void Update()
    {
       

        if(LP.LevelUnlocked[0] == true)
        {
            Destroy(this.gameObject);
        }

        
    }

    private void OnTriggerStay(Collider other)
    {
        LP.LevelUnlocked[0] = true;
    }
}
