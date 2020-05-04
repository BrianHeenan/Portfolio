using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    PlayerAttack playerAttack;
    Collider hitboxCollider;
    public int currStatus;

    private void Start()
    {
        playerAttack = FindObjectOfType<PlayerAttack>();
        hitboxCollider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EnemyHealth>()) // if hitting enemy
        {
            other.GetComponent<EnemyHealth>().TakeDamage(playerAttack.attackDamage);

            other.GetComponent<EnemyHealth>().StatusHandler(currStatus);

            other.GetComponentInChildren<EnemyHealth>().HurtSound();

            if (playerAttack.meleeWeapon.activeSelf)
            {
                return;
            }
            else if (playerAttack.rangeWeapon.activeSelf)
            {
                Destroy(this.gameObject);
                currStatus = 0;
            }         
        }
        else
        {
            return;
        }
    }

    public void ChanageStatus(int status)
    {
        currStatus = status; 
    }
    
    public void Activate()
    {
        hitboxCollider.enabled = true;
    }

    public void Deactive()
    {
        hitboxCollider.enabled = false;

        currStatus = 0;
    }

    public void PlaySound()
    {
        GetComponent<AudioSource>().Play();
    }
}
