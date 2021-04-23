using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfoPanel : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] AnimationClip panelClip;

    void IntroduceInfo()
    {
        animator.Play(panelClip.name);
    }

    private void OnEnable()
    {
        MainLoopCard.OnCardStart += IntroduceInfo;
    }

    private void OnDisable()
    {
        MainLoopCard.OnCardStart -= IntroduceInfo;
    }
}
