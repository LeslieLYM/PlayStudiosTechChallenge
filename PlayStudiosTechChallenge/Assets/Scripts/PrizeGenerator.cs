using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The script is responsible for generating the content for the all tiers of the slots for each round. 
/// </summary>
public class PrizeGenerator : MonoBehaviour
{
    [SerializeField] SO_PrizeList prizeListSO;
    [SerializeField] SO_PrizeTable prizeTableSO;

    void Start()
    {
        prizeListSO.tier1List = new SO_PrizeBase[prizeListSO.numberOfPrizes];
        prizeListSO.tier2List = new SO_PrizeBase[prizeListSO.numberOfPrizes];
        prizeListSO.tier3List = new SO_PrizeBase[prizeListSO.numberOfPrizes];

        GenerateAllPrizes();
    }

    public void GenerateAllPrizes()
    {
        for (int i = 0; i < 3; i++)
        {
            GenerateTierPrizes(i);
        }
    }

    //Go through loot table from Prize Table SO to spawn the pattern for each tier to Prize List SO
    private void GenerateTierPrizes(int tier)
    {
        int length = prizeTableSO.GetLength(tier);
        int[] accumulativeFreqs = new int[length];
        int[] freq = prizeTableSO.GetFrequencies(tier);

        //Get the accumulative rate for the prizes first
        accumulativeFreqs[0] = freq[0];
        for (int i = 1; i < length; i++)
        {
            accumulativeFreqs[i] = accumulativeFreqs[i - 1] + freq[i];
        }
        
        //Find the ceiling of the rate of each generated number, it will determine the content
        for (int i = 0; i < prizeListSO.numberOfPrizes; i++)
        {            
            int rand = Random.Range(0, accumulativeFreqs[length - 1]) + 1;

            int l = 0;
            int h = length - 1;

            int outIndex = -1;

            while (l < h)
            {
                int mid = (l + h) / 2;
                if (rand > accumulativeFreqs[mid])
                {
                    l = mid + 1;
                }
                else
                {
                    h = mid;
                }
            }
            if (accumulativeFreqs[l] >= rand)
            {
                outIndex = l;
            }
            prizeListSO.AssignPrizeToList(tier, i, prizeTableSO.GetPrizes(tier)[outIndex]);
        }
    }

    private void OnEnable()
    {
        SummaryCard.OnCardEnded += GenerateAllPrizes;
    }

    private void OnDisable()
    {
        SummaryCard.OnCardEnded -= GenerateAllPrizes;
    }
}
