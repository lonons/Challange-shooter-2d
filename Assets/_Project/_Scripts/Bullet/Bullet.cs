using System;
using Mirror;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _damage;

    private Rigidbody2D _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Init()
    {
        _rb.AddForce(Vector2.up,ForceMode2D.Impulse);
    }
}
