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
        public BulletController _bulletController { get; private set; }

        [SerializeField] private Projectile _bulletPrefab;

        private PoolsController _poolsController;
        private void Awake()
        {
            Instance = this;
        }

        private void Update()
        {
            
        }

        public override void OnStartServer()
        {
            base.OnStartServer();
            
            InitPoolController();
            InitBulletController();
        }
        [Server]
        private void InitPoolController()
        {
            _poolsController = new PoolsController();
            
        }
        [Server]
        private void InitBulletController()
        {
            var pool = _poolsController.CreatePool("[BULLETS]",_bulletPrefab);
            _bulletController = new BulletController(pool);
        }

    }
}