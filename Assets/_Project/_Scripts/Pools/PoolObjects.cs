using System.Collections.Generic;
using Mirror;
using UnityEngine;

namespace _Project._Scripts.Pools
{
    public class PoolObjects<T> where T : PoolableObject
    {
        private Transform _poolParent;
        
        private T _prefab;
        private Queue<T> _poolQuery;
        
        public PoolObjects(T prefab,Transform poolParent)
        {
            _prefab = prefab;
            _poolParent = poolParent;
            _poolQuery = new Queue<T>();
        }

        [Server]
        private void CreateObject()
        {
            var obj = GameObject.Instantiate(_prefab, _poolParent);
            NetworkServer.Spawn(obj.gameObject);
            obj.gameObject.SetActive(false);
            _poolQuery.Enqueue(obj);
        }
        
        [Server]
        public T TakeObject()
        {
            if (_poolQuery.Count == 0)  CreateObject();
            
            var obj = _poolQuery.Dequeue();
            obj.gameObject.SetActive(true);

            return obj;
        }
        
        [Server]
        public void ReturnObject(T obj)
        {
            obj.gameObject.SetActive(false);
            _poolQuery.Enqueue(obj);
        }
    }
}