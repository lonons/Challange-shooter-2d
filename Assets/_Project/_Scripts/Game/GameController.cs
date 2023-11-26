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
        public MonoBehaviourMethodsController MonoBehaviourMethods { get; private set; }
        public BulletController _bulletController { get; private set; }

        [SerializeField] private Projectile _bulletPrefab;

        private PoolsController _poolsController;
       

        private void Awake()
        {
            Instance = this;
        }

        private void Update()
        {
            if (!isServer) return;
            MonoBehaviourMethods.OnUpdate();
        }

        public override void OnStartServer()
        {
            base.OnStartServer();
            
            MonoBehaviourMethods = new MonoBehaviourMethodsController();
            
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