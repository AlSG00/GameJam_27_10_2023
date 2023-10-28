using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenScreamerScenario : MonoBehaviour, IEvent
{
    public GameObject screamerObject;

    public void DoAction()
    {
        screamerObject.SetActive(false);
        GetComponent<ScenarioTrigger>().ActivateTrigger();
    }
}
