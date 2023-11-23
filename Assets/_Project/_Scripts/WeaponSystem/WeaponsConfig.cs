using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

namespace _Project._Scripts.WeaponSystem
{
    [Serializable]
    public class WeaponsConfig
    { 
        [Header("Bodys")]
        [SerializeField] private GameObject BodyPistol;
        [SerializeField] private GameObject BodyShotGun;
        [SerializeField] private GameObject BodyRiffle;
        [Space]
        [Header("Weapons")]
        [SerializeField] private Weapon WeaponPistol;
        [SerializeField] private Weapon WeaponShotGun;
        [SerializeField] private Weapon WeaponRiffle;
        [SerializeField] private Weapon WeaponSniper;

        [Space] [Header("Pairs")] [SerializeField]
        private List<WeaponPair> _listPairWeapon;

        public BodysEnum GetBodyOnPairWeapon(WeaponEnum weaponEnum)
        {
            var pair = _listPairWeapon.First(x => x._weaponEnum == weaponEnum);
            return pair._bodyEnum;
        }

        public Weapon GetWeapon(WeaponEnum weaponEnum)
        {
            return weaponEnum switch
            {
                WeaponEnum.Pistol => WeaponPistol,
                WeaponEnum.ShotGun => WeaponShotGun,
                WeaponEnum.Rifle => WeaponRiffle,
                WeaponEnum.Sniper => WeaponSniper,
                _ => throw new ArgumentOutOfRangeException(nameof(weaponEnum), weaponEnum, null)
            };
        }

        public GameObject GetBody(BodysEnum bodyEnum)
        {
            return bodyEnum switch
            {
                BodysEnum.Pistol => BodyPistol,
                BodysEnum.ShotGun => BodyShotGun,
                BodysEnum.Rifle => BodyRiffle,
                _ => throw new ArgumentOutOfRangeException(nameof(bodyEnum), bodyEnum, null)
            };
        }
    }

    [Serializable]
    public class WeaponPair
    {
        public WeaponEnum _weaponEnum;
        public BodysEnum _bodyEnum;
    }
}