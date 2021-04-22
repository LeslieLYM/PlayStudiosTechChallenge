using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptSquencer : MonoBehaviour
{
    [SerializeField] SO_CanvasSequence canvasSequenceSO;
    [SerializeField] Canvas[] sequenceCanvas;
    private void Awake()
    {
        sequenceCanvas[0].gameObject.SetActive(true);
    }

    public void TriggerNextSequence()
    {
        GameObject c = sequenceCanvas[canvasSequenceSO.currentCanvasScene].gameObject;
        if (!c.activeSelf)
        {
            c.SetActive(true);
        }       
        sequenceCanvas[canvasSequenceSO.currentCanvasScene].GetComponent<UICard>().StartCardInSequence();
    }

    private void OnEnable()
    {
        //SO_PlayerStat.OnTokenEmptied += ;
        SO_CanvasSequence.OnCanvasChanged += TriggerNextSequence;
    }

    private void OnDisable()
    {
        //SO_PlayerStat.OnTokenEmptied -= EvaluateGameEnd;
        SO_CanvasSequence.OnCanvasChanged -= TriggerNextSequence;
    }
}