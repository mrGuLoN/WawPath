using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject shopOpen;
    [SerializeField] private float distanceBuy;

    private GameObject _player;
    private GameObject _canvas;
    private float xLine, yLine;
    private bool _shopOpen = true;
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _canvas = GameObject.FindGameObjectWithTag("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        xLine = _player.transform.position.x - this.transform.position.x;
        yLine = _player.transform.position.z - this.transform.position.z;        

        if (_shopOpen == true && (xLine*xLine + yLine*yLine) <= distanceBuy*distanceBuy && Input.GetKeyDown(KeyCode.E))
        {
            _canvas.GetComponent<CanvasController>().ShopOpen();
        }
    }

    public void ShopOpen()
    {
        shopOpen.SetActive(true);
        _shopOpen = true;
    }

    public void ShopClose()
    {
        shopOpen.SetActive(false);
        _shopOpen = false;
    }
}
