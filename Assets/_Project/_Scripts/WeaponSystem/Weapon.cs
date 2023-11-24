using System.Linq;
using _Project._Scripts.Pools;
using Mirror;
using Unity.Mathematics;
using UnityEngine;

namespace _Project._Scripts.WeaponSystem
{
    public class Weapon : NetworkBehaviour
    {
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private WeaponStatsConfig _weaponStats;
        
        public void Fire()
        {
            CmdCreateBullet();
        }

        [Command]
        private void CmdCreateBullet()
        {
          PoolsManager.Instance.GetPool().TakeObject().Init();
        }     
    }
}