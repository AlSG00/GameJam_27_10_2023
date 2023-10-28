using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObjectVisualization : MonoBehaviour
{
    [SerializeField] private Transform _trashBagPivot;
    [SerializeField] private Transform _coffeePivot;
    [SerializeField] private Transform _photocameraPivot;

    private void OnEnable()
    {
        TakeTrashBagScenario.OnGetTrash += SetTrashBag;
    }

    private void OnDisable()
    {
        TakeTrashBagScenario.OnGetTrash -= SetTrashBag;
    }

    private void SetTrashBag(GameObject trashBag)
    {
        trashBag.transform.parent = _trashBagPivot;
        trashBag.transform.localPosition = new Vector3(0f, 0f, 0f);
    }
}
