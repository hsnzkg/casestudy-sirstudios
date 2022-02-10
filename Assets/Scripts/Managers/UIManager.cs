using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public GameObject startSection;
    public GameObject inGameSection;
    public GameObject endGameSection;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI endscoreText;


    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject.FindGameObjectWithTag("Managers").AddComponent<UIManager>();
            }
            return instance;
        }
    }
    #region OWN METHODS
    private void Init()
    {
        instance = this;
    }

    public void ShowStartScreen(bool value)
    {
        startSection.SetActive(value);
    }

    public void ShowInGameScreen(bool value)
    {
        inGameSection.SetActive(value);
    }

    public void ShowEndGameScreen(bool value)
    {
        endGameSection.SetActive(value);
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
    private void UpdateScoreText()
    {
        scoreText.text = "SCORE : " + ScoreManager.Instance.GetScore().ToString();
        endscoreText.text = "SCORE : " + ScoreManager.Instance.GetScore().ToString();
    }
    #endregion

    #region UNITY METHODS
    private void Awake()
    {
        Init();
    }

    private void LateUpdate()
    {
        UpdateScoreText();
    }
    #endregion
}
