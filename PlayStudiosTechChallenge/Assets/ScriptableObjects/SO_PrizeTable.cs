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
}
