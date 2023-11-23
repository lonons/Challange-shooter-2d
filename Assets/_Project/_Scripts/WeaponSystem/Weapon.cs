using System.Linq;
using Mirror;
using Unity.Mathematics;
using UnityEngine;

namespace _Project._Scripts.WeaponSystem
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private WeaponStatsConfig _weaponStats;
        
        
        public void Fire()
        {
            ShootManager.Instance.CmdCreateBullet(_shootPoint.position, quaternion.identity);
        }
    }
}