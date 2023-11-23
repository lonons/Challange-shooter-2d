using System;
using _Project._Scripts.HpSystem;
using _Project._Scripts.WeaponSystem;
using UnityEngine;
using Mirror;

public class PlayerController : NetworkBehaviour, IDamagable
{
    [SerializeField] private WeaponsConfig _weaponsConfig;
    [SerializeField] private GameObject _flashLightGO;

    private WeaponSystem _weaponSystem;
 
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
        _weaponSystem = new WeaponSystem();
        _weaponSystem.InitFirsteapon(_weaponsConfig.GetWeapon(WeaponEnum.Pistol));
    }

    private void Update()
    {
        if (!isLocalPlayer) return;
        
        Move();
        FireLogic();
    }
    private void FixedUpdate()
    {
        if (!isLocalPlayer) return;
        LookOnMouse();
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
            _weaponSystem.Fire();
        }
    }

    private void CameraLogic()
    {
        var position = _rb.position;
        var newCameraPosition = new Vector3(position.x,position.y,_mainCamera.transform.position.z);
        _mainCamera.transform.position = newCameraPosition;
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
