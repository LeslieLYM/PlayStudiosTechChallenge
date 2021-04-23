﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(menuName = "Game Utilities/Audio Mixing Utilities", fileName = "AudioUtilities")]
public class SO_AudioProcessor : ScriptableObject
{
    public AudioMixer audioMixer;

    public IEnumerator StartFade(string param, float duration, float targetVolume)
    {        
        float currentVolume;
        audioMixer.GetFloat(param, out currentVolume);
        Debug.Log("Fade Start " + currentVolume);
        currentVolume = Mathf.Pow(10, currentVolume / 20);
        float clampedVolume = Mathf.Clamp(targetVolume, 0.0001f, 1);

        float currentTime = 0;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            float newVolume = Mathf.Lerp(currentVolume, clampedVolume, currentTime / duration);
            audioMixer.SetFloat(param, Mathf.Log10(newVolume) * 20);
            yield return null;
        }
        yield break;
    }
}
