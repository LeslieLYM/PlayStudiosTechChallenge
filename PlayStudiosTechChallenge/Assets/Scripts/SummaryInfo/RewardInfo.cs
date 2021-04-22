﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RewardInfo : MonoBehaviour
{
    [SerializeField] SO_PlayerStat playerStatSO;

    [SerializeField] TextMeshProUGUI pointsText;

    void UpdatePointsText()
    {
        pointsText.text = playerStatSO.roundTotalPoints.ToString();
    }

    private void Start()
    {
        UpdatePointsText();
    }
}
