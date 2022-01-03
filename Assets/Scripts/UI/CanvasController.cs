using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public GameObject shopCanvas;

    private GameObject _player;
    void Start()
    {
        shopCanvas.SetActive(false);
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShopOpen()
    {
        shopCanvas.SetActive(true);
        shopCanvas.GetComponent<ShopUpGrade>().UpdateImage();
        _player.GetComponent<PlayerController>().enabled = false;
    }

    public void ShopClose()
    {
        shopCanvas.SetActive(false);
        _player.GetComponent<PlayerController>().enabled = true;
    }
}
