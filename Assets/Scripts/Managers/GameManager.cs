using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject.FindGameObjectWithTag("Managers").AddComponent<GameManager>();
            }
            return instance;
        }
    }
    #region OWN METHODS
    private void Init()
    {
        instance = this;
    }
    #endregion

    #region UNITY METHODS
    private void Awake()
    {
        Init();
    }
    private void LateUpdate()
    {
        if (ScoreManager.Instance.IsWin())
        {
            UIManager.Instance.ShowInGameScreen(false);
            UIManager.Instance.ShowEndGameScreen(true);
        }
    }
    #endregion
}
