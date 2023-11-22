using UnityEngine;

namespace _Project._Scripts.WeaponSystem
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private float _minWeaponDamage;
        [SerializeField] private float _maxWeaponDamage;
        [SerializeField] private float _magazin;
        [SerializeField] private float _shootDelay;
        [SerializeField] private float _reloadTime;
        [SerializeField] private float _spread;
        
        [SerializeField] private Transform _shootPoint;
        
        
    }
}