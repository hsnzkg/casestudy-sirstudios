using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalManager : MonoBehaviour
{
    public CrystalManagerSettings managerSetting;
    private bool canCreate = true;
    private PlayerMovementController player;

    #region OWN METHODS
    private void Init()
    {
        player = FindObjectOfType<PlayerMovementController>();
        PoolManager.Instance.CreatePool(managerSetting.maxCrystalCount, managerSetting.crystalPrefab);
    }

    private IEnumerator CreateCrystal()
    {
        canCreate = false;

        float xPos = Random.Range(managerSetting.spawnMinXPos, managerSetting.spawnMaxXPos);
        float yPos = Random.Range(managerSetting.spawnMinYPos, managerSetting.spawnMaxYPos);
        float zPos = Random.Range(managerSetting.spawnMinZPos, managerSetting.spawnMaxZPos);

        if (!PoolManager.Instance.IsEmpty())
        {
            float tempTime = Time.time;
            while (!CheckCrystalPosition(PoolManager.Instance.GetLastObjectPosition(), new Vector3(xPos, yPos, zPos)))
            {
                xPos = Random.Range(managerSetting.spawnMinXPos, managerSetting.spawnMaxXPos);
                yPos = Random.Range(managerSetting.spawnMinYPos, managerSetting.spawnMaxYPos);
                zPos = Random.Range(managerSetting.spawnMinZPos, managerSetting.spawnMaxZPos);
                if (Time.time - tempTime > 0.1f)
                {
                    break;
                }
            }
        }

        GameObject tempObject = PoolManager.Instance.GetObject();
        tempObject.transform.position = new Vector3(xPos, yPos, zPos);
        yield return new WaitForSeconds(managerSetting.spawnInterval);
        canCreate = true;
    }

    private bool CheckCrystalPosition(Vector3[] lastPos, Vector3 newPos)
    {
        for (int i = 0; i < lastPos.Length; i++)
        {
            if (Vector3.Distance(lastPos[i], newPos) < 4f || Vector3.Distance(player.GetPosition(), newPos) < 4f)
            {
                return false;
            }
        }
        return true;
    }
    #endregion

    #region UNITY METHODS
    private void Awake()
    {

    }
    private void Start()
    {
        Init();
    }

    private void Update()
    {
        if (canCreate && PoolManager.Instance)
        {
            if (!PoolManager.Instance.IsEmpty())
            {
                StartCoroutine(CreateCrystal());
            }
        }
    }
    #endregion
}
