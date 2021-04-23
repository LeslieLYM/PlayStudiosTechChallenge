using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Statistic/Canvas Sequence Info", fileName = "CanvasSequence")]
public class SO_CanvasSequence : ScriptableObject
{
    public int currentCanvasScene; //Scene to be used as next current

    public delegate void CanvasChangeHandler();
    public static CanvasChangeHandler OnCanvasChanged;

    public void SceneChange(int currentScene)
    {
        currentCanvasScene = currentScene + 1;
        OnCanvasChanged?.Invoke();
    }

    public void ResetScene(int resetScene = 0)
    {
        currentCanvasScene = resetScene;
        OnCanvasChanged?.Invoke();
    }
}
