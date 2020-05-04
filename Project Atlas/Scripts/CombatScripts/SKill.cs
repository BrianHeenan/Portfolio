using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SKill : MonoBehaviour
{
    public float maxCooldown;
    public float currentCooldown;
    public bool onCooldown = false;
    
    SkillBarInteraction sBar;
    
    void Update()
    {
        if (onCooldown)
        {
            currentCooldown += Time.deltaTime;
            GetComponent<Image>().fillAmount = currentCooldown / maxCooldown;
            if (currentCooldown > maxCooldown)
            {
                onCooldown = false;
                currentCooldown = 0;
            }
        }
    }

    public void ActivateSkill()
    {
        PlayerAttack PA = FindObjectOfType<PlayerAttack>();

        if(!onCooldown && !PA.isGlobalCoolDown && !PA.isReticleActive)
        {
            Button _button = GetComponent<Button>();
            _button.onClick.Invoke();
            onCooldown = true;
            PA.isGlobalCoolDown = true;
        }
        
    }

    public void ReticleCall()
    {
        Button _button = GetComponent<Button>();
        _button.onClick.Invoke();
    }

    public void VolleyActivate()
    {
        PlayerAttack PA = FindObjectOfType<PlayerAttack>();

        if(!onCooldown && !PA.isGlobalCoolDown && PA.isReticleActive)
        {
            onCooldown = true;
            PA.isGlobalCoolDown = true;
        }
    }
}
