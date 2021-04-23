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

    void TriggerCurrentOutSequence()
    {
        sequenceCanvas[canvasSequenceSO.previousCanvasScene].GetComponent<UICard>().StartCardOutSequence();
    }

    void TriggerNextSequence()
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
        SO_CanvasSequence.OnCanvasChanged += TriggerNextSequence;
        SO_CanvasSequence.OnPreCanvasChanged += TriggerCurrentOutSequence;
    }

    private void OnDisable()
    {
        SO_CanvasSequence.OnCanvasChanged -= TriggerNextSequence;
        SO_CanvasSequence.OnPreCanvasChanged -= TriggerCurrentOutSequence;
    }
}