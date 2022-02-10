using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;

    public static InputManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject.FindGameObjectWithTag("Managers").AddComponent<InputManager>();
            }
            return instance;
        }
    }
    [SerializeField] private VariableJoystick joystick;

    #region OWN METHODS

    private void Init()
    {
        instance = this;
        joystick = FindObjectOfType<VariableJoystick>();
    }

    public Vector3 GetInput()
    {
        if (Application.isEditor)
        {
            return new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        }
        else if (Application.isMobilePlatform)
        {
            return new Vector3(joystick.Horizontal, 0f, joystick.Vertical);
        }
        return Vector3.zero;
    }

    public bool IsPressing()
    {
        if (Application.isEditor)
        {
            return Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0 ? true : false;
        }
        else if (Application.platform == RuntimePlatform.Android)
        {
            return joystick.Horizontal != 0 || joystick.Vertical != 0 ? true : false;
        }
        return false;
    }

    #endregion

    #region UNITY METHODS
    void Awake()
    {
        Init();
    }
    private void Start()
    {
        UIManager.Instance.ShowInGameScreen(false);
    }
    #endregion
}