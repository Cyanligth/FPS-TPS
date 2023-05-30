using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FPSCameraController : MonoBehaviour
{
    [SerializeField] Transform CameraPos;
    [SerializeField] float mouseSensitive;
    private Vector2 lookDelta;
    private float xRotate;
    private float yRotate;

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void LateUpdate()
    {
        Look();
    }

    private void Look()
    {
        yRotate += lookDelta.x * mouseSensitive * Time.deltaTime;
        xRotate -= lookDelta.y * mouseSensitive * Time.deltaTime;
        xRotate = Mathf.Clamp(xRotate, -80f, 80f);
        CameraPos.localRotation = Quaternion.Euler(xRotate, 0, 0); 
        transform.localRotation = Quaternion.Euler(0, yRotate, 0);
    }

    private void OnLook(InputValue input)
    {
        lookDelta = input.Get<Vector2>();
    }
}
