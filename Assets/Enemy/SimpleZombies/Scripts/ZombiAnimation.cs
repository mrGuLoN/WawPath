using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiAnimation : MonoBehaviour
{
    public float speedAnimation;
    private Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetFloat("SpeedAnimation", speedAnimation);
    }

    public void Run()
    {
        _animator.SetBool("Run", true);
    }

    public void Attack()
    {
        _animator.SetTrigger("Attack");
    }
    public void StopRun()
    {
        _animator.SetBool("Run", false);
    }
}
