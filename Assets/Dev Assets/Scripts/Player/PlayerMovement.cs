using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEditor;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    Vector3 firstTouchDistance;

    [HideInInspector] public bool CanMove = true;

    private void Awake()
    {
        if(instance != null) { Destroy(gameObject); }
        else { instance = this; }
    }

    void Update()
    {
        if(CanMove)
            Movement();
    }

    public void DisablePlayerMovement()
    {
        CanMove = false;
    }

    public void EnablePlayerMovement()
    {
        CanMove = true;
    }

    void TouchAndDragMovement()
    {
        if (MinimalShooting.ControllerPackage.GameControllerSetting.Instance.touchDragController.touchState == MinimalShooting.ControllerPackage.TouchDragController.TouchState.PointerDown)
        {
            Vector3 touchPosition = MinimalShooting.ControllerPackage.GameControllerSetting.Instance.touchDragController.touchPosition;
            Vector3 myPosition = transform.position;
            myPosition.z = 0;

            this.firstTouchDistance = (myPosition - touchPosition);
        }
        else if (MinimalShooting.ControllerPackage.GameControllerSetting.Instance.touchDragController.touchState == MinimalShooting.ControllerPackage.TouchDragController.TouchState.PointerDrag)
        {
            Vector3 input = MinimalShooting.ControllerPackage.GameControllerSetting.Instance.touchDragController.InputVector;
            Vector3 myPosition = transform.position;
            Vector3 newPosition = input + this.firstTouchDistance;

            if (MinimalShooting.ControllerPackage.GameControllerSetting.Instance.onlyXMovement)
            {
                newPosition.y = myPosition.y;
            }
            transform.position = newPosition;
        }
    }

    void Movement()
    {
        TouchAndDragMovement();
        ClampBoundary();
    }

    void ClampBoundary()
    {
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -5.0f, 5.0f);
        pos.y = Mathf.Clamp(pos.y, -9.5f, 9.5f);
        transform.position = pos;
    }
}
