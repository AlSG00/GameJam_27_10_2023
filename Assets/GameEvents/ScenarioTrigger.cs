using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ScenarioTrigger : MonoBehaviour
{
    public bool keepActiveOnStart;
    [SerializeField] private string _playerTask;
    [SerializeField] private string[] _playerTextSet;
    [SerializeField] private string _playerClue;
    public bool hasAdditionalEvent;
    public GameObject[] nextTrigger;
    public float activationDelay = 0;
    public bool canBeActivated = false;
    public static System.Action<string[]> onPlayerEnter;
    public static System.Action<string> onGetNewTask;
    public static System.Action<string> onGetClue;
    public bool additionalEventFinished;

    public bool enteredTrigger = false;
    public bool activateWithButton = false;
    public bool alreadyActivated = false;
    private void SetEventFinishedFlag()
    {
        additionalEventFinished = true;
    }

    private void Start()
    {
        if (keepActiveOnStart == false)
        {
            gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (activationDelay == 0 && canBeActivated == false)
        {
            canBeActivated = true;
            return;
        }
        else if (activationDelay > 0)
        {
            activationDelay -= Time.deltaTime;
        }

        if (activateWithButton)
        {
            if (enteredTrigger)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Activate();
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") == false || canBeActivated == false)
        {
            return;
        }
        enteredTrigger = true;
        additionalEventFinished = false;

        if (_playerClue != "")
        {
            onGetClue?.Invoke(_playerClue);
        }

        if (activateWithButton == false)
        {
            Activate();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        enteredTrigger = false;
        onGetClue?.Invoke("");
    }

    public void ActivateTrigger()
    {
        if (nextTrigger != null)
        {
            foreach (var trigger in nextTrigger)
            {
                trigger.SetActive(true);
            }
        }

        if (_playerTextSet.Length != 0)
        {
            onPlayerEnter?.Invoke(_playerTextSet);
        }

        if (_playerTask != "")
        {
            onGetNewTask?.Invoke(_playerTask);
        }

        if (_playerClue != "")
        {
            onGetClue?.Invoke("");
            Debug.Log("Clue sended");
        }

        gameObject.SetActive(false);
    }

    private void Activate()
    {
        if (alreadyActivated)
        {
            return;
        }

        alreadyActivated = true;

        onGetClue?.Invoke("");
        if (hasAdditionalEvent)
        {
            GetComponent<IEvent>().DoAction();
        }
        else
        {
            ActivateTrigger();
        }
    }
}
