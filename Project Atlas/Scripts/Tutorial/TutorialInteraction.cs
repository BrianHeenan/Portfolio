using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.Audio;

public class TutorialInteraction : MonoBehaviour
{
    
    GameObject player;
    public int id;
    [Tooltip("Place tutorialText under GameUI/Tutorial/TutorialPanel into this slot")]
    public Text tutorialText;
    [Tooltip("Place VideoPlayer into this slot")]
    public VideoPlayer VP;
    [Tooltip("Place tutorialPanel under GameUI/Tutorial into this slot")]
    public GameObject tutorialPanel;
    [Tooltip("Place VideoMovement from Materials/VideoMaterials folder into this slot")]
    public VideoClip movement;
    [Tooltip("Place VideoRealmSwap from Materials/VideoMaterials folder into this slot")]
    public VideoClip realmswap;
    [Tooltip("Place VideoBasicBowAttack from Materials/VideoMaterials folder into this slot")]
    public VideoClip basicBowAttack;
    [Tooltip("Place VideoBasicMeleeAttack from Materials/VideoMaterials folder into this slot")]
    public VideoClip basicMeleeAttack;
    [Tooltip("Place VideoCleave from Materials/VideoMaterials folder into this slot")]
    public VideoClip cleave;
    [Tooltip("Place VideoDisarm from Materials/VideoMaterials folder into this slot")]
    public VideoClip disarm;
    [Tooltip("Place VideoSpin from Materials/VideoMaterials folder into this slot")]
    public VideoClip spin;
    [Tooltip("Place VideoRend from Materials/VideoMaterials folder into this slot")]
    public VideoClip rend;
    [Tooltip("Place VideoSplitShot from Materials/VideoMaterials folder into this slot")]
    public VideoClip splitShot;
    [Tooltip("Place VideoPoisonShot from Materials/VideoMaterials folder into this slot")]
    public VideoClip poisonShot;
    [Tooltip("Place VideoFrozenArrow from Materials/VideoMaterials folder into this slot")]
    public VideoClip frozenArrow;
    [Tooltip("Place VideoVolley from Materials/VideoMaterials folder into this slot")]
    public VideoClip volley;
    [Tooltip("Place VideoDodge from Materials/VideoMaterials folder into this slot")]
    public VideoClip dodge;
    [Tooltip("Place VideoPet from Materials/VideoMaterials folder into this slot")]
    public VideoClip petvideo;
    [Tooltip("Place GameUI into this slot")]
    public AudioSource gameUISound;
    [Tooltip("Place  into this slot")]
    public AudioClip activateSound;

    public bool timeFreeze = false;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerHealth>().gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        //TextTrigger(id);
       // VP.Play();
    }

    public void TextTrigger(int trigger)
    {
        switch (trigger)
        {
            case 0:
                tutorialText.text = "Move by using W/A/S/D. You can hit Tab to heal.";
                VP.clip = movement;
                gameUISound.clip = activateSound;
                gameUISound.Play();
                break;

            case 1:
                tutorialText.text = "Press SPACE to Realm Swap to change specific areas in the game.";
                VP.clip = realmswap;
                gameUISound.clip = activateSound;
                gameUISound.Play();
                break;

            case 2:
                tutorialText.text = "To change weapons press the Left Shift key. Then click the left mouse button to attack.";
                VP.clip = basicMeleeAttack;
                gameUISound.clip = activateSound;
                gameUISound.Play();
                break;

            case 3:
                tutorialText.text = "Press the 1 key, while sword is active, to attack with Cleave. Cleave is used to hit multiple targets in front of the player";
                VP.clip = cleave;
                gameUISound.clip = activateSound;
                gameUISound.Play();
                break;

            case 4:
                tutorialText.text = "Press the 2 key, while sword is active, to attack with Rend. Rend is used to apply damage over time.";
                VP.clip = rend;
                gameUISound.clip = activateSound;
                gameUISound.Play();
                break;

            case 5:
                tutorialText.text = "Press the 3 key, while sword is active, to attack with Disarm.";
                VP.clip = disarm;
                gameUISound.clip = activateSound;
                gameUISound.Play();
                break;

            case 6:
                tutorialText.text = "Press the 4 key, while sword is active, to attack with Spin. Spin is used to hit multiple target around the player.";
                VP.clip = spin;
                gameUISound.clip = activateSound;
                gameUISound.Play();
                break;

            case 7:
                tutorialText.text = "Press Left Shift key to switch to Bow. Then click the left mouse button to attack. The player can hold down the left mouse button for a more accurate shot.";
                VP.clip = basicBowAttack;
                gameUISound.clip = activateSound;
                gameUISound.Play();
                break;

            case 8:
                tutorialText.text = "Press the 1 key, while bow is active, to attack with Split shot. Split Shot hits up to three targets in front of the player.";
                VP.clip = splitShot;
                gameUISound.clip = activateSound;
                gameUISound.Play();
                break;

            case 9:
                tutorialText.text = "Press the 2 key, while bow is active to attack with Poison Shot. Poison Shot applies damage over time.";
                VP.clip = poisonShot;
                gameUISound.clip = activateSound;
                gameUISound.Play();
                break;

            case 10:
                tutorialText.text = "Press the 3 key, while bow is active, to attack with Frozen arrow. Forzen arrow is used to stop the target for a period of time.";
                VP.clip = frozenArrow;
                gameUISound.clip = activateSound;
                gameUISound.Play();
                break;

            case 11:
                tutorialText.text = "Press the 4 key, while bow is active. Place the recticle over your target and press the left mouse button to activate Volley.";
                VP.clip = volley;
                gameUISound.clip = activateSound;
                gameUISound.Play();
                break;

            case 12:
                tutorialText.text = "Press right mouse button to dodge.";
                VP.clip = dodge;
                gameUISound.clip = activateSound;
                gameUISound.Play();
                break;

            case 13:
                tutorialText.text = "After finding a pet in a level, you can activate it by going to Hub City and selecting it.";
                VP.clip = petvideo;
                gameUISound.clip = activateSound;
                gameUISound.Play();
                break;

            default:
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        UIController UI = FindObjectOfType<UIController>();
        UI.GameUISound.outputAudioMixerGroup.audioMixer.GetFloat("SoundFX", out UI.tempFXSound);
        
        if (other.gameObject == player)
        {
            TextTrigger(id);
            tutorialPanel.SetActive(true);
            VP.Play();
            

        }
    }

}
