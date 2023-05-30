using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;

    private CharacterController controller;
    private Vector3 moveDir;
    private float ySpeed = 0;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        controller.Move(transform.forward * moveDir.z * moveSpeed * Time.deltaTime);
        controller.Move(transform.right * moveDir.x * moveSpeed * Time.deltaTime);
    }

    private void OnMove(InputValue input)
    {
        moveDir.x = input.Get<Vector2>().x;
        moveDir.z = input.Get<Vector2>().y;
    }

    private void Jump() 
    {
        ySpeed += Physics.gravity.y * Time.deltaTime;
        if (GroundCheck() && ySpeed < 0)
            ySpeed = 0;
        controller.Move(Vector3.up * ySpeed * Time.deltaTime);
    }
    private void OnJump(InputValue input)
    {
        if(GroundCheck())
            ySpeed = jumpForce;
    }

    private bool GroundCheck()
    {
        RaycastHit hit;
        return Physics.SphereCast(transform.position + Vector3.up * 1 , 0.5f, Vector3.down, out hit, 0.6f);
    }
}
