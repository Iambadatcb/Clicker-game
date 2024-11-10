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
    // public ParticleSystemRenderer effects;
    public Mesh mesh;
    [HideInInspector]public int clicks = 0;

    private AudioSource audioSource;

    private  int oldClicks =0;

     private Shop bakers;
     private int changesClick = 0;
     
    
    void Start()
    {
        
        clicks = PlayerPrefs.GetInt("clicks", 0);
        // bakers.upgrade = PlayerPrefs.GetInt("upgrades", 0);
        // bakers.count = PlayerPrefs.GetInt("rebirths", 0);
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("CountClicks", 1,1);
        bakers = FindObjectOfType<Shop>();
    }
    void Update()
    {
        Changes();

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
        if(bakers.upgrade >=1)
        {
            clicks+= 2 * bakers.upgrade;
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
        changesClick++;
        // PlayerPrefs.SetInt("Clicks", clicks);
        
        // PlayerPrefs.Save();
        // .SetLoops(2,LoopType.Yoyo);
    }
    
    private void CountClicks(){
        var cps = clicks-oldClicks;
        oldClicks = clicks;

        UIManager.instance.UpdateCps(cps);
    }
    private void OnApplicationPause(bool pauseStatus)
    {
        if(pauseStatus){
            Save();
        }
    }
    private void OnApplicationQuit()
    {
        Save();
    }
    public void Save(){
        PlayerPrefs.SetInt("clicks", clicks);
        // PlayerPrefs.SetInt("rebirths", bakers.count);
        // PlayerPrefs.SetInt("upgrades", bakers.upgrade);
        PlayerPrefs.Save();
    }
    private void Changes()
    {
        if (changesClick ==100)
        {
            changesClick = 0;
            var main = clickVFX.main;
            var shape = clickVFX.shape;
            // effects = GetComponent<ParticleSystemRenderer>();

            main.startDelay = 1.0f;
            shape.enabled= true;
            shape.shapeType = ParticleSystemShapeType.Mesh;
            shape.mesh = mesh;
            // effects.mesh = Resources.GetBuiltinResource<Mesh>("Sphere.fbx");
        }

    }

    
}
