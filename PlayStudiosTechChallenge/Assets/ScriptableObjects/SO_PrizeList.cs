using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Statistic/Prize List", fileName = "PrizeList")]
public class SO_PrizeList : ScriptableObject
{
    public int numberOfPrizes = 1;
    public int[] tier1List;
}
