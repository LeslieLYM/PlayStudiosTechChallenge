using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummaryCard : UICard
{
    [SerializeField] SO_PlayerStat playerStatSO;
    [Space]
    [SerializeField] Animator animator;
    [SerializeField] AnimationClip summaryInClip;
    [SerializeField] AnimationClip summaryOutClip;

    public delegate void CardTransitionHandler();
    public static CardTransitionHandler OnCardEnded;

    public override void StartCardInSequence()
    {
        animator.Play(summaryInClip.name);        
    }

    public override void StartCardOutSequence()
    {
        animator.Play(summaryOutClip.name);
        playerStatSO.ResetForNewRound();
        OnCardEnded?.Invoke();
    }

    public void EndGame()
    {
        print("Game end.");
        Application.Quit();
    }
}
