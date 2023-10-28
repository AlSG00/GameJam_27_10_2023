using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextUpdateListener : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerText;
    [SerializeField] TextMeshProUGUI taskText;
    [SerializeField] TextMeshProUGUI clueText;
    Queue<string> speechQueue = new Queue<string>();

    [SerializeField] private float lastTextLineTimer = 4f;
    private float hideTextTime;

    private void OnEnable()
    {
        StartScreenEndEvent.OnTitleFinish += EnqueueTextLine;
        ScenarioTrigger.onPlayerEnter += EnqueueTextLine;
        ScenarioTrigger.onGetNewTask += UpdateTaskText;
        ScenarioTrigger.onGetClue += UpdateClueText;
        PlayerTextEvent.OnTextEvent += EnqueueTextLine;
    }

    private void OnDisable()
    {
        StartScreenEndEvent.OnTitleFinish -= EnqueueTextLine;
        ScenarioTrigger.onPlayerEnter -= EnqueueTextLine;
        ScenarioTrigger.onGetNewTask -= UpdateTaskText;
        ScenarioTrigger.onGetClue -= UpdateClueText;
        PlayerTextEvent.OnTextEvent -= EnqueueTextLine;
    }

    private void Update()
    {
        if (speechQueue.Count != 0)
        {
            if (Input.GetKeyDown(KeyCode.E) ||
                hideTextTime + lastTextLineTimer < Time.time)
            {
                DequeueTextLine();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.E) ||
                hideTextTime + lastTextLineTimer < Time.time)
            {
                playerText.text = "";
            }
        }
    }

    //private void EnqueueTextLine(string text, bool isFirstLineInSet = false)
    //{
    //    speechQueue.Enqueue(new TextLine(text, isFirstLineInSet));

    //    if (isFirstLineInSet)
    //    {
    //        DequeueTextLine();
    //    }
    //}

    private void EnqueueTextLine(string[] textSet)
    {
        foreach (string line in textSet)
        {
            //speechQueue.Enqueue(new TextLine(text, isFirstLineInSet));
            speechQueue.Enqueue(line);

        }

        //if (isFirstLineInSet)
        //{
        //    DequeueTextLine();
        //}

        if (speechQueue.Count == textSet.Length)
        {
            DequeueTextLine();
        }
    }

    private void DequeueTextLine()
    {
        UpdatePlayerText(speechQueue.Dequeue());
        hideTextTime = Time.time;
        //if (speechQueue.Count == 0)
        //{
        //    hideTextTime = Time.time;
        //}

    }

    private void UpdatePlayerText(string text)
    {
        playerText.text = text;
    }

    private void UpdateTaskText(string text)
    {
        taskText.text = text;
    }

    private void UpdateClueText(string text)
    {
        clueText.text = text;
    }

    public class TextLine
    {
        public string Text;
        public bool First;

        public TextLine(string text, bool first)
        {
            Text = text;
            First = first;
        }
    }
}
