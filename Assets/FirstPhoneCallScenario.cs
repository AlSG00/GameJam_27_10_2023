using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPhoneCallScenario : MonoBehaviour, IEvent
{
    [SerializeField] private Light phoneLight;
    [SerializeField] private AudioSource phoneAudioSource;
    [SerializeField] private AudioClip pickPhone;
    [SerializeField] private AudioClip putPhone;
    [SerializeField] private Light[] _lights;
    [SerializeField] private GameObject flashlightModel;
    //[SerializeField] private FlashlightController flashlight;

    public static event Action<bool> OnFlashlightAvailable;

    public async void DoAction()
    {
        phoneLight.enabled = false;
        StartScreenEndEvent.OnActivatePlayer?.Invoke(false);
        phoneAudioSource.enabled = false;
        var audio = GetComponent<AudioSource>();
        audio.PlayOneShot(pickPhone);
        do
        {
            await System.Threading.Tasks.Task.Delay(300);
        }
        while (audio.isPlaying);

        PlayerTextEvent.OnTextEvent?.Invoke(new string[] { "алло?" });

        await System.Threading.Tasks.Task.Delay(2000);

        TurnOffLights();

        await System.Threading.Tasks.Task.Delay(1000);

        audio.PlayOneShot(putPhone);
        do
        {
            await System.Threading.Tasks.Task.Delay(300);
        }
        while (audio.isPlaying);

        flashlightModel.SetActive(false);
        OnFlashlightAvailable?.Invoke(true);
        StartScreenEndEvent.OnActivatePlayer?.Invoke(true);
        GetComponent<ScenarioTrigger>().ActivateTrigger();
    }

    private void TurnOffLights()
    {
        foreach (var light in _lights)
        {
            light.enabled = false;
        }
    }
}
