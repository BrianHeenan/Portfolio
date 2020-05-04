using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealmIndication : MonoBehaviour
{
    [Tooltip("Place RealmParticleSwirl from under TempPlayer here.")]
    public GameObject realmParticle;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        realmParticle.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        realmParticle.SetActive(false);
    }
}
