using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    [SerializeField] SO_CurrentToken currentToken;
    [SerializeField] GameObject prizeGameObject;

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

    public void RevealPrize()
    {
        prizeGameObject.SetActive(true);
        print("you got prize!");
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
