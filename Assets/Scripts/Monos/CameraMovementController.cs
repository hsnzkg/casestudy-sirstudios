using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementController : MonoBehaviour
{
    public CameraSettings cameraSettings;
    private Transform target;
    #region OWN METHODS
    private void Init()
    {
        target = FindObjectOfType<PlayerMovementController>().transform;
        Rotate();
        Follow();
    }
    private void Follow()
    {
        Vector3 desiredPosition = target.position + cameraSettings.cameraPositionOffset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, cameraSettings.cameraLerpSpeed);
    }

    private void Rotate()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(cameraSettings.cameraRotationOffset), cameraSettings.cameraLerpSpeed);
    }

    private void LateUpdate()
    {
        if (target)
        {
            Follow();
            Rotate();
        }
    }
    #endregion


    #region UNITY METHODS
    private void Awake()
    {
        Init();
    }
    #endregion
}
