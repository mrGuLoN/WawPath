using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private bool player;
    public float health;

    private float _maxHealth;
    private CharacterController _chController;
    private Animator _animator;
    private Rigidbody[] _rb;
    private CapsuleCollider _col;


    // Update is called once per frame
    void Start()
    {
        _animator = GetComponent<Animator>();
        _maxHealth = health;
        _chController = GetComponent<CharacterController>();
        _col = GetComponent<CapsuleCollider>();
        LiveAgain();
    }

    public void LiveAgain()
    {
        _animator.enabled = true;
        _chController.enabled = true;
        _col.enabled = true;
        if (player == true)
        {
            var _controller = GetComponent<PlayerController>();
            _controller.enabled = true;
        }
        else
        {
            var _controller = GetComponent<ZombiController>();
            _controller.enabled = true;
        }

        _rb = GetComponentsInChildren<Rigidbody>();

        for(int i=0; i < _rb.Length; i++)
        {
            _rb[i].useGravity = false;
            _rb[i].isKinematic = true;
        }
    }

    public void EnemyDead()
    {
        var _controller = GetComponent<ZombiController>();
        _controller.enabled = false;
        _chController.enabled = false;
        _animator.enabled = false;
        _col.enabled = false;

        _rb = GetComponentsInChildren<Rigidbody>();

        for (int i = 0; i < _rb.Length; i++)
        {
            _rb[i].useGravity = true;
            _rb[i].isKinematic = false;
        }

    }
}
