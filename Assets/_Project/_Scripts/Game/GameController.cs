using System;
using _Project._Scripts.Bullet;
using _Project._Scripts.Pools;
using Mirror;
using UnityEngine;

namespace _Project._Scripts.Game
{
    public class GameController : NetworkBehaviour
    {
        public static GameController Instance;
        
        [SerializeField] private Projectile _bulletPrefab;

        private PoolsController _poolsController;
        private BulletController _bulletController;
        private void Awake()
        {
            Instance = this;
        }

        public override void OnStartServer()
        {
            base.OnStartServer();
            
            InitPoolController();
            InitBulletController();
        }

        [Server]
        private void InitBulletController()
        {
            var pool = _poolsController.CreatePool("[BULLETS]",_bulletPrefab);
        }

        [Server]
        private void InitPoolController()
        {
            _poolsController = new PoolsController();
            
        }
    }
}