using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiController : MonoBehaviour
{
    private ZombiMovement _zMove;
    private ZombiAnimation _zAnim;
    private ZombiData _zData;
    private ZombiFindPlayer _zFind;
    private float _speed, _rotation;
    private GameObject _player;
    private bool _dontMove, _inAttack = false;
    void Awake()
    {
        _zMove = GetComponent<ZombiMovement>();
        _zAnim = GetComponent<ZombiAnimation>();
        _zData = GetComponent<ZombiData>();
        _zFind = GetComponent<ZombiFindPlayer>();
        _speed = Random.Range(_zData.minAndMaxSpeed.x, _zData.minAndMaxSpeed.y);
        _rotation = Random.Range(_zData.minAndMaxSpeed.x, _zData.minAndMaxSpeed.y);
        _zAnim.speedAnimation = _speed / 3;
      //  _zFind.FindPlayer(out _player);
        _dontMove = false;
    }

    private void Start()
    {
     
    }
    
    void FixedUpdate()
    {
        if (_dontMove == false)
        {
            _zMove.Rotation(_rotation, _player);
            _zMove.Run(_speed);
        }

        if (_inAttack == false)
        {
            RaycastHit hit;
            if (Physics.Raycast(new Vector3(this.transform.position.x, this.transform.position.y + 0.9f, this.transform.position.z), transform.forward, out hit, 0.5f))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    _zAnim.Attack();
                    _zData.damageSpher.SetActive(true);
                    _dontMove = true;
                    _inAttack = true;
                }
            }
           
        }
    }

    public void EndAttack()
    {
        _dontMove = false;
        _zData.damageSpher.SetActive(false);
        _inAttack = false;       
    }
}
