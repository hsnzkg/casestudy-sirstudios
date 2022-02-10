using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Settings", menuName = "Settings/CameraSetting", order = 1)]
public class CameraSettings : ScriptableObject
{
    public float cameraLerpSpeed;
    public Vector3 cameraPositionOffset;
    public Vector3 cameraRotationOffset;
}
