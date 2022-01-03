using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopBuy : MonoBehaviour
{
    [SerializeField] private GameObject weapon1, weapon2, weapon3;
    [SerializeField] private Image image1, image2, image3;
    [SerializeField] private Text cost1, cost2, cost3;

    private PlayerController player;
    void Start()
    {
        cost1.text = (weapon1.GetComponent<GunDataAndFire>().costUpgrade * 10).ToString();
        cost2.text = (weapon2.GetComponent<GunDataAndFire>().costUpgrade * 10).ToString();
        cost3.text = (weapon3.GetComponent<GunDataAndFire>().costUpgrade * 10).ToString();
        image1.sprite = weapon1.GetComponent<GunDataAndFire>().magazineImage;
        image2.sprite = weapon2.GetComponent<GunDataAndFire>().magazineImage;
        image3.sprite = weapon3.GetComponent<GunDataAndFire>().magazineImage;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    public void Buy1()
    {
        BuyPrefabScript(weapon1);
    }

    public void Buy2()
    {
        BuyPrefabScript(weapon2);
    }

    public void Buy3()
    {
        BuyPrefabScript(weapon3);
    }

    private void BuyPrefabScript(GameObject prefab)
    {
        player.activeGun.transform.SetParent(null);
        player.activeGun.GetComponent<BoxCollider>().enabled = true;
        player.activeGun.GetComponent<Rigidbody>().useGravity = true;

        player.activeGun = Instantiate(prefab, player.gunPointInHand);
        player.activeGun.transform.SetParent(player.gunPointInHand);
        player.activeGun.GetComponent<BoxCollider>().enabled = false;
        player.activeGun.GetComponent<Rigidbody>().useGravity = false;
        player.NewGunInHand();
    }
}
