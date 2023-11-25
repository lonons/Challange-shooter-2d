using Mirror;
using UnityEngine;

namespace _Project._Scripts.Pools
{
    public abstract class PoolableObject : NetworkBehaviour
    {
        public abstract void Activate(Vector2 position, Quaternion quaternion);
    }
}