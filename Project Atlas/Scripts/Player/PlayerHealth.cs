using System.Collections;
using System.Threading;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class PlayerHealth : MonoBehaviour
{
    public int healthMax = 100;                                 // The amount of health the player starts the game with.
    public int currentHealth;                                   // The current health the player has.
    public Slider healthSlider;                                 // Reference to the UI's health bar.
    public Text healthText;                                     // Reference to the UI's health text.
    public Image damageImage;                                   // Reference to an image to flash on the screen on being hurt.
    public AudioClip deathSound;                                // The audio clip to play when the player dies.
    public AudioClip hurtSound;                                 // The auido clip to play when the player gets hurts.
    public AudioClip heartBeatSound;
    public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.
    public bool isImmortal = false;                             // The bool to control is player can take damage or not. True = can't take damage. False = can't take damage.
    public int blockPercentage = 5;                             // The amount that incoming damage is reduced if blocking.
    public int respawnSeconds;                                  // The time it takes to respawn.
    public Transform respawnPoint;                              // The location that the player respawns.
    public Transform startPoint;                                // The location that the player starts at.
    Animator anim;                                              // Reference to the Animator component.
    public AudioSource playerAudio;                                    // Reference to the AudioSource component.
    PlayerMovement playerMovement;                              // Reference to the player's movement.
    public bool isDead;                                         // Whether the player is dead.
    bool damaged;                                               // True when the player gets damaged.
    float respawnTimer;                                         // The temporary float to keep track of time.
    public int id;                              // This identifies the mob in AutoSave
    public static int assigner;                      // this Assignes the Id of mobs for save
    public bool defenseCompanion = false;                       // If the defense companion is on

    void Awake()
    {
        // Setting up the references.
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        startPoint = transform;
        respawnPoint = startPoint;

        // Set the initial health of the player.
        currentHealth = healthMax;
    }

    void Update()
    {
        // Updates the health UI text.
        healthText.text = currentHealth.ToString() + "/" + healthMax.ToString();

        // Set the max value of the health slider to max health.
        healthSlider.maxValue = healthMax;

        // Set the health bar's value to the current health.
        healthSlider.value = currentHealth;

        currentHealth = Mathf.Clamp(currentHealth, 0, healthMax);

        if (currentHealth <= 25)
        {
            playerAudio.clip = heartBeatSound;
            if (!playerAudio.isPlaying)
            {
                playerAudio.Play();
            }
        }

        // If the player has just been damaged...
        if (damaged)
        {
            // ... set the colour of the damageImage to the flash colour.
            damageImage.color = flashColour;
        }
        // Otherwise...
        else
        {
            // ... transition the colour back to clear.
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        // Reset the damaged flag.
        damaged = false;

        // If player dead, then start timer for respawn.
        if (isDead)
        {
            // Add to the temporary timer.
            respawnTimer += Time.deltaTime;

            // If the temporary timer is greater than the set amount of time to respawn...
            if (respawnTimer >= respawnSeconds)
            {
                // ... respawn the player.
                //Respawn();
                StartCoroutine("IRespawn");

                // Reset timer.
                respawnTimer = 0;
            }
        }
    }

    // Function to damage the player.
    public void TakeDamage(int amount)
    {
        // If player is immortal...
        if (isImmortal)
        {
            // ... don't take damage.
            return;
        }
        
        else
        {
            // Set the damaged flag so the screen will flash.
            damaged = true;

            if(defenseCompanion == true)
            {
                amount = amount / 2;
            }

            else
            {
                // Reduce the current health by the damage amount.
                currentHealth -= amount;
            }

            if(currentHealth >= 25)
            {
                // Set audio to hurt sound.
                playerAudio.clip = hurtSound;

                // Play the hurt sound effect.
                playerAudio.Play();
            }

            // If the player has lost all it's health and the death flag hasn't been set yet...
            if (currentHealth <= 0 && !isDead)
            {
                // ... it should die.
                Death();
            }
        }
    }

    IEnumerator IRespawn()
    {
        isDead = false;
        anim.SetBool("IsDead", isDead);

        transform.position = respawnPoint.position;
        transform.rotation = respawnPoint.rotation;

        yield return new WaitForSeconds(2);

        playerMovement.enabled = true;
        currentHealth = healthMax;
    }

    // Function to respawn player.
    //public void Respawn()
    //{
    //    isDead = false;
    //    anim.SetBool("IsDead", isDead);

    //    transform.position = respawnPoint.position;
    //    transform.rotation = respawnPoint.rotation;
    //    playerMovement.enabled = true;
    //    //playerMovement.isBlocking = false;
    //    currentHealth = healthMax;
    //}

    // Function to kill the player.
    void Death()
    {
        // Set the death flag so this function won't be called again.
        isDead = true;

        // Tell the animator that the player is dead.
        anim.SetBool("IsDead", isDead);

        // Set the audiosource to play the death clip and play it (this will stop the hurt sound from playing).
        playerAudio.Stop();
        playerAudio.clip = deathSound;
        playerAudio.Play();

        // Turn off the movement scripts.
        playerMovement.enabled = false;
    }
}
