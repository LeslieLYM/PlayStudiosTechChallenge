using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Statistic/Player Statistic", fileName = "PlayerStatistic")]
public class SO_PlayerStat : ScriptableObject
{
    [Header("Setup")]
    public int maxTokens;


    [Header("Player's info")]
    public int totalPoints;
    public int roundTotalPoints;
    public int totalTokens;

    int potentialTokens = 0;

    public delegate void ResourceChangeHandler();
    public static ResourceChangeHandler OnTokenChanged;
    public static ResourceChangeHandler OnPointsChanged;

    [Space]
    [Space]
    [SerializeField] bool reset;

    public void StoreNewPoints(int pt)
    {
        roundTotalPoints += pt;
        OnPointsChanged?.Invoke();
    }

    public void UsePicks()
    {
        if (totalTokens < potentialTokens)
        {
            Debug.LogError("Total pick will drop below zero. Current pick use is skipped but check the pick processing method.");
            return;
        }
        totalTokens -= potentialTokens;
        OnTokenChanged?.Invoke();

        potentialTokens = 0;
    }

    public void AssumeTokenUse(int i)
    {
        potentialTokens = i;
    }

    public bool HasEnoughTokens(int i)
    {
        return totalTokens >= i;
    }





    private void OnValidate()
    {
        if (reset)
        {
            roundTotalPoints = 0;
            totalTokens = 10;
            potentialTokens = 0;
            reset = false;
        }
    }
}
