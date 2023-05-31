using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{


    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnReload()
    {
        animator.SetTrigger("Reload");
    }
    private void OnFire()
    {
        animator.SetTrigger("Fire");
    }
}
