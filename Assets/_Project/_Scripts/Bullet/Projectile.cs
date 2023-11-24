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

    private void Update()
    {
        if (timer >= 2f) ;
        else timer += Time.deltaTime;


    }

    public override void Init()
    {
        timer = 0f;
       // _rb.AddForce(Vector2.up,ForceMode2D.Impulse);
    }
}
