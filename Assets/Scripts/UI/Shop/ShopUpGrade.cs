using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUpGrade : MonoBehaviour
{
    [SerializeField] private Image weaponImage;   
    [SerializeField] private Text damageCost, speedCost, sizeCost, ammoCost;
    

    private PlayerController player;
    private float _intToFloat;

    private void Start()
    {
        FindPlayer();
        ChoiseUpgradeWeapon();
        UpDateCost();
    }

    public void FindPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>(); ;
    }

    public void ChoiseUpgradeWeapon()
    {
        weaponImage.sprite = player.activeGunData.magazineImage;
    }

    public void UpDateCost()
    {
        damageCost.text = player.activeGunData.costUpgrade + " $";
        speedCost.text = player.activeGunData.costUpgrade + " $";
        sizeCost.text = player.activeGunData.costUpgrade + " $";
        ammoCost.text = player.activeGunData.costAmmo + " $";
    }

    public void UpdateDamage()
    {
        player.activeGunData.damage *= 1.1f;
        player.activeGunData.costUpgrade *= 1.1f;
        UpDateCost();
    }

    public void UpdateSpeed()
    {
        player.activeGunData.bulletInSec *= 1.1f;
        player.NewGunInHand();
        player.activeGunData.costUpgrade *= 1.1f;
        UpDateCost();
    }

    public void UpdateSize()
    {
        _intToFloat = player.activeGunData.bulletInMagazine;
        _intToFloat *= 1.1f;
        player.activeGunData.bulletInMagazine =(int)_intToFloat;
        player.activeGunData.costUpgrade *= 1.1f;
        UpDateCost();
    }

    public void UpdateImage()
    {
        weaponImage.sprite = player.activeGunData.magazineImage;
        UpDateCost();
    }
}
