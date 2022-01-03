using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiData : MonoBehaviour
{
    public Vector2 minAndMaxSpeed;
    public Vector2 minAndMaxRotationSpeed;
    public float damage;
    public Transform player;
    public float speedAnimation;
    public GameObject damageSpher;

    private void Start()
    {
        damageSpher.GetComponent<DamageSpher>().damage = damage;
        damageSpher.SetActive(false);
    }
}
