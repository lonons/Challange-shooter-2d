using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project._Scripts.Game
{
    public class MonoBehaviourMethodsController
    {
        private List<IOnUpdate> _listOnUpdate;

        public MonoBehaviourMethodsController()
        {
            _listOnUpdate = new List<IOnUpdate>();
        }
        public void OnUpdate()
        {
            if (_listOnUpdate.Count == 0) return;
            foreach (var onupdate in _listOnUpdate)
            {
                onupdate.OnUpdate(Time.deltaTime);
            }
        }

        public void AddMethod(IOnUpdate method)
        {
            _listOnUpdate.Add(method);
        }
    }
}