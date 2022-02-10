using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Settings", menuName = "Settings/MovementSetting", order = 1)]
public class MovementSettings : ScriptableObject
{
    public float multiplerACC;
    public float multiplerDEC;
    public float maxMultiplerSpeed;
    public float multiplerLerpValue;
    public float movementSpeed;
    public float rotationSpeed;
}
