using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RewardInfo : MonoBehaviour
{
    [SerializeField] SO_PlayerStat playerStatSO;

    [SerializeField] TextMeshProUGUI pointsText;

    void UpdatePointsText()
    {
        pointsText.text = "+" + playerStatSO.roundTotalPoints.ToString();
    }

    private void OnEnable()
    {
        SO_PlayerStat.OnRoundPointsChanged += UpdatePointsText;
    }

    private void OnDisable()
    {
        SO_PlayerStat.OnRoundPointsChanged -= UpdatePointsText;
    }

    private void Start()
    {
        UpdatePointsText();
    }
}
