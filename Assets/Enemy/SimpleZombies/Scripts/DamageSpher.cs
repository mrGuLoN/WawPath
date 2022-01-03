using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSpher : MonoBehaviour
{
    public float damage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(other);
            other.GetComponent<PlayerInput>().enabled = false;
            other.GetComponent<Animator>().enabled = false;
        }
    }
}
