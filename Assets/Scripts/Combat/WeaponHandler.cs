using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField] GameObject weaponLogic;

    // Called from Animation Event
    public void EnableWeapon()
    {
        weaponLogic.SetActive(true);
    }

    // Called from Animation Event
    public void DisableWeapon()
    {
        weaponLogic.SetActive(false);
    }
}
