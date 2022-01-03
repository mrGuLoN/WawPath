using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    [SerializeField] private AudioSource[] step;

    public void SoundStep()
    {
        var randomSound = Random.Range(0, step.Length);
        step[randomSound].Play();
    }
}
