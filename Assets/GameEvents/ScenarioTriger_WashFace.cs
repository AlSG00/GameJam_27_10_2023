using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenarioTriger_WashFace : MonoBehaviour, IEvent
{
    [SerializeField] Animator _blackScreenAnimator;
    bool canProceed = false;

    public static System.Action<bool> OnPlayerEnter;

    public async void DoAction()
    {
        //OnPlayerEnter?.Invoke(false);
        ////StartCoroutine(WashFace());
        ////while (canProceed == false)
        ////{
        ////    continue;
        ////}

        //OnPlayerEnter?.Invoke(true);
        //GetComponent<ScenarioTrigger>().additionalEventFinished = true;

        _blackScreenAnimator.SetBool("FadeOut", true);
        StartScreenEndEvent.OnActivatePlayer?.Invoke(false);
        do
        {
            await System.Threading.Tasks.Task.Delay(200);
        }
        while (_blackScreenAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f);

        await System.Threading.Tasks.Task.Delay(2000);

        _blackScreenAnimator.SetBool("FadeOut", false);
        do
        {
            await System.Threading.Tasks.Task.Delay(200);
        }
        while (_blackScreenAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f);
        StartScreenEndEvent.OnActivatePlayer?.Invoke(true);
        GetComponent<ScenarioTrigger>().ActivateTrigger();
    }

    private IEnumerator WashFace()
    {
        _blackScreenAnimator.SetBool("FadeOut", true);

        while (_blackScreenAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
        {
            yield return new WaitForFixedUpdate();
        }

        yield return new WaitForSeconds(3);

        _blackScreenAnimator.SetBool("FadeOut", false);

        while (_blackScreenAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
        {
            yield return new WaitForFixedUpdate();
        }
        canProceed = true;
        yield return null;
    }
}
