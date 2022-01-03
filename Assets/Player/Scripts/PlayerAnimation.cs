using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{   
    private Animator _animator;
    void Start()
    {       
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void MoveAnimation(Vector3 movement, float mouseMovementX)
    {
        if (movement != Vector3.zero) 
        {
            _animator.SetBool("Stay", false);
            _animator.SetFloat("InputX", movement.x);
            _animator.SetFloat("InputY", movement.z);
        }
        else 
        {
            _animator.SetBool("Stay", true);
            _animator.SetFloat("Mouse X", mouseMovementX*5);
        }
    }

    public void NewGanParametr(float speed)
    {
        _animator.SetFloat("TempFire", speed / 4);
    }

    public void RifleFire()
    {
        _animator.SetTrigger("RifleFire");
    }

    public void ShotGunFire()
    {
        _animator.SetTrigger("ShotGunFire");
    }

    public void Reload()
    {
        _animator.SetTrigger("Reload");
    }

    public void ChangeWeapon()
    {
        _animator.SetTrigger("ChangeWeapon");
    }
}
