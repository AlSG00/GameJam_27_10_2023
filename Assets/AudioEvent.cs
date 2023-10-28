using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEvent : MonoBehaviour, IEvent
{
    public AudioSource audioSource;

    public async void DoAction()
    {
        audioSource.enabled = true;
        do
        {
            await System.Threading.Tasks.Task.Delay(300);
        }
        while (audioSource.isPlaying);
        GetComponent<ScenarioTrigger>().ActivateTrigger();
    }
}
