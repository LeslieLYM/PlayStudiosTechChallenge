using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TokenInfo : MonoBehaviour
{
    [SerializeField] SO_PlayerStat playerStatSO;

    [SerializeField] TextMeshProUGUI tokenText;

    void UpdateTokenText()
    {
        tokenText.text = playerStatSO.totalTokens.ToString();
    }

    private void OnEnable()
    {
        SO_PlayerStat.OnTokenChanged += UpdateTokenText;
    }

    private void OnDisable()
    {
        SO_PlayerStat.OnTokenChanged -= UpdateTokenText;
    }

    private void Start()
    {
        UpdateTokenText();
    }
}
