using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{    
    public Vector3 movement;
    public float mouseMovementX;

    void FixedUpdate()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        mouseMovementX = Input.GetAxis("Mouse X");
    }
}
