using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Statistic/Prize List", fileName = "PrizeList")]
public class SO_PrizeList : ScriptableObject
{
    public int numberOfPrizes = 1;
    public int[] tier1List;
    public int[] tier2List;
    public int[] tier3List;

    Dictionary<int, int[]> prizeTierPair = new Dictionary<int, int[]>();

    public int RequestPrize(int t, int id)
    {
        return prizeTierPair[t][id];
    }

    public void AssignPrizeToList(int tier, int i, int prize)
    {
        prizeTierPair[tier][i] = prize;

        //Feedback to inspector
        switch (tier)
        {
            case 0:
                tier1List[i] = prizeTierPair[tier][i];
                break;
            case 1:
                tier2List[i] = prizeTierPair[tier][i];
                break;
            case 2:
                tier3List[i] = prizeTierPair[tier][i];
                break;
            default:
                Debug.LogError("Token used is out of range, need to check Current Token scriptable object.");
                break;
        }
    }

    private void OnEnable()
    {
        prizeTierPair.Clear();
        prizeTierPair.Add(0, tier1List);
        prizeTierPair.Add(1, tier2List);
        prizeTierPair.Add(2, tier3List);
    }
}
