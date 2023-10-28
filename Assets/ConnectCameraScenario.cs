using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectCameraScenario : MonoBehaviour, IEvent
{
    [SerializeField] private GameObject _cameraToPut;
    [SerializeField] private GameObject _cameraInHand;
    [SerializeField] private Light[] _lights;
    [SerializeField] private AudioSource audio;
    [SerializeField] private GameObject screamer;

    public async void DoAction()
    {
        StartScreenEndEvent.OnActivatePlayer?.Invoke(false);
        _cameraToPut.SetActive(true);
        _cameraInHand.SetActive(false);

        await System.Threading.Tasks.Task.Delay(2000);
        foreach (var light in _lights)
        {
            light.enabled = false;
        }

        await System.Threading.Tasks.Task.Delay(1000);
        StartScreenEndEvent.OnActivatePlayer?.Invoke(true);
        audio.Play();
        do
        {
            await System.Threading.Tasks.Task.Delay(300);
        }
        while (audio.isPlaying);

        screamer.SetActive(true);
        GetComponent<ScenarioTrigger>().ActivateTrigger();
    }
}
