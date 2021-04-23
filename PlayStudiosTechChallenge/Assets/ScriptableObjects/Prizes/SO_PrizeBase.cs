using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SO_PrizeBase : ScriptableObject
{
    public int value;

    public abstract int ApplyPrizeEffect();
}
