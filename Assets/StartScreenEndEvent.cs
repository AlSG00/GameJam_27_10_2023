using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenEndEvent : MonoBehaviour
{
    public static event System.Action<string[]> OnTitleFinish;
    public static event System.Action<bool> OnTitleScreenFade;
    public static System.Action<bool> OnActivatePlayer;

    public void TriggerGameStart()
    {
        string[] startSpeech = new string[]
        {
            "��� ������� ������...\n����� [E]",
            "������ ������� ������, ���� ��������.",
            "[W][A][S][D] - �����������\n[Shift] - ���������",
            "[Esc] (������� ������� �������) - ����� �� ����"
        };

        OnTitleFinish?.Invoke(startSpeech);

        OnTitleScreenFade?.Invoke(false);
        OnActivatePlayer?.Invoke(true);
    }
}
