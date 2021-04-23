using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Prize Asset/Token Prize", fileName = "TokenPrize")]
public class SO_TokenPrize : SO_PrizeBase
{
    public override int ApplyPrizeEffect()
    {
        playerStatSO.RefundToken((int)value);
        return (int) value;
    }
}
