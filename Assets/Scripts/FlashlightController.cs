using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    [SerializeField] Light flashlightSource;
    [SerializeField] GameObject flashlightModel;
    [SerializeField] AudioSource flashlightAudioSource;
    [SerializeField] AudioClip  TurnOnAudio;
    [SerializeField] AudioClip TurnOffAudio;
    private bool _isActive;
    private bool isAvailable = false;

    // ����� ����� �������� �� ������, ����� ��������� ���� ��������� ��� ��������� ���
    private void OnEnable()
    {
        FirstPhoneCallScenario.OnFlashlightAvailable += SetAvailable;
    }

    private void OnDisable()
    {
        FirstPhoneCallScenario.OnFlashlightAvailable -= SetAvailable;
    }

    private void SetAvailable(bool available)
    {
        isAvailable = available;
    }

    // Start is called before the first frame update
    void Start()
    {
        _isActive = false;
        SetFlahslightState(_isActive);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            HandleFlashlightState();
        }
    }

    private void HandleFlashlightState()
    {
        if (isAvailable == false)
        {
            return;
        }

        if (_isActive == false)
        {
            _isActive = true;
            flashlightAudioSource.PlayOneShot(TurnOnAudio);
        }
        else
        {
            _isActive = false;
            flashlightAudioSource.PlayOneShot(TurnOffAudio);
        }

        SetFlahslightState(_isActive);
    }

    private void SetFlahslightState(bool isActive)
    {
        _isActive = isActive;
        flashlightModel.SetActive(isActive);
        //flashlightSource.enabled = isActive;
    }
}
