using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class MovementController : MonoBehaviour
{
    [Header("Multipler Settings")]
    public MovementSettings movementSettings;
    
    private protected float currentMultiplerValue;
    private protected Vector3 lastRotation;
    private protected bool accelerating = false;





    #region OWN METHODS


    public virtual void AccelerateMultipler()
    {
        currentMultiplerValue = Mathf.Clamp(Mathf.Lerp(currentMultiplerValue, currentMultiplerValue + movementSettings.multiplerACC, movementSettings.multiplerLerpValue), 0f, movementSettings.maxMultiplerSpeed);
    }
    public virtual void DeAccelerateMultipler()
    {
        currentMultiplerValue = Mathf.Clamp(Mathf.Lerp(currentMultiplerValue, currentMultiplerValue - movementSettings.multiplerDEC, movementSettings.multiplerLerpValue), 0f, movementSettings.maxMultiplerSpeed);
    }
    #endregion


    #region UNITY METHODS
    #endregion
}
