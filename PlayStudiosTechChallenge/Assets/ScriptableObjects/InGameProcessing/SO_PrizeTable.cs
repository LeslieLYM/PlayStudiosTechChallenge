using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The scriptable object stores the loot table for each tier prizes. Designers can allocate PrizeBase scriptable objects with their spawn rate here.
/// </summary>
[CreateAssetMenu(menuName = "Prize Asset/Prize Table", fileName = "PrizeTable")]
public class SO_PrizeTable : ScriptableObject
{
    [Header("====Tier 1====")]
    public SO_PrizeBase[] tier1Prizes;
    public int[] tier1Frequencies;

    [Header("====Tier 2====")]
    [Space]
    public SO_PrizeBase[] tier2Prizes;
    public int[] tier2Frequencies;

    [Header("====Tier 3====")]
    [Space]
    public SO_PrizeBase[] tier3Prizes;
    public int[] tier3Frequencies;

    Dictionary<int, SO_PrizeBase[]> prizePair = new Dictionary<int, SO_PrizeBase[]>();
    Dictionary<int, int[]> frequencyPair = new Dictionary<int, int[]>();

    public int GetLength(int i)
    {
        return prizePair[i].Length;
    }

    public SO_PrizeBase[] GetPrizes(int tier)
    {
        return prizePair[tier];
    }
    
    public int[] GetFrequencies(int tier)
    {
        return frequencyPair[tier];
    }

    private void OnEnable()
    {
        prizePair.Clear();
        frequencyPair.Clear();

        prizePair.Add(0, tier1Prizes);
        prizePair.Add(1, tier2Prizes);
        prizePair.Add(2, tier3Prizes);

        frequencyPair.Add(0, tier1Frequencies);
        frequencyPair.Add(1, tier2Frequencies);
        frequencyPair.Add(2, tier3Frequencies);
    }
}
