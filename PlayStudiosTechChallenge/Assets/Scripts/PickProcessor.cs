using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickProcessor : MonoBehaviour
{
    [SerializeField] SO_PlayerStat playerStatSO;

    //Assess if there are enough tokens
    public void EvaluateGameEnd()
    {
        if (playerStatSO.totalTokens <= 0)
        {
            print("Game end.");
        }
    }

    private void OnEnable()
    {
        SO_PlayerStat.OnTokenChanged += EvaluateGameEnd;
    }

    private void OnDisable()
    {
        SO_PlayerStat.OnTokenChanged -= EvaluateGameEnd;
    }
}
