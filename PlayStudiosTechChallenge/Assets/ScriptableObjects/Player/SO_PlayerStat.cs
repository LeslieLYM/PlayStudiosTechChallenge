using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Statistic/Player Statistic", fileName = "PlayerStatistic")]
public class SO_PlayerStat : ScriptableObject
{
    public int totalPoints;
    public int totalPicks;

    public void StoreNewPoints(int pt)
    {
        totalPoints += pt;
    }

    public void UsePicks(int i)
    {
        if (totalPicks - i < 0)
        {
            Debug.LogError("Total pick will drop below zero. Current pick use is skipped but check the pick processing method.");
            return;
        }
        totalPicks -= i;
    }
}
