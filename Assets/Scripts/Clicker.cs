using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;
using System;

public class Clicker : MonoBehaviour
{
    [Header("Animation settings")]
    public float scale= 1.2f;
    public float duration = 0.1f;
    public Ease ease = Ease.OutElastic;

    [Header("Audio")]
    public AudioClip clip;

    [Header("VFX")]
    public ParticleSystem clickVFX;
    [HideInInspector]public int clicks = 0;

    private AudioSource audioSource;

     private Shop bakers;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        bakers = FindObjectOfType<Shop>();
    }
    // void Update()
    // {
    //     if (bakers.count>0)
    //     {
    //         clicks += 1*bakers.count;
    //         InvokeRepeating("BakerJob",0.1f,1.0f);

    //     }

    // }
    private void OnMouseDown()
    {
        clickVFX.Emit(1);
        if(bakers.upgrade ==1)
        {
            clicks+=2;
        }
        else if(bakers.upgrade<1)
        {

            clicks++;
        }
        // Debug.Log("Clicks: " + clicks);
        UIManager.instance.UpdateClicks(clicks);

        audioSource.pitch = UnityEngine.Random.Range(0.9f, 1.1f);
        audioSource.PlayOneShot(clip);

        transform
        .DOScale(1, duration)
        .ChangeStartValue(scale * Vector3.one)
        .SetEase(ease);
        
        PlayerPrefs.SetInt("Clicks", clicks);
        
        PlayerPrefs.Save();
        // .SetLoops(2,LoopType.Yoyo);
    }
    

    
}
