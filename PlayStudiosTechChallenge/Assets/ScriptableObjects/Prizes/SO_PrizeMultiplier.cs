using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prize Asset/Prize Multiplier", fileName = "PrizeMultiplier")]
public class SO_PrizeMultiplier : SO_PrizeBase
{
    public override int ApplyPrizeEffect()
    {
        int i = (int)(playerStatSO.roundTotalPoints * value);
        playerStatSO.StoreNewPoints(i);
        return i;
    }
}
