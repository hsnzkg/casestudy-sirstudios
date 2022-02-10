using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PoolManager : MonoBehaviour
{
    private static PoolManager instance;
    public static PoolManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject.FindGameObjectWithTag("Managers").AddComponent<PoolManager>();
            }
            return instance;
        }
    }

    [SerializeField] private Stack<GameObject> objectPool = new Stack<GameObject>();
    [SerializeField] private List<GameObject> activeObjectPool = new List<GameObject>();

    #region OWN METHODS

    private void Init()
    {
        instance = this;
    }

    public void CreatePool(int count, GameObject prefab)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject tempObject = Instantiate(prefab, Vector3.zero, Quaternion.identity, null);
            AddObject(tempObject);
        }
    }

    public GameObject GetObject()
    {
        GameObject tempObject = objectPool.Pop();
        activeObjectPool.Add(tempObject);
        tempObject.SetActive(true);
        return tempObject;
    }

    public Vector3[] GetLastObjectPosition()
    {
        return activeObjectPool.ToArray().Select(go => go.transform.position).ToArray();
    }

    public void AddObject(GameObject obj)
    {
        activeObjectPool.Remove(obj);
        obj.SetActive(false);
        objectPool.Push(obj);
    }

    public bool IsEmpty()
    {
        if (objectPool.Count <= 0)
        {
            return true;
        }
        return false;
    }

    #endregion

    #region UNITY METHODS
    private void Awake()
    {
        Init();
    }
    #endregion
}
