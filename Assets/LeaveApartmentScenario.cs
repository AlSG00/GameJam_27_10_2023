using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveApartmentScenario : MonoBehaviour, IEvent
{
    public GameObject screamer;
    public Animator screamerAnimator;
    public AudioSource screamerSecondAudioSource;

    public async void DoAction()
    {
        StartScreenEndEvent.OnActivatePlayer?.Invoke(false);

        PlayerTextEvent.OnTextEvent?.Invoke(new string[] {
            "Не открывается...",
            "Не могу открыть чёртову дверь!",
            "Нет..."
        }
        );

        screamer.SetActive(true);

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

        StartScreenEndEvent.OnActivatePlayer?.Invoke(true);
        GetComponent<ScenarioTrigger>().ActivateTrigger();
    }
}
