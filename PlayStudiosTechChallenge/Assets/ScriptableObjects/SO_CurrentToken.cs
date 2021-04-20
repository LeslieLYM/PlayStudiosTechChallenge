using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Statistic/Current Token Flow", fileName = "CurrentTokenFlow")]
public class SO_CurrentToken : ScriptableObject
{
    public GameObject tokenPanelGameObject;
    public int currentTokenUse = 1;
    public int currentSelectedSlot = -1;

    public void ChangeTokenUse(int i)
    {
        currentTokenUse += i;
        currentTokenUse = Mathf.Clamp(currentTokenUse, 1, 3);
    }

    public void SetSelectedSlot(int i)
    {
        currentSelectedSlot = i;
    }

    private void OnDisable()
    {
        tokenPanelGameObject = null;
        currentTokenUse = 1;
        currentSelectedSlot = -1;
    }
}
