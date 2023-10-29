using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class showOthersText : MonoBehaviour
{
    public TextMeshProUGUI textMesh;

    [SerializeField] private float lastTextLineTimer = 3f;
    private float hideTextTime;
    Queue<string> textQueue = new Queue<string>();

    private void OnEnable()
    {
        TranslateRadioTextScenario.OnRadioTranslate += EnqueueTextLine;
        SecondPhoneAnswerScenario.OnPhoneCall += SetNewSpeaker;
        ExamineBodyScenario.OnExamineBody += SetNewSpeaker;
    }

    private void OnDisable()
    {
        TranslateRadioTextScenario.OnRadioTranslate -= EnqueueTextLine;
        SecondPhoneAnswerScenario.OnPhoneCall -= SetNewSpeaker;
        ExamineBodyScenario.OnExamineBody -= SetNewSpeaker;
    }

    private void Update()
    {
        if (textQueue.Count != 0)
        {
            if (hideTextTime + lastTextLineTimer < Time.time)
            {
                DequeueTextLine();
            }
        }
        else
        {
            if (hideTextTime + lastTextLineTimer < Time.time)
            {
                textMesh.text = "";
            }
        }
    }

    private void EnqueueTextLine(string[] textSet)
    {
        foreach (string line in textSet)
        {
            textQueue.Enqueue(line);
        }

        if (textQueue.Count == textSet.Length)
        {
            DequeueTextLine();
        }
    }

    private void DequeueTextLine()
    {
        UpdateText(textQueue.Dequeue());
        hideTextTime = Time.time;
    }

    private void UpdateText(string text)
    {
        textMesh.text = text;
    }

    private void SetNewSpeaker(string[] text, Transform speakerPivot)
    {
        GetComponent<SynchronizePosition>().textPivot = speakerPivot;
        EnqueueTextLine(text);
    }
}
