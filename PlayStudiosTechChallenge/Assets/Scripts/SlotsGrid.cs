using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotsGrid : MonoBehaviour
{
    [SerializeField] SO_CurrentToken currentToken;
    public EventTrigger[] eventTriggers;

    private void Awake()
    {
        eventTriggers = GetComponentsInChildren<EventTrigger>();

        if (eventTriggers.Length > 0)
        {
            for (int i = 0; i < eventTriggers.Length; i++)
            {
                eventTriggers[i].GetComponentInParent<Slot>().AssignId(i);
            }
        }
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

    public void RevealSelectedSlot()
    {
        eventTriggers[currentToken.currentSelectedSlot].GetComponentInParent<Slot>().RevealPrize();
    }
}
