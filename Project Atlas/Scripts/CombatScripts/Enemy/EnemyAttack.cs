using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks = 2f;     // The time in seconds between each attack.
    public int damage = 10;
    public GameObject weapon;
    public GameObject hitbox;
    public GameObject weaponTrail;
    ShootProjectile shootProjectile;
    NavAgentStateMachine_Best myAgent;
    Animator anim;                              // Reference to the animator component.
    EnemyHealth enemyHealth;                    // Reference to this enemy's health.
    public bool isAttacking = false;            // Whether enemy is attacking.
    float timer;                                // Timer for counting up to the next attack.

    private void Awake()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
        myAgent = GetComponent<NavAgentStateMachine_Best>();
        //hitbox = GetComponentInChildren<EnemyHitBox>().gameObject;
        //weaponTrail = GetComponentInChildren<TrailRenderer>().gameObject;
        if(hitbox != null)
        {
            hitbox.SetActive(false);
        }
    }

    void Start()
    {
        // Setting up the references.
        shootProjectile = GetComponentInChildren<ShootProjectile>();
    }

    void Update()
    {
        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;

        if (myAgent.inRange && enemyHealth.currentHealth > 0 && !isAttacking)
        {
            Attack();
        }

        if (timer >= timeBetweenAttacks)
        {
            isAttacking = false;
            timer = 0;
        }
    }

    void Attack()
    {
        isAttacking = true;
        anim.GetComponent<Animator>().SetTrigger("isBasicAttack");
    }

    void Fire()
    {
        shootProjectile.Shoot();
    }

    void Activate()
    {
        hitbox.SetActive(true);
        if (weaponTrail != null)
        {
            weaponTrail.SetActive(true);

        }
    }

    void Deactivate()
    {
        hitbox.SetActive(false);
        if (weaponTrail != null)
        {
            weaponTrail.SetActive(false);
        }
    }
}
