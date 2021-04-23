using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLoopCard : UICard
{
    [SerializeField] SO_AudioProcessor audioUtilitySO;

    [SerializeField] Animator animator;
    [SerializeField] AnimationClip tokenInClip;
    [SerializeField] AnimationClip tokenOutClip;

    [Space]
    [SerializeField] AudioSource audioSource;

    public delegate void CardChangeHandler();
    public static CardChangeHandler OnCardStart;

    public override void StartCardInSequence()
    {
        StartCoroutine(audioUtilitySO.StartFade("SFXVolume", 1.5f, 1));
        audioSource.Play();
        OnCardStart?.Invoke();
    }

    public override void StartCardOutSequence()
    {
        StartCoroutine(audioUtilitySO.StartFade("SFXVolume", 1.5f, -32));
        StartCoroutine(audioUtilitySO.DelayStopSound(audioSource, 1.5f));
    }
    
    public void ActivateTokenPanel()
    {
        animator.Play(tokenInClip.name);
    }

    public void DeactivateTokenPanel()
    {
        animator.Play(tokenOutClip.name);
    }
}
