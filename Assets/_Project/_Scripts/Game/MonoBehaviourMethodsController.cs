using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project._Scripts.Game
{
    public class MonoBehaviourMethodsController : MonoBehaviour
    {
        private List<IOnUpdate> _listOnUpdate;

        private void Update()
        {
            if (_listOnUpdate.Count == 0) return;
            foreach (var onupdate in _listOnUpdate)
            {
                onupdate.OnUpdate(Time.deltaTime);
            }
        }
    }
}