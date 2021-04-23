using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This scriptable object is used to store which scene (canvas) is in current and communicate Script Sequencer to trigger transitions 
/// </summary>
[CreateAssetMenu(menuName = "Game Statistic/Canvas Sequence Info", fileName = "CanvasSequence")]
public class SO_CanvasSequence : ScriptableObject
{
    public int currentCanvasScene; //Scene to be used as next current
    public int previousCanvasScene;

    public delegate void CanvasChangeHandler();
    public static CanvasChangeHandler OnCanvasChanged;
    public static CanvasChangeHandler OnPreCanvasChanged;

    public void PreSceneChange(int currentScene)
    {
        previousCanvasScene = currentScene;
        OnPreCanvasChanged?.Invoke();
    }

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
