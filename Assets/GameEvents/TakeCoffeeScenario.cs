using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeCoffeeScenario : MonoBehaviour, IEvent
{
    public GameObject coffeeCup;
    public static event System.Action<GameObject> OnGetCoffee;

    public async void DoAction()
    {
        var audio = GetComponent<AudioSource>();
        audio.Play();
        OnGetCoffee?.Invoke(coffeeCup);
        do
        {
            await System.Threading.Tasks.Task.Delay(300);
        }
        while (audio.isPlaying);
        GetComponent<ScenarioTrigger>().ActivateTrigger();
    }
}
