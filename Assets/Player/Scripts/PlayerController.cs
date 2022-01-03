using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speedMovement, speedRotation;
    public GameObject gunInHand;
    public GameObject secondGan;
    public GameObject activeGun;
    public GameObject nonActiveGun;
    public GunDataAndFire activeGunData;
    public Transform gunPointInHand, gunPointSecondGun;


    private Vector3 _movement;
    private float _mouseMovementX;
    private PlayerAnimation _plAnimation;
    private PlayerFire _plFire;
    private PlayerrMovement _plMovement;
    private PlayerSound _plSound;
    private bool _onFire;
    private Animator _ani;
    private GameObject _gunTemp;



    void Start()
    {
        _plAnimation = GetComponent<PlayerAnimation>();
        _plFire = GetComponent<PlayerFire>();
        _plMovement = GetComponent<PlayerrMovement>();
        _plSound = GetComponent<PlayerSound>();
        _onFire = false;
        _ani = GetComponent<Animator>();
        activeGun = Instantiate(gunInHand, gunPointInHand);
        nonActiveGun = Instantiate(secondGan, gunPointSecondGun);
        NewGunInHand();
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && _onFire == false)
        {
            if (activeGunData.shotgun == false)
            {
                if (activeGunData.haveBullet > 0)
                {
                    _plAnimation.RifleFire();
                    activeGunData.haveBullet--;
                }
                else if (activeGunData.allBullet > 0)
                {
                    _plAnimation.Reload();
                    _onFire = true;
                }
            }
            else
            {
                if (activeGunData.haveBullet > 0)
                {
                    _plAnimation.ShotGunFire();
                    activeGunData.haveBullet--;
                }
                else if (activeGunData.allBullet > 0)
                {
                    _plAnimation.Reload();
                    _onFire = true;
                }
            }
            _onFire = true;
        }
        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            _plAnimation.ChangeWeapon();
            activeGunData.enabled = false;
            _onFire = true;
        }
    }

    private void FixedUpdate()
    {
        _movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _mouseMovementX = Input.GetAxis("Mouse X");

        if (_movement != Vector3.zero)
        {
            _plMovement.Movement(speedMovement, _movement);
        }
        if (_mouseMovementX != 0)
        {
            _plMovement.Rotation(speedRotation, _mouseMovementX);
        }

        _plAnimation.MoveAnimation(_movement, _mouseMovementX);
    }
    #region GunController
    public void NewGunInHand()
    {
        _plAnimation.NewGanParametr(activeGun.GetComponent<GunDataAndFire>().bulletInSec);
        activeGunData = activeGun.GetComponent<GunDataAndFire>();
        activeGunData.enabled = true;
        activeGunData.ColliderOff();
        nonActiveGun.GetComponent<BoxCollider>().enabled = false;
        EndFire();
    }

    public void InstantiateBullet()
    {
        activeGunData.Fire();        
    }

    public void EndFire()
    {
        _onFire = false;
    }

    public void ReloadEndWeapon()
    {
        activeGunData.Reload();
        _onFire = false;
    }

    private void ChangeWEaponGameObject()
    {
        _gunTemp = activeGun;
        activeGun = nonActiveGun;
        nonActiveGun = _gunTemp;
        activeGun.transform.position = gunPointInHand.position;
        activeGun.transform.rotation = gunPointInHand.rotation;
        nonActiveGun.transform.position = gunPointSecondGun.position;
        nonActiveGun.transform.rotation = gunPointSecondGun.rotation;
        activeGun.transform.SetParent(gunPointInHand);
        nonActiveGun.transform.SetParent(gunPointSecondGun);
        NewGunInHand();
    }
    #endregion

    public void StepSound()
    {
        _plSound.SoundStep();
    }
}

   
