using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This scriptable object manages all players' statistics and offers corresponding methods
/// </summary>
[CreateAssetMenu(menuName = "Game Statistic/Player Statistic", fileName = "PlayerStatistic")]
public class SO_PlayerStat : ScriptableObject
{
    [SerializeField] SO_CanvasSequence canvasSequenceSO;

    [Header("Setup")]
    public int maxTokens;

    [Header("Player's info")]
    public int totalPoints;
    public int roundTotalPoints;
    public int totalTokens;
    public int refundTokens;

    int potentialTokens = 0;

    public delegate void ResourceChangeHandler();
    public static ResourceChangeHandler OnTokenChanged;
    public static ResourceChangeHandler OnTokenEmptied;
    public static ResourceChangeHandler OnRoundPointsChanged;
    public static ResourceChangeHandler OnPointsChanged;

    [Header("Reset Preset")]
    [Space(25)]
    [SerializeField] bool reset;
    [SerializeField] bool resetOnStart;
    [SerializeField] int resetTokens = 10;
    [SerializeField] int resetBasePoints = 0;
    [SerializeField] int resetRoundPoints = 0;

    public void SecureRoundPoints(int pt)
    {
        totalPoints += pt;
        OnPointsChanged?.Invoke();
    }

    public void StoreNewPoints(int pt)
    {
        roundTotalPoints = pt;
        OnRoundPointsChanged?.Invoke();
    }
    
    //Refund tokens are first stored separately
    public void RefundToken(int i)
    {
        refundTokens += i;
        OnTokenChanged?.Invoke();
    }

    public void UsePicks()
    {
        //Check if there are weird cases that total tokens are fewer than tokens suggested to be spended
        if (totalTokens < potentialTokens)
        {
            Debug.LogError("Total pick will drop below zero. Current pick use is skipped but check the pick processing method.");
            return;
        }
        totalTokens -= potentialTokens;
        OnTokenChanged?.Invoke();

        //Refund the earned tokens back to the total before game end check
        if (refundTokens > 0)
        {
            totalTokens += refundTokens;
            refundTokens = 0;
            OnTokenChanged?.Invoke();
        }

        //Trigger scene transition to summary scene when all tokens are used
        if (totalTokens <= 0)
        {
            if (refundTokens <= 0)
            {
                SecureRoundPoints(roundTotalPoints);
                canvasSequenceSO.PreSceneChange(1);
                canvasSequenceSO.SceneChange(1);
                OnTokenEmptied?.Invoke();
            }      
        }

        potentialTokens = 1;
    }

    public void AssumeTokenUse(int i)
    {
        potentialTokens = i;
    }

    public bool HasEnoughTokens(int i)
    {
        return totalTokens >= i;
    }

    public void ResetForNewRound()
    {
        totalTokens = resetTokens;
        roundTotalPoints = 0;
        potentialTokens = 0;
        OnTokenChanged?.Invoke();
        OnRoundPointsChanged?.Invoke();
    }

    private void OnEnable()
    {
        if (resetOnStart)
        {
            ResetStats();
        }
        OnTokenChanged?.Invoke();
    }

    private void OnValidate()
    {
        if (reset)
        {
            ResetStats();
            totalPoints = resetBasePoints;
            reset = false;
        }
    }

    private void ResetStats()
    {
        roundTotalPoints = resetRoundPoints;
        totalTokens = resetTokens;
        potentialTokens = 1;
        refundTokens = 0;
    }
}
