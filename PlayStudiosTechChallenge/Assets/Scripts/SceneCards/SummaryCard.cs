using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The script manages the summary scene with transitional assets
/// </summary>
public class SummaryCard : UICard
{
    [SerializeField] SO_AudioProcessor audioUtilitySO;
    [SerializeField] SO_PlayerStat playerStatSO;
    [Space]
    [SerializeField] Animator animator;
    [SerializeField] AnimationClip summaryInClip;
    [SerializeField] AnimationClip summaryOutClip;

    [Space]
    [SerializeField] AudioSource audioSource;

    public delegate void CardTransitionHandler();
    public static CardTransitionHandler OnCardEnded;

    public override void StartCardInSequence()
    {

        audioSource.Play();
        StartCoroutine(audioUtilitySO.StartFade("MusicVolume", 1.5f, 1f));
        animator.Play(summaryInClip.name);        
    }

    public override void StartCardOutSequence()
    {
        animator.Play(summaryOutClip.name);
        //StartCoroutine(audioUtilitySO.StartFade("MusicVolume", 1.5f, -32));
        audioSource.Stop();
        playerStatSO.ResetForNewRound();
        OnCardEnded?.Invoke();
    }

    public void EndGame()
    {
        print("Game end.");
        Application.Quit();
    }
}
