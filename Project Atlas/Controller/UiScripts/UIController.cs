////////////////
//Created 1/9/19 By Brian Heenan
//Edited 2/11/19
//Edited By Lloyd Jarrell on 1/10/2019
//Content edited: added function: 
//
////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class UIController : MonoBehaviour
{
    public static bool isPaused = false;
    public AudioSource GameUISound;
    public GameObject pauseMenuUI;              //this gameobject is the pause menu gameobject in the Hierarchy.
    public GameObject companionPanel;           //this gameobject is the companion panel gameobject in the Hierarchy.
   
   
    //public GameObject cont;
    //public GameObject greyOutCont;
    static UIController inst;
    public bool stealControl = false;
    public AudioMixer mixer;
    public static AudioMixer audioMixer;

    public Dropdown resolutionDropdown;
    Resolution[] resolutions;

    //public Text timerText;
    private float startTime;
    public float tempFXSound;
    private void Awake()
    {
        Continue();
        audioMixer = GameUISound.outputAudioMixerGroup.audioMixer;
        //LoadAudio();
    }

    private void Start()
    {
        Continue();

        startTime = Time.time;
        resolutions =  Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        

    }

    void Update()
    {
        float t = Time.time - startTime;
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f0");

        

       // timerText.text = minutes + ":"  + seconds;

       if (Input.GetKeyDown(KeyCode.Escape))
       {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
       }

        if (Input.GetKeyDown(KeyCode.C))
        {
            CompanionPanel();
           
        }
    }

    

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        //audioMixer.SetFloat("SoundFX", tempFXSound);
        isPaused = false;
        stealControl = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        //audioMixer.SetFloat("SoundFX", tempFXSound);
        Time.timeScale = 0f;
        
        isPaused = true;
        stealControl = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        Debug.Log("Loading Menu...");
    }

    public void WinLoad()
    {
        string path = Application.persistentDataPath + "/player.sav";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        else
        {
            return;
        }
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
        Debug.Log("Loading Menu...");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    public void Tutorial()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 9);
    }

    public void QuitGame()
    {
        Debug.Log("Quiting");

        //add editor Quit
        Application.Quit();
        //EditorApplication.isPlaying = false;
        // this is a trap.... closed unity all the way EditorApplication.Exit(0);
    }

    public void SetVolume (float volume)
    {
        
        audioMixer.SetFloat("MasterVolume", volume);
    }

    public void SetSoundFX(float fxVolume)
    {
        audioMixer.SetFloat("SoundFX", fxVolume);
    }

    public void SetMusicVolume(float musicVolume)
    {
        audioMixer.SetFloat("Music", musicVolume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void CompanionPanel()
    {
        if (companionPanel != null)
        {
            bool companionIsActive = companionPanel.activeSelf;
            companionPanel.SetActive(!companionIsActive);
            stealControl = !companionIsActive;
        }
    }
    
    public void NewGame()
    {
        string path = Application.persistentDataPath + "/player.sav";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        else
        {
            return;
        }
    }
    public void Continue()
    {
        string path = Application.persistentDataPath + "/player.sav";
        if (File.Exists(path))
        {
            //cont.SetActive(true);
            //greyOutCont.SetActive(false);
        }
        else
        {
            return;
        }
    }

    public void SetResolution(int x,int y)
    {
        Screen.SetResolution(x, y, Screen.fullScreen);
    }

    //public void LoadAudio()
    //{
    //    string path = Application.persistentDataPath + "/audio.sav";
    //    if (File.Exists(path))
    //    {
            
    //        SetVolume(data.m_Volume);
    //        SetSoundFX(data.m_FXVolume);
    //        SetMusicVolume(data.m_MusicVolume);
    //        SetFullscreen(data.m_Fullscreen);
    //        SetQuality(data.m_QualIndex);
    //        SetResolution(data.m_ResolutionX, data.m_ResolutionY);
    //    }
    //    else
    //    {
    //        Debug.LogWarning("No save object exists");
    //    }
    //}

    public void TutorialPanel()
    {
        TutorialInteraction tutorialScript = FindObjectOfType<TutorialInteraction>();

        tutorialScript.tutorialPanel.SetActive(false);
        //stealControl = false;
        //Time.timeScale = 1;
        //tutorialScript.timeFreeze = false;
        //audioMixer.SetFloat("SoundFX", tempFXSound);
    }
    
}
