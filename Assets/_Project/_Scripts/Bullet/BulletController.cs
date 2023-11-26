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
            GameController.Instance.MonoBehaviourMethods.AddMethod(this);
        }
       
        public void OnUpdate(float deltaTime)
        {
            if (_activeBullets.Count == 0) return;
            var bulletsForDelete = new List<ActiveBullet>(); 
            foreach (var activeBullet in _activeBullets)
            {
                if (activeBullet.Activated)
                    activeBullet.TimerTick(deltaTime);
                else bulletsForDelete.Add(activeBullet);
            }
            
            if (bulletsForDelete.Count == 0) return;
            
            foreach (var activeBullet in bulletsForDelete)
            {
                _activeBullets.Remove(activeBullet);
            }
        }
        [Server]
        public void RequestBullet(Vector2 position,float angle)
        {
            var bullet = _pool.TakeObject();
            bullet.RpcActivate(position,angle);
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
            activeBullet.Bullet.RpcDeActivate();
            activeBullet.Activated = false;
            _pool.ReturnObject(activeBullet.Bullet);
        }
        
    }
}