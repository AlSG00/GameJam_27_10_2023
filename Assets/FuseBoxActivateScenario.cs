using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseBoxActivateScenario : MonoBehaviour, IEvent
{
    [SerializeField] private Light[] lights;

    public async void DoAction()
    {
        var audio = GetComponent<AudioSource>();
        audio.Play();
        do
        {
            await System.Threading.Tasks.Task.Delay(300);
        }
        while (audio.isPlaying);

        foreach (var light in lights)
        {
            light.enabled = true;
        }

        GetComponent<ScenarioTrigger>().ActivateTrigger();
    }
}
