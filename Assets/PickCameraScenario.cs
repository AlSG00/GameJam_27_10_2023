using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickCameraScenario : MonoBehaviour, IEvent
{
    public GameObject cameraModel;
    public GameObject coffeCupModelInHand;
    public GameObject coffeCupModelOnTable;
    public static event System.Action<GameObject> OnGetCamera;

    public async void DoAction()
    {
        var audio = GetComponent<AudioSource>();
        OnGetCamera?.Invoke(cameraModel);
        coffeCupModelInHand.SetActive(false);
        coffeCupModelOnTable.SetActive(true);
        audio.Play();
        do
        {
            await System.Threading.Tasks.Task.Delay(300);
        }
        while (audio.isPlaying);

        GetComponent<ScenarioTrigger>().ActivateTrigger();
    }
}
