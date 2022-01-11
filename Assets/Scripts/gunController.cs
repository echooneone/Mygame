using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunController : MonoBehaviour
{
    public Transform weaponHold;
    public Gun startingGun;
    public Gun[] weaponDepot;
    Gun equippedGun;
    int counter = 0;
    void Start()
    {
        if (startingGun != null)
        {
            EquipGun(startingGun);
        }
    }
    public void EquipGun(Gun gunToEquip)
    {
        if(equippedGun!=null)
        {
            Destroy(equippedGun.gameObject);
        }
        equippedGun = Instantiate(gunToEquip, weaponHold.position, weaponHold.rotation) as Gun;
        equippedGun.transform.parent = weaponHold;
    }
    public void Shoot()
    {
        if (equippedGun != null)
        {
            equippedGun.Shoot();
        }
    }
    public void SwitchWeapon()
    {
        counter++;
        if (counter == weaponDepot.Length)
            counter = 0;
        EquipGun(weaponDepot[counter]);
    }

}
