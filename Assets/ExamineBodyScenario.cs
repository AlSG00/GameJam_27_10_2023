using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
public class ExamineBodyScenario : MonoBehaviour, IEvent
{
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioClip secondMusic;

    [SerializeField] private Light _roomLight;
    [SerializeField] private Light[] _apartmentLight;
    [SerializeField] private GameObject _mainVictim;
    [SerializeField] private Transform _mainVictimTextPivot;
    [SerializeField] private GameObject _firstVictimGroup;
    [SerializeField] private GameObject _secondVictimGroup;
    [SerializeField] private GameObject _thirdVictimGroup;
    [SerializeField] private GameObject _fourthVictimGroup;

    [SerializeField] private string[] _finalDialogue;
    [SerializeField] private GameObject _hellLight;

    public static event System.Action<string[], Transform> OnExamineBody;
    public static event System.Action<string[], Transform> OnMuteAudio;

    public async void DoAction()
    {
        StartScreenEndEvent.OnActivatePlayer?.Invoke(false);


        PlayerTextEvent.OnTextEvent?.Invoke(new string[] {
            "...это... ...я?"
        });

        //
        await Task.Delay(4000);

        _roomLight.enabled = false;
        await Task.Delay(50);
        _mainVictim.SetActive(true);
        await Task.Delay(50);
        _roomLight.enabled = true;

        OnExamineBody?.Invoke(_finalDialogue, _mainVictimTextPivot);
        await Task.Delay(18000); // to 6th line

        _roomLight.enabled = false;
        await Task.Delay(50);
        _firstVictimGroup.SetActive(true);
        await Task.Delay(50);
        //_musicSource.enabled = true;
        //_musicSource.Play();
        _roomLight.enabled = true;
        
        await Task.Delay(2900); // 7th

        _roomLight.enabled = false;
        await Task.Delay(50);
        _secondVictimGroup.SetActive(true);
        await Task.Delay(50);
        _roomLight.enabled = true;
        await Task.Delay(2900); // 8th

        _roomLight.enabled = false;
        await Task.Delay(50);
        _thirdVictimGroup.SetActive(true);
        await Task.Delay(50);
        _roomLight.enabled = true;
        await Task.Delay(2900); // 9th

        await Task.Delay(24000);
        _musicSource.Stop();

        foreach (var light in _apartmentLight)
        {
            light.enabled = false;
        }
        _roomLight.enabled = false;
        _firstVictimGroup.SetActive(false);
        _secondVictimGroup.SetActive(false);
        _thirdVictimGroup.SetActive(false);
        _fourthVictimGroup.SetActive(true);
        await Task.Delay(3000);
        _hellLight.SetActive(true);
        _musicSource.clip = secondMusic;
        _musicSource.Play();
        await Task.Delay(15000);
        _mainVictim.SetActive(false);
        StartScreenEndEvent.OnActivatePlayer?.Invoke(true);
        GetComponent<ScenarioTrigger>().ActivateTrigger();
    }
}
