using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSManager : MonoBehaviour
{
    [SerializeField] private int maxFPS;
    private void Awake()
    {
        Application.targetFrameRate = maxFPS;   
    }
}
