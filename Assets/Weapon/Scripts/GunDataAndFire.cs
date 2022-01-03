using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunDataAndFire : MonoBehaviour
{
    public float damage, bulletSpeed, bulletInSec, scater;
    public int pellet, bulletInMagazine, haveBullet, allBullet;
    public Transform gunPoint;
    public bool shotgun;
    public Sprite magazineImage;
    public float costUpgrade;
    public float costAmmo;
    [SerializeField] private AudioSource fireSound;

    public PollObjects.ObjectInfo.ObjectType Type => type;
    [SerializeField] private PollObjects.ObjectInfo.ObjectType type;

    private float _needBullet;

    private void Start()
    {
        haveBullet = bulletInMagazine;
    }

    public void Fire()    
    {
        fireSound.Play();
        
        for (int i = 0; i < pellet; i++)
        {
            float _randHor = Random.Range((-scater - 1) / 180, (scater + 1) / 180);
            float _randVer = Random.Range((-scater / 2 - 1) / 180, (scater / 2 + 1) / 180);
            var bulletFire = PollObjects.Instance.GetObject(type);
            bulletFire.transform.position = gunPoint.position;
            bulletFire.transform.forward = gunPoint.forward + this.transform.TransformVector(new Vector3(_randHor, _randVer, 0));
            bulletFire.GetComponent<Bullet>().speed = bulletSpeed;
            bulletFire.GetComponent<Bullet>().damage = damage;            
        }
    }

    public void ColliderOn()
    {
        GetComponent<BoxCollider>().enabled = true;
    }

    public void ColliderOff()
    {
        GetComponent<BoxCollider>().enabled = false;
    }

    public void Reload()
    {
        _needBullet = bulletInMagazine - haveBullet;

        if(_needBullet >= allBullet)
        {
            haveBullet = allBullet;
            allBullet = 0;
        }
        else
        {
            haveBullet = bulletInMagazine;
            allBullet -= haveBullet;
        }        
    }
}
