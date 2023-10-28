using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeTrashBagScenario : MonoBehaviour, IEvent
{
    public static event System.Action<GameObject> OnGetTrash;
    public void DoAction()
    {
        OnGetTrash?.Invoke(gameObject);
    }
}
