using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class TranslateRadioTextScenario : MonoBehaviour, IEvent
{
    public string[] radioTranslationTextSet;
    public AudioSource radioSource;
    public static event System.Action<string[]> OnRadioTranslate;

    public async void DoAction()
    {
        StartScreenEndEvent.OnActivatePlayer?.Invoke(false);

        PlayerTextEvent.OnTextEvent?.Invoke(new string[] { "...не выключается..." });

        await Task.Delay(3000);

        OnRadioTranslate?.Invoke(radioTranslationTextSet);

        await Task.Delay(24000);

        radioSource.enabled = false;
        StartScreenEndEvent.OnActivatePlayer?.Invoke(true);
        GetComponent<ScenarioTrigger>().ActivateTrigger();
    }
}
