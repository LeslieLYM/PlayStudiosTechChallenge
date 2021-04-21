using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsInfo : MonoBehaviour
{
    [SerializeField] SO_PlayerStat playerStatSO;

    [SerializeField] TextMeshProUGUI pointsText;

    void UpdatePointsText()
    {
        pointsText.text = playerStatSO.totalPoints.ToString();
    }

    private void OnEnable()
    {
        SO_PlayerStat.OnPointsChanged += UpdatePointsText;
    }

    private void OnDisable()
    {
        SO_PlayerStat.OnPointsChanged -= UpdatePointsText;
    }

    private void Start()
    {
        pointsText.text = playerStatSO.totalPoints.ToString();
    }
}
