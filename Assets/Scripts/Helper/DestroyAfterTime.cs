using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float value;
    private void Start()
    {
        Destroy(gameObject, value);
    }
}
