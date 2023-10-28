using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepScenario : MonoBehaviour, IEvent
{
    [SerializeField] private Animator _blackScreenAnimator;
    [SerializeField] private Light[] lampsToTurnOff;
    
    public async void DoAction()
    {
        _blackScreenAnimator.SetBool("FadeOut", true);
        StartScreenEndEvent.OnActivatePlayer?.Invoke(false);
        do
        {
            await System.Threading.Tasks.Task.Delay(200);
        }
        while (_blackScreenAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f);

        foreach (var light in lampsToTurnOff)
        {
            light.enabled = false;
        }

        await System.Threading.Tasks.Task.Delay(5000);
        _blackScreenAnimator.SetBool("FadeOut", false);
        do
        {
            await System.Threading.Tasks.Task.Delay(3000);
        }
        while (_blackScreenAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f);
        StartScreenEndEvent.OnActivatePlayer?.Invoke(true);
        GetComponent<ScenarioTrigger>().ActivateTrigger();
    }
}
