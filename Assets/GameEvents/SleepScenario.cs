using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepScenario : MonoBehaviour, IEvent
{
    [SerializeField] private Animator _blackScreenAnimator;
    [SerializeField] private Light[] lampsToTurnOff;
    [SerializeField] private AudioSource[] clocksAudio;
    [SerializeField] private AudioSource[] streetAudio;
    //[SerializeField] private AudioSource SleepAudio;

    public async void DoAction()
    {
        GetComponent<AudioSource>().Play();
        //SleepAudio.PlayOneShot(SleepAudio.clip);
        _blackScreenAnimator.SetBool("FadeOut", true);
        StartScreenEndEvent.OnActivatePlayer?.Invoke(false);
        do
        {
            await System.Threading.Tasks.Task.Delay(300);
        }
        while (_blackScreenAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f);

        foreach (var light in lampsToTurnOff)
        {
            light.enabled = false;
        }

        foreach (var clock in clocksAudio)
        {
            clock.enabled = false;
        }

        foreach (var audio in streetAudio)
        {
            audio.enabled = false;
        }

        await System.Threading.Tasks.Task.Delay(5000);
        _blackScreenAnimator.SetBool("FadeOut", false);
        do
        {
            await System.Threading.Tasks.Task.Delay(1000);
        }
        while (_blackScreenAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f);
        StartScreenEndEvent.OnActivatePlayer?.Invoke(true);
        GetComponent<ScenarioTrigger>().ActivateTrigger();
    }
}
