using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Slot : MonoBehaviour
{
    [SerializeField] SO_CurrentToken currentToken;
    [SerializeField] GameObject prizeGameObject;
    [SerializeField] TextMeshProUGUI prizeText;

    [SerializeField] MainLoopCard mainCard;

    [Space]
    [SerializeField] Animator animator;
    [SerializeField] AnimationClip slotInClip;
    [SerializeField] AnimationClip slotOutClip;

    [Space]
    [SerializeField] int id;

    bool isRevealed = false;
    Coroutine clipPlayed;

    public void AttemptToUseTokens()
    {
        if (!isRevealed)
        {
            currentToken.tokenPanelGameObject.SetActive(true);
            mainCard.ActivateTokenPanel();
            isRevealed = true;
        }        
    }

    public void RevealPrize(int i)
    {
        prizeText.text = i.ToString();
        prizeGameObject.SetActive(true);
    }

    public void RegisterAsSelected()
    {
        currentToken.SetSelectedSlot(id);
    }

    void IntroduceSlot()
    {
        clipPlayed = StartCoroutine(PlaySlotClip(slotInClip));
    }

    void HideSlot()
    {
        if (prizeGameObject.activeSelf)
        {
            prizeGameObject.SetActive(false);
            isRevealed = false;
        }
        clipPlayed = StartCoroutine(PlaySlotClip(slotOutClip));
    }

    IEnumerator PlaySlotClip(AnimationClip clip)
    {
        yield return new WaitForSeconds(Random.Range(0, 0.34f));
        animator.Play(clip.name);
        StopCoroutine(clipPlayed);
    }

    public void AssignId(int i)
    {
        id = i;
    }

    private void OnEnable()
    {
        MainLoopCard.OnCardStart += IntroduceSlot;
        SummaryCard.OnCardEnded += HideSlot;
    }

    private void OnDisable()
    {
        MainLoopCard.OnCardStart -= IntroduceSlot;
        SummaryCard.OnCardEnded -= HideSlot;
    }

    private void Awake()
    {
        mainCard = GetComponentInParent<MainLoopCard>();
    }

    private void Start()
    {
        prizeGameObject.SetActive(false);
    }
}
