using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (totalTokens <= 0)
        {
            SecureRoundPoints(roundTotalPoints);
        }
    }
    
    public void RefundToken(int i)
    {
        totalTokens += i;
        OnTokenChanged?.Invoke();
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

        if (totalTokens <= 0)
        {
            canvasSequenceSO.PreSceneChange(1);
            canvasSequenceSO.SceneChange(1);
            OnTokenEmptied?.Invoke();
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
    }
}
