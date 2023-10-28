using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneRingScenario : MonoBehaviour, IEvent
{
    public AudioSource phoneAudioSource;
    public Light phoneLamp;
    public void DoAction()
    {
        //phoneAudioSource.Play();
        phoneAudioSource.enabled = true;
        phoneLamp.enabled = true;
        GetComponent<ScenarioTrigger>().ActivateTrigger();
    }
}
