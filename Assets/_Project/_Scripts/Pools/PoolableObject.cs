using Mirror;
using UnityEngine;

namespace _Project._Scripts.Pools
{
    public abstract class PoolableObject : NetworkBehaviour
    {
        public abstract void RpcActivate(Vector2 position,float angle);
        public abstract void RpcDeActivate();
    }
}