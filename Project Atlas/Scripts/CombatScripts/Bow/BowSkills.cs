using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowSkills : MonoBehaviour
{
    [Tooltip("Place Bow from player prefab, here.")]
    public Animator playerAnimator;
    public GameObject arrow;     //normal arrow prefab
    public GameObject p_arrow;   //poison arrow prefab
    public GameObject f_arrow;   //frost arrow prefab
    public GameObject volleyShot;
    public Transform spawnPoint;
    public Transform split1;
    public Transform split2;
    public Transform split3;
    public Transform volleySpawn;
    public float arrowForce;
    public GameObject target;
    PlayerAttack PA;
    public int TempDamage;

    private void Start()
    {
        PA = FindObjectOfType<PlayerAttack>();
        TempDamage = PA.attackDamage;

    }
    public void Volley()
    {
        //Rain Of arrows that land at targeted location for 5 seconds. Damaging all targets in the area.
        if (target.activeInHierarchy != true)
        {
            target.SetActive(true);
            PA.isReticleActive = true;
            PA.attackDamage += 60;
        }
        //else if (target.activeInHierarchy == true)
        //{           
        //    bow.SetBool("isRainingDown", true);            
        //    target.SetActive(false);
        //}       
        
    }

    public void PlaySound()
    {
        GetComponent<AudioSource>().Play();
    }

    public void TurningOff()
    {
        PA.attackDamage = TempDamage;
        playerAnimator.SetBool("isBowSkill", false);
        playerAnimator.SetBool("isRainingDown", false);
    }

    public void PoisonArrow()
    {
        playerAnimator.SetBool("isBowSkill", true);

        GameObject go = Instantiate(p_arrow, spawnPoint.position, spawnPoint.rotation);

        if (go == null)
        {
            return;
        }
        go.GetComponent<Rigidbody>().AddForce(spawnPoint.transform.forward * arrowForce, ForceMode.VelocityChange);
        HitBox hit = FindObjectOfType<HitBox>();
        hit.ChanageStatus(3);
    }

    public void StopArrow()
    {
        playerAnimator.SetBool("isBowSkill", true);

        GameObject go = Instantiate(f_arrow, spawnPoint.position, spawnPoint.rotation);

        if (go == null)
        {
            return;
        }
        go.GetComponent<Rigidbody>().AddForce(spawnPoint.transform.forward * arrowForce, ForceMode.VelocityChange);
        HitBox hit = FindObjectOfType<HitBox>();
        hit.ChanageStatus(4);
    }

    public void SplitArrow()
    {
        playerAnimator.SetBool("isBowSkill", true);

        GameObject splitGo1 = Instantiate(arrow, split1.position, split1.rotation);
        GameObject splitGo2 = Instantiate(arrow, split2.position, split2.rotation);
        GameObject splitGo3 = Instantiate(arrow, split3.position, split3.rotation);

        if (splitGo1 == null && splitGo2 == null && splitGo3 == null)
        {
            return;
        }
        splitGo1.GetComponent<Rigidbody>().AddForce(split1.transform.forward * arrowForce, ForceMode.VelocityChange);
        splitGo2.GetComponent<Rigidbody>().AddForce(split2.transform.forward * arrowForce, ForceMode.VelocityChange);
        splitGo3.GetComponent<Rigidbody>().AddForce(split3.transform.forward * arrowForce, ForceMode.VelocityChange);
    }

    public void VolleysArrow()
    {
        GameObject volley = Instantiate(volleyShot, volleySpawn.position, volleySpawn.rotation);

        if (volley == null)
        {
            return;
        }
        volley.GetComponent<Rigidbody>().AddForce(-spawnPoint.transform.up * arrowForce, ForceMode.VelocityChange);
    }
}
