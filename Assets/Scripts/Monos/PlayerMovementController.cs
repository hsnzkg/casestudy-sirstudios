using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]


public class PlayerMovementController : MovementController
{
    private Rigidbody playerRB;

    #region OWN METHODS
    public void Init()
    {
        playerRB = GetComponent<Rigidbody>();
        lastRotation = playerRB.rotation.eulerAngles;
    }

    private void IgnoreMove()
    {
        playerRB.velocity = new Vector3(0, playerRB.velocity.y, 0);
        playerRB.angularVelocity = Vector3.zero;
    }

    private void Move()
    {
        playerRB.velocity = playerRB.transform.forward.normalized * movementSettings.movementSpeed * currentMultiplerValue * Time.fixedDeltaTime;
    }

    private void Rotate()
    {
        float angle = Mathf.Atan2(InputManager.Instance.GetInput().x, InputManager.Instance.GetInput().z) * Mathf.Rad2Deg;
        Vector3 desiredRotation = new Vector3(0f, angle, 0f);
        if (InputManager.Instance.IsPressing())
        {
            playerRB.rotation = Quaternion.Slerp(playerRB.rotation, Quaternion.Euler(desiredRotation), movementSettings.rotationSpeed * currentMultiplerValue);
        }
        else
        {
            playerRB.rotation = Quaternion.Euler(lastRotation);
        }
        lastRotation = playerRB.rotation.eulerAngles;
    }

    #endregion


    #region UNITY METHODS
    void Awake()
    {
        Init();
    }

    void Update()
    {
        if (InputManager.Instance.IsPressing())
        {
            accelerating = true;
        }
        else
        {
            accelerating = false;
        }
    }

    public Vector3 GetPosition()
    {
        return playerRB.position;
    }

    private void FixedUpdate()
    {
        if (accelerating)
        {
            base.AccelerateMultipler();
        }
        else
        {
            base.DeAccelerateMultipler();
        }
        if (!ScoreManager.Instance.IsWin())
        {
            Move();
            Rotate();
        }
    }
    #endregion
}