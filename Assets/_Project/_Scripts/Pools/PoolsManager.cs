using System;
using System.Collections.Generic;
using System.Linq;
using Mirror;
using UnityEngine;

namespace _Project._Scripts.Pools
{
    public class PoolsManager 
    {
        [SerializeField] private Projectile _bulletPrefab;
        
        private List<PoolObjects<PoolableObject>> _listPools;
        private Transform _parentPools;
        
        public void PoolsManager()
        {
            _listPools = new List<PoolObjects<PoolableObject>>();
            _parentPools = new GameObject() { name = "[POOLS]" }.transform;
            CreatePool("[BULLETS]", _bulletPrefab);
        }

        private void CreatePool(string name, PoolableObject obj)
        {
            var poolParent = new GameObject() { name = name, transform = { parent = _parentPools } }.transform;
            var pool = new PoolObjects<PoolableObject>(obj,poolParent);
            _listPools.Add(pool);
        }

        public PoolObjects<PoolableObject> GetPool()
        {
            return _listPools.First();
        }
        
    }
}