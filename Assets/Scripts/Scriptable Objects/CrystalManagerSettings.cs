using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Settings", menuName = "Settings/CrystalManagerSetting", order = 1)]

public class CrystalManagerSettings : ScriptableObject
{
    public int maxCrystalCount;
    public float spawnInterval;
    public GameObject crystalPrefab;

    [Range(-10f, 10f)]
    public float spawnMinXPos;
    [Range(-10f, 10f)]
    public float spawnMaxXPos;
    [Range(-10f, 10f)]
    public float spawnMinYPos;
    [Range(-10f, 10f)]
    public float spawnMaxYPos;
    [Range(-10f, 10f)]
    public float spawnMinZPos;
    [Range(-10f, 10f)]
    public float spawnMaxZPos;
}
