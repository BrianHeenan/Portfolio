using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class KeyBindDialoge : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        inputManager = GameObject.FindObjectOfType<InputManager>();
        string[] buttonNames = inputManager.GetButtonNames();

        
            for(int i = 0; i < buttonNames.Length; i++)
        {
            string bn;
            bn = buttonNames[i];

            GameObject go =  (GameObject)Instantiate(keyItemPrefab);
            go.transform.SetParent(keyList.transform);
            go.transform.localScale = Vector3.one; //cool!!!

            Text buttonNameText = go.transform.Find("Button Name").GetComponent<Text>();
            buttonNameText.text = bn;
            

            Text keyNameText = go.transform.Find("Button/Key Name").GetComponent<Text>();
            keyNameText.text = inputManager.GetKeyNameForButton(bn);
            buttonToLabel[bn] = keyNameText;

            Button keyBindButton = go.transform.Find("Button").GetComponent<Button>();
            keyBindButton.onClick.AddListener(() => { StartRebindFor(bn); });
        }
    }
    InputManager inputManager;
    public GameObject keyItemPrefab;
    public GameObject keyList;
    string buttonToRebind = null;
    Dictionary<string, Text> buttonToLabel;


    // Update is called once per frame
    void Update()
    {
        if(buttonToRebind != null)
        {
            if(Input.anyKeyDown)
            {

                foreach (KeyCode kc in Enum.GetValues(typeof(KeyCode)))
                {
                    if(Input.GetKeyDown(kc))
                    {
                        inputManager.SetButtonForKey(buttonToRebind, kc);
                        buttonToLabel[buttonToRebind].text = kc.ToString();
                        buttonToRebind = null;
                        break;
                    }
                }
            }
        }
    }
    void StartRebindFor(string buttonName)
    {
        Debug.Log(buttonName);
        buttonToRebind = buttonName;
    }


}
