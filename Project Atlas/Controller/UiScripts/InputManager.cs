using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InputManager : MonoBehaviour
{
    private void OnEnable()
    {
        buttonKeys = new Dictionary<string, KeyCode>();
        buttonKeys["Dash"] = KeyCode.Space;
        buttonKeys["Base Attack"] = KeyCode.Mouse0;
        buttonKeys["Attack1"] = KeyCode.Alpha1;
        buttonKeys["Attack2"] = KeyCode.Alpha2;
        buttonKeys["Attack3"] = KeyCode.Alpha3;
        buttonKeys["Attack4"] = KeyCode.Alpha4;
        buttonKeys["Health"] = KeyCode.Tab;
      // buttonKeys["Horizontal"] = KeyCode.W;
      // buttonKeys["Vertical"] = KeyCode.S;
       // buttonKeys["Left"] = KeyCode.A;
       // buttonKeys["Right"] = KeyCode.D;
        buttonKeys["WeaponSwap"] = KeyCode.LeftShift;
    }
    // Start is called before the first frame update
    void Start()
    {
    }
    Dictionary<string, KeyCode> buttonKeys;

    // Update is called once per frame
    void Update()
    {

    }
    public bool GetButtonDown(string buttonName)
    {
        if (buttonKeys.ContainsKey(buttonName) == false)
        {
            Debug.LogError("InputManager::GetButtonDown -- No button names:" + buttonName);
            return false;
        }
        return Input.GetKeyDown(buttonKeys[buttonName]);
    }

    public string[] GetButtonNames()
    {
        return buttonKeys.Keys.ToArray();
    }

    public string GetKeyNameForButton(string buttonName)
    {
        if (buttonKeys.ContainsKey(buttonName) == false)
        {
            Debug.LogError("InputManager::GetNameForButton -- No button named" + buttonName);
            return "N/A";
        }
        return buttonKeys[buttonName].ToString();
    }

    public void SetButtonForKey(string buttonName, KeyCode keycode)
    {
        buttonKeys[buttonName] = keycode;
    }
}
