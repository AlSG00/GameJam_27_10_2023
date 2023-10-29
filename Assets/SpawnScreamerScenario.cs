using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScreamerScenario : MonoBehaviour, IEvent
{
    public GameObject screamer;
    public AudioSource musicSource;
    public void DoAction()
    {
        musicSource.Play();
        screamer.SetActive(true);
        GetComponent<ScenarioTrigger>().ActivateTrigger();
    }
}
