using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// The scripts manages all the slots, specifically their interactivity & get content for the unlocking slot
/// </summary>
public class SlotsGrid : MonoBehaviour
{
    [SerializeField] SO_PlayerStat playerStatSO;
    [SerializeField] SO_CurrentToken currentToken;
    [SerializeField] SO_PrizeList prizeListSO;
    public EventTrigger[] eventTriggers;

    private void Awake()
    {
        eventTriggers = GetComponentsInChildren<EventTrigger>();
        prizeListSO.numberOfPrizes = eventTriggers.Length;

        if (eventTriggers.Length > 0)
        {
            for (int i = 0; i < eventTriggers.Length; i++)
            {
                eventTriggers[i].GetComponentInParent<Slot>().AssignId(i);
                eventTriggers[i].gameObject.SetActive(false);
            }
        }
    }

    public void OffInteractivity()
    {
        SetSlotsInteractivity(false);
    }

    public void OnInteractivity()
    {
        SetSlotsInteractivity(true);
    }

    public void SetSlotsInteractivity(bool active)
    {
        if (eventTriggers.Length > 0)
        {
            for (int i = 0; i < eventTriggers.Length; i++)
            {
                eventTriggers[i].gameObject.SetActive(active);
            }
        }
    }

    //Identify the selected slot form Current Token SO and access content from PrizeList SO to reveal the prize
    public void RevealSelectedSlot()
    {
        Slot s = eventTriggers[currentToken.currentSelectedSlot].GetComponentInParent<Slot>();
        SO_PrizeBase p = prizeListSO.RequestPrize(currentToken.currentTokenUse - 1, currentToken.currentSelectedSlot);
        p.ApplyPrizeEffect();
        s.RevealPrize(p.prizeDisplay);

        //Use token(s) afterwards
        playerStatSO.UsePicks();
    }

    private void OnEnable()
    {
        BeginningCard.OnCardEnded += OnInteractivity;
        SO_PlayerStat.OnTokenEmptied += OffInteractivity;
        SummaryCard.OnCardEnded += OffInteractivity;
    }

    private void OnDisable()
    {
        BeginningCard.OnCardEnded -= OnInteractivity;
        SO_PlayerStat.OnTokenEmptied -= OffInteractivity;
        SummaryCard.OnCardEnded -= OffInteractivity;
    }
}
