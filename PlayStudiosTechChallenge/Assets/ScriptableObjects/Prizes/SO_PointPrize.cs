using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prize Asset/Point Prize", fileName = "PointPrize")]
public class SO_PointPrize : SO_PrizeBase
{
    public override int ApplyPrizeEffect()
    {
        int i = playerStatSO.roundTotalPoints + (int)value;
        playerStatSO.StoreNewPoints(i);
        return i;
    }
}
