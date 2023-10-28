using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClueTrigger : MonoBehaviour
{
    public string clueText;
    public TextMeshProUGUI clue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            clue.text = clueText;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        clue.text = clueText;
    }
}
