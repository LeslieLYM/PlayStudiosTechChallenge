using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PrizeGenerator : MonoBehaviour
{
    [SerializeField] SO_PrizeList prizeListSO;
    [SerializeField] SO_PrizeTable prizeTableSO;

    void Start()
    {
        int length = prizeTableSO.tier1Prizes.Length;
        int[] accumulativeFreqs = new int[length];
        accumulativeFreqs[0] = prizeTableSO.tier1Frequencies[0];

        for (int i = 1; i < length; i++)
        {
            accumulativeFreqs[i] = accumulativeFreqs[i - 1] + prizeTableSO.tier1Frequencies[i];
        }

        prizeListSO.tier1List = new int[prizeListSO.numberOfPrizes];
        for (int i = 0; i < prizeListSO.numberOfPrizes; i++)
        {
            int rand = Random.Range(0, accumulativeFreqs[length - 1]) + 1;

            int l = 0;
            int h = length - 1;

            int outIndex = -1;

            print("rand " + rand);
            while (l < h)
            {
                int mid = (l + h) / 2;
                print("mid " + mid);
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
            prizeListSO.tier1List[i] = prizeTableSO.tier1Prizes[outIndex];
        }
    }

}
