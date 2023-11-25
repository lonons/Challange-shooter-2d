using System;
using _Project._Scripts.Pools;
using Mirror;
using UnityEngine;

public class Projectile : PoolableObject
{
    private float _damage;
    private float timer = 0f;
    
    private Rigidbody2D _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    [ClientRpc]
    public override void Activate(Vector2 position, Quaternion quaternion)
    {
        _rb.position = position;
        _rb.transform.rotation = quaternion;
    }
}
