using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveApartmentScenario : MonoBehaviour, IEvent
{
    public GameObject screamerFirst;
    public GameObject screamerSecond;
    public Animator screamerAnimator;
    public AudioSource screamerSecondAudioSource;
    public AudioSource musicAudio;
    public Light[] lights;
    public GameObject invisibleWallInRoom;

    public async void DoAction()
    {
        invisibleWallInRoom.SetActive(false);
        StartScreenEndEvent.OnActivatePlayer?.Invoke(false);
        screamerFirst.SetActive(false);
        PlayerTextEvent.OnTextEvent?.Invoke(new string[] {
            "Не открывается...",
            "Не могу открыть чёртову дверь!",
            "Нет..."
        }
        );

        screamerSecond.SetActive(true);

        do
        {
            await System.Threading.Tasks.Task.Delay(300);
        }
        while (screamerAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f);

        screamerSecondAudioSource.Play();
        do
        {
            await System.Threading.Tasks.Task.Delay(300);
        }
        while (screamerSecondAudioSource.isPlaying);
        screamerSecond.SetActive(false);
        musicAudio.Stop();

        foreach (var light in lights)
        {
            light.enabled = true;
        }

        StartScreenEndEvent.OnActivatePlayer?.Invoke(true);
        GetComponent<ScenarioTrigger>().ActivateTrigger();
    }
}
