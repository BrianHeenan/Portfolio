/*
 * Created by: Hunter Duncan
 * Start date: 1/10/2019
 * Edits: Hunter Duncan-1/11/2019, Hunter Duncan-1/12/2019, Hunter Duncan-1/14/2019
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class RealmManager : MonoBehaviour
{
    PostProcessVolume m_Volume;
    ColorGrading m_ColorGrading;
    Vignette m_Vignette;
    float saturationStart;
    float intensityStart;
    float smoothnessStart;
    float roundnessStart;
    float t;
    bool realmSwap;
    AudioSource audioSource;
    public float swapSeconds = 3; // Realm Swap cooldown.
    public RealmObject[] realmObjects;
    public RealmPlayer realmPlayer;
    float timer;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        realmObjects = FindObjectsOfType<RealmObject>();
        realmPlayer = FindObjectOfType<RealmPlayer>();

        m_ColorGrading = ScriptableObject.CreateInstance<ColorGrading>();
        m_ColorGrading.enabled.Override(true);
        m_ColorGrading.saturation.Override(0);
        saturationStart = m_ColorGrading.saturation.value;

        m_Vignette = ScriptableObject.CreateInstance<Vignette>();
        m_Vignette.enabled.Override(true);
        m_Vignette.intensity.Override(0);
        m_Vignette.smoothness.Override(0);
        m_Vignette.roundness.Override(0);
        intensityStart = m_Vignette.intensity.value;
        smoothnessStart = m_Vignette.smoothness.value;
        roundnessStart = m_Vignette.roundness.value;

        m_Volume = PostProcessManager.instance.QuickVolume(8, 100f, m_Vignette, m_ColorGrading);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && timer >= swapSeconds)
        {
            timer = 0;
            realmSwap = !realmSwap;
            audioSource.Play();
        }

        if (realmPlayer.GetComponent<PlayerHealth>().isDead)
        {
            realmSwap = false;
        }

        if (realmSwap)
        {
            FadeToGrayscale(saturationStart, -100);
            FadeToVignette(intensityStart, smoothnessStart, roundnessStart, .7f, .3f, .8f);
            RealmSwapTime(swapSeconds);
        }
        else if (!realmSwap)
        {
            FadeToGrayscale(saturationStart, -100);
            FadeToVignette(intensityStart, smoothnessStart, roundnessStart, .7f, .3f, .8f);
            RealmSwapTime(-swapSeconds);
        }
    }

    public void RealmSwapTime(float swapSeconds)
    {
        float add = Time.deltaTime * Mathf.Abs(swapSeconds) * (swapSeconds > 0 ? 1 : -1);
        t += add;
        t = Mathf.Clamp(t, 0f, 1f);
    }
    public void PositionLerp(GameObject myGO, Vector3 startPosition, Vector3 endPosition)
    {
        myGO.transform.position = Vector3.Lerp(startPosition, endPosition, t);
    }
    public void ColorLerp(GameObject myGO, Color startColor, Color endColor)
    {
        myGO.GetComponent<MeshRenderer>().material.color = Color.Lerp(startColor, endColor, t);
    }
    public void ShapeScale(GameObject myGO, Vector3 startScale, Vector3 endScale)
    {
        myGO.GetComponent<Transform>().localScale = Vector3.Lerp(startScale, endScale, t);
    }
    public void FadeToGrayscale(float startValue, float targetValue)
    {
        m_ColorGrading.saturation.value = Mathf.Lerp(startValue, targetValue, t);
    }
    public void FadeToVignette(float iStart, float sStart, float rStart, float iTarget, float sTarget, float rTarget)
    {
        m_Vignette.intensity.value = Mathf.Lerp(iStart, iTarget, t);
        m_Vignette.smoothness.value = Mathf.Lerp(sStart, sTarget, t);
        m_Vignette.roundness.value = Mathf.Lerp(rStart, rTarget, t);
    }
}