using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

public class Clicker : MonoBehaviour
{
    [Header("Animation settings")]
    public float scale= 1.2f;
    public float duration = 0.1f;
    public Ease ease = Ease.OutElastic;

    private int clicks = 0;
    public AudioClip clip;

    private AudioSource audioSource;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnMouseDown()
    {
        clicks++;
        // Debug.Log("Clicks: " + clicks);
        UIManager.instance.UpdateClicks(clicks);

        transform
        .DOScale(1, duration)
        .ChangeStartValue(scale * Vector3.one)
        .SetEase(ease);
        // .SetLoops(2,LoopType.Yoyo);
        audioSource.PlayOneShot(clip);
    }

    
}
