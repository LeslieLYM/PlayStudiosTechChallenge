using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// SO_CurrentToken stores the current states of the tokens and selection of slot
/// </summary>
[CreateAssetMenu(menuName = "Game Statistic/Current Token Flow", fileName = "CurrentTokenFlow")]
public class SO_CurrentToken : ScriptableObject
{
    [SerializeField] SO_PlayerStat playerStatSO;
    public GameObject tokenPanelGameObject;
    public int currentTokenUse = 1;
    public int currentSelectedSlot = -1;

    public delegate void currentChangeHandler();
    public static currentChangeHandler OnTokenChanged;

    public void ChangeTokenUse(int i)
    {
        currentTokenUse = (currentTokenUse + i > playerStatSO.totalTokens)? currentTokenUse : currentTokenUse + i;
        currentTokenUse = Mathf.Clamp(currentTokenUse, 1, 3);
        playerStatSO.AssumeTokenUse(currentTokenUse);
    }

    public void SetSelectedSlot(int i)
    {
        currentSelectedSlot = i;
    }

    public void ResetTokenUse()
    {
        currentTokenUse = 1;
        playerStatSO.AssumeTokenUse(currentTokenUse);
        OnTokenChanged?.Invoke();
    }

    private void OnEnable()
    {
        tokenPanelGameObject = null;
        currentTokenUse = 1;
        currentSelectedSlot = -1;
    }
}
