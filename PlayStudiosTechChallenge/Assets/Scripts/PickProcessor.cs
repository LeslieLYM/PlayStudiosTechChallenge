using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickProcessor : MonoBehaviour
{
    [SerializeField] SO_PlayerStat playerStatSO;

    //Assess if there are enough tokens
    public void EvaluatePickUse(int i)
    {
        if (playerStatSO.HasEnoughTokens(i))
        {
            //playerStatSO.UsePicks(i);
            return;
        }
        print("You don't have enough tokens.");
    }
}
