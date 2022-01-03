using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerrMovement : MonoBehaviour
{    
    private CharacterController _characterController;
    

    private void Start()
    {      
        _characterController = GetComponent<CharacterController>();
    }

    public void Movement(float speedMovement, Vector3 _moveDir)
    {        
        _moveDir = this.transform.TransformVector(_moveDir);
        _characterController.Move(new Vector3(_moveDir.x, -10, _moveDir.z) * speedMovement*Time.deltaTime);      
    }

    public void Rotation(float speedRotation, float mouseMovementX)
    {
        this.transform.forward = this.transform.forward + this.transform.right * speedRotation * mouseMovementX * Time.deltaTime;        
    }

}
