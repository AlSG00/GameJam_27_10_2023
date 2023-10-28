using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeTrashBagScenario : MonoBehaviour, IEvent
{
    public GameObject trashBag;
    public static event System.Action<GameObject> OnGetTrash;

    public async void DoAction()
    {
        var audio = GetComponent<AudioSource>();
        audio.Play();
        OnGetTrash?.Invoke(trashBag);
        do
        {
            await System.Threading.Tasks.Task.Delay(300);
        }
        while (audio.isPlaying);
        GetComponent<ScenarioTrigger>().ActivateTrigger();
    }
}
