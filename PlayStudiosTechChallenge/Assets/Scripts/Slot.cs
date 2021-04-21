using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Slot : MonoBehaviour
{
    [SerializeField] SO_CurrentToken currentToken;
    [SerializeField] GameObject prizeGameObject;
    [SerializeField] TextMeshProUGUI prizeText;

    [Space]
    [SerializeField] int id;

    bool isRevealed = false;

    public void AttemptToUseTokens()
    {
        if (!isRevealed)
        {
            currentToken.tokenPanelGameObject.SetActive(true);
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

    public void AssignId(int i)
    {
        id = i;
    }

    private void Start()
    {
        prizeGameObject.SetActive(false);
    }
}
