using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// bool Fade
public class BackScreenController : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    
    private void OnEnable()
    {
        StartScreenEndEvent.OnTitleScreenFade += FadeOut;
    }

    private void OnDisable()
    {
        StartScreenEndEvent.OnTitleScreenFade -= FadeOut;
    }

    private void Start()
    {
        FadeOut(true);
    }

    private void FadeOut(bool fadeScreen)
    {
        _animator.SetBool("FadeOut", fadeScreen);
    }

}
