using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TokenPanel : MonoBehaviour
{
    [SerializeField] SO_CurrentToken currentToken;
    [SerializeField] TextMeshProUGUI tokenAmountText;

    public void UpdateTokenText()
    {
        tokenAmountText.text = currentToken.currentTokenUse.ToString();
    }

    private void Awake()
    {
        currentToken.tokenPanelGameObject = this.gameObject;
        this.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        //SummaryCard.OnCardEnded += UpdateTokenText;
        SO_CurrentToken.OnTokenChanged += UpdateTokenText;
    }

    private void OnDisable()
    {
        //SummaryCard.OnCardEnded -= UpdateTokenText;
        SO_CurrentToken.OnTokenChanged -= UpdateTokenText;
    }
}
