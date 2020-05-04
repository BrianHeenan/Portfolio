using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;    //allows change in the editor
    public Rigidbody playerRB;  //variable to hold reference for players Rigidbody
    public bool walking = false;
    //---For Audio
    public AudioSource audioSource;
    public AudioClip audioClip;
    //---For Dodging
    public int dodgeSpeed;
    public bool isDodging = false;
    public float dodgeTime;
    private float timer;
    public float dodgeCD = 1f;
    public GameObject dashTrail;
    [HideInInspector]
    public float tempSpeed;
    //---Health script to allow immortal during dodge.
    PlayerHealth health;
    //---Attack script to check if attacking.
    PlayerAttack playerAttack;
    Animator anim;

    float _moveHor;
    float _moveVert;

    private void Awake()
    {
        //---Setup references
        anim = GetComponent<Animator>();
        health = GetComponent<PlayerHealth>();
        playerAttack = GetComponent<PlayerAttack>();
        tempSpeed = speed;
        playerRB = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _moveHor = Input.GetAxisRaw("Horizontal");  //used to record the Horizontal input to move the player.
        _moveVert = Input.GetAxisRaw("Vertical");   //used to record the Vertical input to move the player.

        if (playerAttack.isAttacking)
        {
            walking = false;
        }
        else
        {
            walking = _moveHor != 0f || _moveVert != 0f;
        }

        if (Input.GetMouseButtonDown(1) && timer > dodgeCD)
        {
            timer = 0;
            isDodging = true;
            dashTrail.SetActive(true);
        }

        timer += Time.deltaTime;

        if (timer >= dodgeTime)
        {
            isDodging = false;
            dashTrail.SetActive(false);
        }
    }

    private void FixedUpdate()  //because of addforce
    {
        //if (playerAttack.isAttacking)
        //{
        //    playerRB.isKinematic = true;
        //}
        //else if(timer >= playerAttack.timeBetweenAttacks)
        //{
        //    playerRB.isKinematic = false;
        //    Move(_moveHor, _moveVert);
        //}
        if (walking)
        {
            Move(_moveHor, _moveVert);
        }

        Turning(_moveHor, _moveVert);

        Animating();

        WalkSound();
    }

    void Move(float h, float v)
    {
        //not sure if this needs to be referenced again.
        Vector3 movement = new Vector3(h, 0.0f, v).normalized;

        //---is Dodging
        if (isDodging)
        {
            speed = dodgeSpeed;
            health.isImmortal = true;
            anim.SetBool("isDashing", true);
        }
        else
        {
            speed = tempSpeed;
            health.isImmortal = false;
            anim.SetBool("isDashing", false);
        }

        playerRB.AddForce(movement * speed, ForceMode.Acceleration);
    }

    void Turning(float h, float v)
    {
        //Look at the mouse for attacking.
        if (playerAttack.isAttacking)
        {
            var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
            var angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
        }
        //Look at direction moving.
        else
        {
            Vector3 movement = new Vector3(h, 0, v).normalized;

            transform.LookAt(movement + transform.position);
        }
    }

    void WalkSound()
    {
        if (walking)
        {
            audioSource.clip = audioClip;
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
    }

    void Animating()
    {
        // Tell the animator whether or not the player is walking.
        anim.SetBool("IsWalking", walking);
    }
}
