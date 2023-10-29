using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRingScenario : MonoBehaviour, IEvent
{
    [SerializeField] private AudioSource _doorRingAudioSource;
    public async void DoAction()
    {
        _doorRingAudioSource.Play();
        do
        {
            await System.Threading.Tasks.Task.Delay(300);
        }
        while (_doorRingAudioSource.isPlaying);

        GetComponent<ScenarioTrigger>().ActivateTrigger();
    }
}
