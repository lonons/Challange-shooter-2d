using System;
using _Project._Scripts.Pools;
using _Project._Scripts.TriggerSystem;
using Mirror;
using UnityEngine;

public class Projectile : PoolableObject
{
    [SerializeField] private TriggerEvents _triggerEvents;
    
    private float _damage;
    private float timer = 0f;
    
    
    private Rigidbody2D _rb;
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

        if (isServer)
        {
            _triggerEvents ??= GetComponentInChildren<TriggerEvents>();
            _triggerEvents.TriggerEnter += OnTriggerEnter;
        }
    }

    [ClientRpc]
    public override void RpcActivate(Vector2 position, float angle)
    {
        gameObject.SetActive(true);
        _rb.position = position;
        _rb.rotation = angle;
        _rb.velocity = Vector2.zero;
        float angleInRadians = Mathf.Deg2Rad * angle;
        Vector2 direction = new Vector2(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians));
        _rb.AddForce(direction*10f, ForceMode2D.Impulse);
    }

    private void OnDestroy()
    {
        if (!isServer) return;
        _triggerEvents.TriggerEnter -= OnTriggerEnter;
    }


    [ClientRpc]
    public override void RpcDeActivate()
    {
        gameObject.SetActive(false);
    }

    [Server]
    private void OnTriggerEnter(Collider other)
    {
        var damagable = other.gameObject.GetComponent<IDamagable>();
        if (damagable!=null) 
           Temp(other.name);
    }

    [ClientRpc]
    private void Temp(string str)
    {
        Debug.Log($"damage {str}");
    }

}
