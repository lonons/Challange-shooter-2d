using System.Linq;
using _Project._Scripts.Game;
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
        
        public void Fire(float angle)
        {
            CmdCreateBullet(angle);
        }

        [Command]
        private void CmdCreateBullet(float angle)
        {
          GameController.Instance._bulletController.RequestBullet(_shootPoint.position,angle);
        }     
    }
}