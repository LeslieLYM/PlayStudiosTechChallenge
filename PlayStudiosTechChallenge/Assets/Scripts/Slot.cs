using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] SO_CurrentToken currentToken;
    [SerializeField] GameObject prizeGameObject;
    [SerializeField] TextMeshProUGUI prizeText;
    [SerializeField] CanvasGroup slotCG;

    [SerializeField] MainLoopCard mainCard;

    [Header("Sprites Setup")]
    [Space]
    [SerializeField] Image slotContentImage;
    [SerializeField] Sprite closedSlotSprite;
    [SerializeField] Sprite openSlotSprite;

    [Header("Animation Setup")]
    [Space]
    [SerializeField] Animator animator;
    [SerializeField] AnimationClip slotInClip;
    [SerializeField] AnimationClip slotOutClip;
    [SerializeField] AnimationClip slotZoomInClip;
    [SerializeField] AnimationClip slotZoomOutClip;
    [SerializeField] AnimationClip slotZoomPopClip;

    [Header("Audio Setup")]
    [Space]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] bubbleClips;

    [Space]
    [SerializeField] int id;
    

    bool isRevealed = false;
    bool isHighlighted = false;
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

    public void HighlightSlot()
    {
        if (!isRevealed)
        {
            isHighlighted = true;
            animator.Play(slotZoomInClip.name);
            animator.SetLayerWeight(1, 1);
            PlaySlotSound(bubbleClips[Random.Range(0, bubbleClips.Length)]);
        }        
    }
    
    public void UnHighlightSlot()
    {
        if (!isRevealed)
        {
            isHighlighted = false;
            animator.Play(slotZoomOutClip.name);
            animator.SetLayerWeight(1, 0);
        }        
    }

    public void RevealPrize(int i)
    {
        slotContentImage.sprite = openSlotSprite;
        prizeText.text = i.ToString();
        animator.Play(slotZoomOutClip.name);
        prizeGameObject.SetActive(true);
    }

    public void RegisterAsSelected()
    {
        currentToken.SetSelectedSlot(id);
        animator.SetLayerWeight(1, 0);
    }

    void IntroduceSlot()
    {
        clipPlayed = StartCoroutine(PlaySlotClip(slotInClip));
    }

    void HideSlot()
    {
        if (prizeGameObject.activeSelf)
        {
            slotContentImage.sprite = closedSlotSprite;
            prizeGameObject.SetActive(false);
            isRevealed = false;
        }
        clipPlayed = StartCoroutine(PlaySlotClip(slotOutClip));
    }

    void PlaySlotSound(AudioClip c)
    {
        audioSource.clip = c;
        audioSource.Play();
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
        slotCG.alpha = 0;
        prizeGameObject.SetActive(false);
    }
}
