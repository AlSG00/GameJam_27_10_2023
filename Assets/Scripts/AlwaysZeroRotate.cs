using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysZeroRotate : MonoBehaviour
{
    private void Update()
    {
        gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }
}
