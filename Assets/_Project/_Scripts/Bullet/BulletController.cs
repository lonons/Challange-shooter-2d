using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project._Scripts.Bullet
{
    public class BulletController : MonoBehaviour
    {
        private List<ActiveBullet> _activeBullets;

        private void Awake()
        {
            _activeBullets = new List<ActiveBullet>();
        }

        private void Update()
        {
            if (_activeBullets.Count == 0) return;
            foreach (var activeBullet in _activeBullets)
            {
                activeBullet.TimerTick(Time.deltaTime);
            }
        }

        public void AddBullet(Projectile bullet)
        {
            var activeBullet = new ActiveBullet(bullet, 3f);
            activeBullet.TimeLeft += RemoveBullet;
            _activeBullets.Add(activeBullet);
        }

        private void RemoveBullet(ActiveBullet activeBullet)
        {
            activeBullet.TimeLeft -= RemoveBullet;
            _activeBullets.Remove(activeBullet);
        }
    }
}