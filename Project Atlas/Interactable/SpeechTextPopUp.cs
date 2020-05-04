using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechTextPopUp : MonoBehaviour
{
    Canvas GameUI;
    public GameObject textPanel;
    public GameObject NPC;
    public Transform player;

    LevelProgression LP;

    // Start is called before the first frame update
    void Start()
    {
        GameUI = FindObjectOfType<Canvas>();
        LP = FindObjectOfType<LevelProgression>();
    }

    // Update is called once per frame
    void Update()
    {
        textPanel.transform.position = Camera.main.WorldToScreenPoint((Vector3.forward * 5) + NPC.transform.position);

        if(LP.LevelUnlocked[1] == true)
        {
            Destroy(NPC);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        NPC.transform.LookAt(player);
        textPanel.SetActive(true);

        
    }
    private void OnTriggerExit(Collider other)
    {
        textPanel.SetActive(false);
    }
}
