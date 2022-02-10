using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private float requiredScore;
    private float currentScore;
    private static ScoreManager instance;


    public static ScoreManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject.FindGameObjectWithTag("Managers").AddComponent<ScoreManager>();
            }
            return instance;
        }
    }

    #region OWN METHODS
    private void Init()
    {
        instance = this;
    }

    public void IncrementScore(float value)
    {
        currentScore = Mathf.Clamp(currentScore + value, 0f, requiredScore);
    }

    public float GetScore()
    {
        return currentScore;
    }
    public bool IsWin()
    {
        return currentScore == requiredScore ? true : false;
    }
    #endregion

    #region UNITY METHODS
    private void Awake()
    {
        Init();
    }
    #endregion
}
