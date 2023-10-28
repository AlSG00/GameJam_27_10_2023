using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScreamerScenario : MonoBehaviour, IEvent
{
    public GameObject screamer;

    public void DoAction()
    {
        screamer.SetActive(true);
        GetComponent<ScenarioTrigger>().ActivateTrigger();
    }
}
