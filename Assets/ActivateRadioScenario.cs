using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateRadioScenario : MonoBehaviour, IEvent
{
    public AudioSource radioAudio;

    public void DoAction()
    {
        radioAudio.enabled = true;
        GetComponent<ScenarioTrigger>().ActivateTrigger();
    }


}
