using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bedroomEscapeScreamerScenario : MonoBehaviour
{
    public GameObject screamerObject;
    public GameObject invisibleWall;

    public void DoAction()
    {
        invisibleWall.SetActive(true);
        //screamerObject.SetActive(false);
        GetComponent<ScenarioTrigger>().ActivateTrigger();
    }
}
