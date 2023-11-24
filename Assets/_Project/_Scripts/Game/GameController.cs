using System;
using _Project._Scripts.Pools;
using Mirror;
using UnityEngine;

namespace _Project._Scripts.Game
{
    public class GameController : NetworkBehaviour
    {
        public static GameController Instance;

        private PoolsManager _poolsManager;
        private void Awake()
        {
            Instance = this;
        }
    }
}