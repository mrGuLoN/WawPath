using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiMovement : MonoBehaviour
{
    private CharacterController _charController;
    private Vector3 _currentDirection;

    private void Start()
    {
        _charController = GetComponent<CharacterController>();
        _currentDirection = this.transform.position;
    }

    public void Rotation(float speedRotation, GameObject player)
    {
        Vector3 _direction = new Vector3(player.transform.position.x, this.transform.position.y, player.transform.position.z) - this.transform.position;
        _currentDirection = Vector3.Lerp(_currentDirection, _direction, speedRotation * Time.deltaTime);
        this.transform.forward = _currentDirection;
    }

    public void Run(float speed)
    {
        _charController.Move(this.transform.forward * speed * Time.deltaTime);
    }


}
