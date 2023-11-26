using System;
using UnityEngine;

namespace _Project._Scripts.TriggerSystem
{
    public class TriggerEvents : MonoBehaviour
    {
        public Action<Collider> TriggerEnter; 
        private void OnTriggerEnter(Collider other)
        {
            TriggerEnter?.Invoke(other);
        }
    }
}