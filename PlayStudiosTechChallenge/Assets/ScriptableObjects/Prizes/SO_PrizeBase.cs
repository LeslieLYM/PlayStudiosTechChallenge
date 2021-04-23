using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SO_PrizeBase : ScriptableObject
{
    [SerializeField] protected SO_PlayerStat playerStatSO;

    [Space]
    public string prizeDisplay;
    public float value;

    public abstract int ApplyPrizeEffect();
}
