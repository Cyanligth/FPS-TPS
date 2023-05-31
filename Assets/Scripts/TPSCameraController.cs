using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.InputSystem;

public class TPSCameraController : MonoBehaviour
{
    [SerializeField] float mouseSensitive;
    [SerializeField] Transform VCamPos;
    [SerializeField] float lookDistance;
    [SerializeField] Transform aimTarget;
    private Vector2 lookDelta;
    private float xRotate;
    private float yRotate;

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        Vector3 lookPoint = Camera.main.transform.position + Camera.main.transform.forward * lookDistance;
        aimTarget.position = lookPoint;
        lookPoint.y = transform.position.y + 1;
        transform.LookAt(lookPoint);
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
        VCamPos.rotation = Quaternion.Euler(xRotate, yRotate, 0);
    }

    private void OnLook(InputValue input)
    {
        lookDelta = input.Get<Vector2>();
    }
}
