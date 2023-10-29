using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynchronizePosition : MonoBehaviour
{
    public Transform textPivot;
    [SerializeField] RectTransform textRect;

    private void FixedUpdate()
    {
        textRect.position = Camera.main.WorldToScreenPoint(textPivot.position);
    }
}
