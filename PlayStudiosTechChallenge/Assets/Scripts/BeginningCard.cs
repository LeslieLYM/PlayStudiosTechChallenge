using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginningCard : UICard
{
    [SerializeField] SO_CanvasSequence canvasSequenceSO;
    [SerializeField] Animator animator;
    [SerializeField] AnimationClip beginningInClip;
    [SerializeField] AnimationClip beginningOutClip;

    public delegate void CardTransitionHandler();
    public static CardTransitionHandler OnCardEnded;

    public override void StartCardInSequence()
    {
        animator.Play(beginningInClip.name);
    }

    public override void StartCardOutSequence()
    {
        animator.Play(beginningOutClip.name);
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
