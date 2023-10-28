using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowTrashScenario : MonoBehaviour, IEvent
{
    [SerializeField] private Animator _blackScreenAnimator;
    [SerializeField] private GameObject _trashBag;

    public async void DoAction()
    {
        GetComponent<AudioSource>().Play();
        _blackScreenAnimator.SetBool("FadeOut", true);
        StartScreenEndEvent.OnActivatePlayer?.Invoke(false);
        do
        {
            await System.Threading.Tasks.Task.Delay(300);
        }
        while (_blackScreenAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f);

        await System.Threading.Tasks.Task.Delay(1000);

        _trashBag.SetActive(false);

        //await System.Threading.Tasks.Task.Delay(1000);

        _blackScreenAnimator.SetBool("FadeOut", false);
        do
        {
            await System.Threading.Tasks.Task.Delay(200);
        }
        while (_blackScreenAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f);
        StartScreenEndEvent.OnActivatePlayer?.Invoke(true);
        GetComponent<ScenarioTrigger>().ActivateTrigger();
    }
}
