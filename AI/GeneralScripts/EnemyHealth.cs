/*
 * Name: Hunter Duncan
 * Name: Brian Heenan
 * Edited: 02/11/19
 * Purpose:Enemy Health Controller
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;                 // The amount of health the enemy starts the game with.
    public int currentHealth;                   // The current health the enemy has.
    public float sinkSpeed = 2.5f;              // The speed at which the enemy sinks through the floor when dead.
    public AudioClip deathSoundClip;            // The sound to play when the enemy dies.
    public AudioClip hurtSoundClip;             // The sound to play when the enemy gets hurt.
    public GameObject enemyHealthUI;
    public GameObject healthPickup;
    Transform enemy;
    Canvas HUDUI;
    public ParticleSystem particleSystem;
    GameObject myUI;
    Slider healthSlider;
    
    RendCall rendCall;
    DisarmCall disarmCall;
    PoisonCall poisonCall;
    StopMovementCall stopCall;
    PlayerHealth playerHealth;
    PlayerAttack playerAttack;
    NavAgentStateMachine_Best myAgent;
    Rigidbody rb;
    EnemyAttack enemyAttack;
    Animator anim;                              // Reference to the animator.
    AudioSource enemyAudio;                     // Reference to the audio source.
    bool isDead;                                // Whether the enemy is dead.
    bool isSinking;                             // Whether the enemy has started sinking through the floor.
    public int id;                              // This identifies the mob in AutoSave
    public static int  assigner;                // this Assignes the Id of mobs for save
    int rendCount;
    int disarmCount;
    int poisonCount;
    int stopCount;
    
    float tempSpeed;
    void Awake()
    {
        // Setting up the references.
        anim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        myAgent = GetComponent<NavAgentStateMachine_Best>();
        enemyAttack = GetComponent<EnemyAttack>();
        rb = GetComponent<Rigidbody>();
        playerAttack = FindObjectOfType<PlayerAttack>();

        // Setting the current health when the enemy first spawns.
        currentHealth = maxHealth;

        myUI = Instantiate(enemyHealthUI);
    }

    void Start()
    {
        healthSlider = myUI.GetComponentInChildren<Slider>();
        healthSlider.maxValue = maxHealth;
        healthSlider.value = maxHealth;
        
        HUDUI = FindObjectOfType<Canvas>();
        myUI.transform.SetParent(HUDUI.transform, false);
        rendCall = myUI.GetComponentInChildren<RendCall>();
        disarmCall = myUI.GetComponentInChildren<DisarmCall>();
        poisonCall = myUI.GetComponentInChildren<PoisonCall>();
        stopCall = myUI.GetComponentInChildren<StopMovementCall>();
        enemy = this.transform;
        playerHealth = FindObjectOfType<PlayerHealth>();
        poisonCall.gameObject.SetActive(false);
        stopCall.gameObject.SetActive(false);
        disarmCall.gameObject.SetActive(false);
        rendCall.gameObject.SetActive(false);
        
        assignID();
    }
    void assignID()
    {
        this.id = assigner;
        assigner++;
    }

    void Update()
    {
        // If the enemy should be sinking...
        if (isSinking)
        {
            // ... move the enemy down by the sinkSpeed per second.
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime, Space.World);
        }

        if(myUI != null)
        {
            myUI.transform.position = Camera.main.WorldToScreenPoint((Vector3.forward * 1) + transform.position);
        }

        anim.SetFloat("Speed", GetComponent<NavMeshAgent>().speed);
    }

    public void TakeDamage(int amount)
    {
        // If the enemy is dead...
        if (isDead)
            // ... no need to take damage so exit the function.
            return;
        
        particleSystem.Play();
        
        // Reduce the current health by the amount of damage sustained.
        currentHealth -= amount;
        
        // Set health bar slider to current health.
        healthSlider.value = currentHealth;

        // If the current health is less than or equal to zero...
        if (currentHealth <= 0)
        {
            // ... the enemy is dead.
            Death();
        }
    }
    public void HurtSound()
    {
        enemyAudio.clip = hurtSoundClip;
        enemyAudio.Play();
    }

    void Death()
    {
        // The enemy is dead.
        isDead = true;

        // Turn off all colliders on gameobject.
        Collider[] colliders = GetComponentsInChildren<Collider>();
        foreach (Collider collider in colliders)
        {
            collider.enabled = false;
        }
        
        // Find and disable the Nav Mesh Agent.
        GetComponent<NavMeshAgent>().enabled = false;

        // Find the rigidbody component and make it kinematic (since we use Translate to sink the enemy).
        GetComponent<Rigidbody>().isKinematic = true;

        // Find and disable AI state machine
        myAgent.enabled = false;

        

        // Tell the animator that the enemy is dead.
        anim.SetTrigger("Dead");

        DropItem();

        // Change the audio clip of the audio source to the death clip and play it (this will stop the hurt clip playing).
        enemyAudio.clip = deathSoundClip;
        enemyAudio.Play();
    }


    public void StartSinking()
    {
        // The enemy should now sink.
        isSinking = true;

        // Destroy health UI
        Destroy(myUI);

        // After 2 seconds destroy the enemy.
        Destroy(gameObject, 2f);
    }

    public void StatusHandler(int status)
    {
        switch (status)
        {
            case 0:
                break;
            case 1:
                //Rend
                InvokeRepeating("RendDamage", 1, 1);
                rendCall.gameObject.SetActive(true);
                break;
            case 2:
                //Disarm
                
                myAgent.runAway = true;
                InvokeRepeating("DisarmEnemy", 1, 1);
                disarmCall.gameObject.SetActive(true);
                break;
            case 3:
                //Poison
                InvokeRepeating("PoisonDamage", 1, 1);
                poisonCall.gameObject.SetActive(true);
                break;
            case 4:
                //Stop Movement
                tempSpeed = gameObject.GetComponent<NavMeshAgent>().speed;
                InvokeRepeating("StopMovement", 1, 1);
                stopCall.gameObject.SetActive(true);
                break;

            default:
                break;
        }
    }
    public void RendDamage()
    {
        rendCount++;
        TakeDamage(10);
        playerHealth.currentHealth += 5;
        playerAttack.healthParticle.Play();
        if(rendCount >= 6)
        {
            CancelInvoke("RendDamage");
            rendCall.gameObject.SetActive(false);
            rendCount = 0;
        }
    }
    public void DisarmEnemy()
    {
        
        disarmCount++;
        if(enemyAttack.weapon != null)
        {
            enemyAttack.weapon.SetActive(false);
        }
        
        

        if(disarmCount >= 6)
        {
            CancelInvoke("DisarmEnemy");
            myAgent.runAway = false;
            disarmCall.gameObject.SetActive(false);
            if(enemyAttack.weapon != null)
            {
                enemyAttack.weapon.SetActive(true);
            }
            
            disarmCount = 0;
        }
    }
    public void PoisonDamage()
    {
        poisonCount++;
        TakeDamage(10);
        if (poisonCount >= 6)
        {
            CancelInvoke("PoisonDamage");
            poisonCall.gameObject.SetActive(false);
            poisonCount = 0;
        }
    }
    public void StopMovement()
    {
        stopCount++;
        NavMeshAgent enemy = gameObject.GetComponent<NavMeshAgent>();
        enemy.speed = 0;
        if (stopCount >= 6)
        {
            CancelInvoke("StopMovement");
            stopCall.gameObject.SetActive(false);
            
            enemy.speed = tempSpeed;
            stopCount = 0;
        }
    }

    public void DropItem()
    {
        enemy.position = new Vector3(enemy.position.x, enemy.position.y, enemy.position.z);
        const float dropChance = 1f / 5f;  //1 in 5 chances to drop.
        if(Random.Range(0f,1f) <= dropChance)
        {
            Instantiate(healthPickup, enemy.position, enemy.rotation);
        }
    }
}
