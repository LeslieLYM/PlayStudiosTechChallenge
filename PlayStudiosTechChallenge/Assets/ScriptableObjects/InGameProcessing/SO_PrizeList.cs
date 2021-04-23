using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// SO_PrizeList stores the generated prize data for each round. Dictionary is used to be reference for other scripts
/// </summary>
[CreateAssetMenu(menuName = "Game Statistic/Prize List", fileName = "PrizeList")]
public class SO_PrizeList : ScriptableObject
{
    public int numberOfPrizes = 1;
    public SO_PrizeBase[] tier1List;
    public SO_PrizeBase[] tier2List;
    public SO_PrizeBase[] tier3List;

    Dictionary<int, SO_PrizeBase[]> prizeTierPair = new Dictionary<int, SO_PrizeBase[]>();

    public SO_PrizeBase RequestPrize(int t, int id)
    {
        return prizeTierPair[t][id];
    }

    public void AssignPrizeToList(int tier, int i, SO_PrizeBase prize)
    {
        prizeTierPair[tier][i] = prize;

        //Feedback to inspector only
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
