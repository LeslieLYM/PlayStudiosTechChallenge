using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prize Asset/Prize Table", fileName = "PrizeTable")]
public class SO_PrizeTable : ScriptableObject
{
    [Header("====Tier 1====")]
    public int[] tier1Prizes;
    public int[] tier1Frequencies;

    [Header("====Tier 2====")]
    public int[] tier2Prizes;
    public int[] tier2Frequencies;

    [Header("====Tier 3====")]
    public int[] tier3Prizes;
    public int[] tier3Frequencies;

    Dictionary<int, int[]> prizePair = new Dictionary<int, int[]>();
    Dictionary<int, int[]> frequencyPair = new Dictionary<int, int[]>();

    public int GetLength(int i)
    {
        return prizePair[i].Length;
    }

    public int[] GetPrizes(int tier)
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
