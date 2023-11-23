using System;
using Mirror;
using UnityEngine;


public class ShootManager : NetworkBehaviour
{
    public static ShootManager Instance;

    [SerializeField] private GameObject prefab;
    
    private void Start()
    {
        Instance = this;
    }

    [Command]
    public void CmdCreateBullet(Vector3 position, Quaternion quaternion)
    {
        Debug.Log("Start Create");
        var bullet = GameObject.Instantiate(prefab.gameObject, position, quaternion);
        NetworkServer.Spawn(bullet);
    }
}
