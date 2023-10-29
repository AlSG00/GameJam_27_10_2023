using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothAudioMute : MonoBehaviour
{
    //public bool isPassed;
    //public AudioClip sound;
    public AudioSource _audioSource;

    public float timeToFade;
    private float timeElapsed;
    public float targetVolume;
    private float currentVolume;

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }

    private void Start()
    {
        currentVolume = _audioSource.volume;
    }

    private void FadeAudio()
    {
        StartCoroutine(FadeAudioRoutine());
    }

    private IEnumerator FadeAudioRoutine()
    {
        float tempTimeElapsed = timeElapsed;
        float tempTimeToFade = timeToFade;

        timeElapsed = 0;
        while (tempTimeElapsed < tempTimeToFade)
        {
            _audioSource.volume = Mathf.Lerp(currentVolume, 0, tempTimeElapsed / tempTimeToFade);
            tempTimeElapsed += Time.deltaTime;
            yield return null;
        }
    }
}
