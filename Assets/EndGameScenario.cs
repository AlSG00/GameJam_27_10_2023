using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EndGameScenario : MonoBehaviour, IEvent
{
    [SerializeField] private Animator BlackScreenAnimator;
    [SerializeField] private TextMeshProUGUI endText;
    [SerializeField] private AudioSource glitchAudio;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioClip glitchSound;
    [SerializeField] private AudioClip glitchSoundSecond;


    public async void DoAction()
    {
        StartScreenEndEvent.OnActivatePlayer?.Invoke(false);
        glitchAudio.Stop();
        ScenarioTrigger.onGetNewTask?.Invoke("");
        GetComponent<AudioSource>().Play();
        BlackScreenAnimator.SetBool("FadeOut", true);
        do
        {
            await System.Threading.Tasks.Task.Delay(300);
        }
        while (BlackScreenAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f);
        await System.Threading.Tasks.Task.Delay(2000);

        endText.enabled = true;
        glitchAudio.loop = false;
        glitchAudio.PlayOneShot(glitchSound);
        musicSource.Stop();
        //glitchAudio.Play();
        await System.Threading.Tasks.Task.Delay(5000);

        endText.enabled = false;
        glitchAudio.PlayOneShot(glitchSoundSecond);
        await System.Threading.Tasks.Task.Delay(2000);

        Application.Quit();
    }
}
