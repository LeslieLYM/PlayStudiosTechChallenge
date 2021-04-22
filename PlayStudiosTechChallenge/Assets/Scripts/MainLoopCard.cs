using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLoopCard : UICard
{
    [SerializeField] Animator animator;
    [SerializeField] AnimationClip tokenInClip;
    [SerializeField] AnimationClip tokenOutClip;

    [Space]
    [SerializeField] CanvasGroup playerInfoCanvasGroup;

    public delegate void CardChangeHandler();
    public static CardChangeHandler OnCardStart;

    public override void StartCardInSequence()
    {
        OnCardStart?.Invoke();
    }

    public override void StartCardOutSequence()
    {

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
