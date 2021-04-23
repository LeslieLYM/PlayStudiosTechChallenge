using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The script manages the beginning scene with transitional assets
/// </summary>
public class BeginningCard : UICard
{
    [SerializeField] SO_CanvasSequence canvasSequenceSO;
    [SerializeField] SO_AudioProcessor audioUtilitySO;
    [Space]
    [SerializeField] Animator animator;
    [SerializeField] AnimationClip beginningInClip;
    [SerializeField] AnimationClip beginningOutClip;
    [Space]
    [SerializeField] AudioSource audioSource;

    public delegate void CardTransitionHandler();
    public static CardTransitionHandler OnCardEnded;

    public override void StartCardInSequence()
    {
        animator.Play(beginningInClip.name);
        StartCoroutine(audioUtilitySO.StartFade("MusicVolume", 1.5f, 1f));
        audioSource.Play();
    }

    public override void StartCardOutSequence()
    {
        animator.Play(beginningOutClip.name);
        StartCoroutine(audioUtilitySO.StartFade("MusicVolume", 1.5f, -32));
        OnCardEnded?.Invoke();
    }

    public void DeactivateCard()
    {
        this.gameObject.SetActive(false);
    }

    public void ConcludeCard()
    {
        canvasSequenceSO.SceneChange(0);
    }
}
