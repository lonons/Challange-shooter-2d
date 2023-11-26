using System.Collections;
using System.Collections.Generic;
using _Project._Scripts.WeaponSystem;
using UnityEngine;

public class WeaponSystem
{

    private Weapon _currentWeapon;

    public void InitFirsteapon(Weapon weapon)
    {
        _currentWeapon = weapon;
    }
    
    public void ChangeWeapon()
    {
       
    }
    public void Fire(float angle)
    {
        _currentWeapon.Fire(angle);
    }
    
}
