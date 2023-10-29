using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeadTalkScenario : MonoBehaviour, IEvent
{
    [SerializeField] private GameObject textPivotSet;
    [SerializeField] private GameObject textMeshSet;
    public async void DoAction()
    {
        textPivotSet.SetActive(true);
        textMeshSet.SetActive(true);
        await System.Threading.Tasks.Task.Delay(3000);

        textPivotSet.SetActive(false);
        textMeshSet.SetActive(false);
        GetComponent<ScenarioTrigger>().ActivateTrigger();
    }
}
