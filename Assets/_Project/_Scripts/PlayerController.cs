using System;
using _Project._Scripts.HpSystem;
using UnityEngine;
using Mirror;

public class PlayerController : NetworkBehaviour, IDamagable
{

    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _flashLightGO;
    
    private Rigidbody2D _rb;

    public float _speed = 10f;
    private Vector2 input;
    private float angle;
    private HpSystem _hpSystem;
    private Camera _mainCamera;

    private void Start()
    {
        if (!isLocalPlayer)
        {
            _flashLightGO.gameObject.SetActive(false);
            return;
        }

        _rb = GetComponent<Rigidbody2D>();
        _hpSystem = new HpSystem();
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (!isLocalPlayer) return;
        
        Move();
        LookOnMouse();
        FireLogic();
    }
    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + input * _speed / 100);
    }

    private void LateUpdate()
    {
        if (!isLocalPlayer) return;
        
        CameraLogic();
    }

    private void FireLogic()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            SpawnBullet();
        }
    }

    private void CameraLogic()
    {
        var position = _rb.position;
        var newCameraPosition = new Vector3(position.x,position.y,_mainCamera.transform.position.z);
        _mainCamera.transform.position = newCameraPosition;
    }
    

    [Command]
    private void SpawnBullet()
    {
        var bullet = Instantiate(_bullet, _rb.position, Quaternion.AngleAxis(angle,Vector3.forward));
        NetworkServer.Spawn(bullet);
    }

    private void Move()
    {
        input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
    private void LookOnMouse()
    {
        // Получаем позицию мыши в мировых координатах
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Вычисляем вектор направления от персонажа к указателю мыши
        Vector2 lookDirection = mousePosition - _rb.position;

        // Нормализуем вектор направления, чтобы получить единичный вектор
        lookDirection.Normalize();

        // Получаем угол в радианах и конвертируем его в градусы
        angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        // Поворачиваем персонаж в направлении указателя мыши
        _rb.rotation = angle;
    }

    public void GetDamage(float damage) => _hpSystem.GetDamage(damage);
}
