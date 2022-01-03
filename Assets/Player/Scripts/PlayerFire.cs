using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField] private float damage, pellet, scater, speedFire, speedBullet;
    [SerializeField] private Transform firePoint;
    public PollObjects.ObjectInfo.ObjectType bullet;
    public void Fire()
    {
        for (int i = 0; i < pellet; i++)
        {
            float _randHor = Random.Range((-scater - 1) / 180, (scater + 1) / 180);
            float _randVer = Random.Range((-scater / 2 - 1) / 180, (scater / 2 + 1) / 180);
            var bulletNew = PollObjects.Instance.GetObject(bullet);

            bulletNew.transform.position = firePoint.position;
            bulletNew.transform.rotation = firePoint.rotation;
            bulletNew.transform.forward = firePoint.forward + new Vector3(_randHor, _randVer, 0);
            bulletNew.GetComponent<Bullet>().speed = speedBullet;
            bulletNew.GetComponent<Bullet>().damage = damage;
        }
    }
}
