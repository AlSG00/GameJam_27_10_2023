using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SecondPhoneAnswerScenario : MonoBehaviour, IEvent
{
    [SerializeField] private Light roomLight;
    [SerializeField] private Light phoneLight;
    [SerializeField] private Transform phonePivot;
    [SerializeField] private AudioSource phoneAudioSource;
    [SerializeField] private AudioClip pickPhone;
    [SerializeField] private AudioClip putPhone;
    [SerializeField] private GameObject deadBodyModel;
    [SerializeField] private AudioSource radioEffectAudioSource;
    [SerializeField] private AudioSource musicSource;

    public string[] radioTranslationTextSet;
    public static event System.Action<string[], Transform> OnPhoneCall;

    public async void DoAction()
    {
        StartScreenEndEvent.OnActivatePlayer?.Invoke(false);
        phoneLight.enabled = false;
        PlayerTextEvent.OnTextEvent?.Invoke(new string[] { "..." });
        phoneAudioSource.Stop();
        phoneAudioSource.PlayOneShot(pickPhone);
        do
        {
            await System.Threading.Tasks.Task.Delay(300);
        }
        while (phoneAudioSource.isPlaying);

        await Task.Delay(1000);

        OnPhoneCall?.Invoke(radioTranslationTextSet, phonePivot);
        await Task.Delay(18000);

        PlayerTextEvent.OnTextEvent?.Invoke(new string[] { "...мама...я..." });
        await Task.Delay(12000);

        PlayerTextEvent.OnTextEvent?.Invoke(new string[] { "...что?" });
        await Task.Delay(6000);

        radioEffectAudioSource.enabled = true;

        await Task.Delay(6000);
        musicSource.Play();
        await Task.Delay(3000);
        PlayerTextEvent.OnTextEvent?.Invoke(new string[] { "...что за...алло!?" });
        await Task.Delay(18000);

        await Task.Delay(100);
        roomLight.enabled = false;
        await Task.Delay(100);
        roomLight.enabled = true;
        deadBodyModel.SetActive(true);
        await Task.Delay(3000);
        radioEffectAudioSource.enabled = false;
        phoneAudioSource.PlayOneShot(putPhone);
        do
        {
            await Task.Delay(300);
        }
        while (phoneAudioSource.isPlaying);

        StartScreenEndEvent.OnActivatePlayer?.Invoke(true);
        GetComponent<ScenarioTrigger>().ActivateTrigger();
    }
}
