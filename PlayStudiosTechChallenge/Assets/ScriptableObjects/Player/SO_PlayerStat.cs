using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Statistic/Player Statistic", fileName = "PlayerStatistic")]
public class SO_PlayerStat : ScriptableObject
{
    [Header("Setup")]
    public int maxTokens;

    [Space]
    [Header("Player's info")]
    public int totalPoints;
    public int totalTokens;

    public void StoreNewPoints(int pt)
    {
        totalPoints += pt;
    }

    public void UsePicks(int i)
    {
        if (totalTokens - i < 0)
        {
            Debug.LogError("Total pick will drop below zero. Current pick use is skipped but check the pick processing method.");
            return;
        }
        totalTokens -= i;
    }

    public bool HasEnoughTokens(int i)
    {
        return totalTokens >= i;
    }
}
