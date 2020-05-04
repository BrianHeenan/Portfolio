using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSkills : MonoBehaviour
{
    [Tooltip("Place Sword from player prefab, here.")]
    public Animator sword;
    int TempDamage;
    public GameObject SwordParticle;
    public Gradient CleaveGradient, RendGradient, DisarmGradient, SpinGradient;
    private void Start()
    {
        PlayerAttack PA = FindObjectOfType<PlayerAttack>();
        TempDamage = PA.attackDamage;
    }

    public void Cleave()
    {
        //Hits up to 3 targets in front of the player. Deals an additional 30 damage to each target.
        PlayerAttack PA =  FindObjectOfType<PlayerAttack>();
        PA.attackDamage += 30;
        sword.SetBool("isCleave", true);
        SwordParticle.SetActive(true);
        SwordParticle.GetComponent<TrailRenderer>().colorGradient = CleaveGradient;
    }
    public void Rend()
    {
        //Slashes the target doing 10 bleed damage every 1 second for 6 seconds.
        PlayerAttack PA = FindObjectOfType<PlayerAttack>();
        PA.isAttacking = true;
        PA.meleeWeapon.GetComponent<Collider>().enabled = true;
        HitBox hit = FindObjectOfType<HitBox>();
        sword.SetBool("isSword1", true);
        hit.ChanageStatus(1);
        SwordParticle.SetActive(true);
        SwordParticle.GetComponent<TrailRenderer>().colorGradient = RendGradient;
    }
    public void Disarm()
    {
        //Disarms the target preventing it from attacking for 3 seconds.
        PlayerAttack PA = FindObjectOfType<PlayerAttack>();
        PA.isAttacking = true;
        PA.meleeWeapon.GetComponent<Collider>().enabled = true;
        HitBox hit = FindObjectOfType<HitBox>();
        sword.SetBool("isSword1", true);
        hit.ChanageStatus(2);
        SwordParticle.SetActive(true);
        SwordParticle.GetComponent<TrailRenderer>().colorGradient = DisarmGradient;
    }
    public void SwordSpin()
    {
        //Damages targets around player within weapon range. Deals 10 Additional damage.
        PlayerAttack PA = FindObjectOfType<PlayerAttack>();
        PA.attackDamage += 60;
        sword.SetBool("isSwordSpin", true);
        SwordParticle.SetActive(true);
        SwordParticle.GetComponent<TrailRenderer>().colorGradient = SpinGradient;
    }

    public void ActivateHitBox()
    {
        HitBox hitBox = FindObjectOfType<HitBox>();
        hitBox.Activate();
    }

    public void DeactivateHitBox()
    {
        HitBox hitBox = FindObjectOfType<HitBox>();
        hitBox.Deactive();
    }

    public void TurnOff()
    {
        PlayerAttack PA = FindObjectOfType<PlayerAttack>();
        PA.attackDamage = TempDamage;
        sword.SetBool("isCleave", false);
        sword.SetBool("isSwordSpin", false);
        SwordParticle.SetActive(false);
    }
}
