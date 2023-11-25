using System;
using System.Collections.Generic;
using _Project._Scripts.Game;
using _Project._Scripts.Pools;
using Mirror;
using UnityEngine;

namespace _Project._Scripts.Bullet
{
    public class BulletController : NetworkBehaviour, IOnUpdate
    {
        private List<ActiveBullet> _activeBullets;
        private PoolObjects<PoolableObject> _pool; 

        public BulletController(PoolObjects<PoolableObject> pool)
        {
            _activeBullets = new List<ActiveBullet>();
            _pool = pool;
        }
       
        public void OnUpdate(float deltaTime)
        {
            if (_activeBullets.Count == 0) return;
            foreach (var activeBullet in _activeBullets)
            {
                activeBullet.TimerTick(deltaTime);
            }
        }
        [Server]
        public void RequestBullet(Vector2 position,Quaternion quaternion)
        {
            var bullet = _pool.TakeObject();
            bullet.Activate(position,quaternion);
            AddBullet(bullet);
        }

        [Server]
        private void AddBullet(PoolableObject bullet)
        {
            var activeBullet = new ActiveBullet(bullet, 3f);
            activeBullet.TimeLeft += RemoveBullet;
            _activeBullets.Add(activeBullet);
        }

        [Server]
        private void RemoveBullet(ActiveBullet activeBullet)
        {
            activeBullet.TimeLeft -= RemoveBullet;
            _activeBullets.Remove(activeBullet);
            _pool.ReturnObject(activeBullet.Bullet);
        }
    }
}