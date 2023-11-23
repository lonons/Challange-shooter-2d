using UnityEngine;

namespace _Project._Scripts.WeaponSystem
{
    [CreateAssetMenu (fileName = "WeaponData", menuName = "Configs/WeaponStats", order = 1)]
    public class WeaponStatsConfig : ScriptableObject
    {
        [SerializeField] private float _minWeaponDamage;
        [SerializeField] private float _maxWeaponDamage;
        [SerializeField] private float _magazin;
        [SerializeField] private float _shootDelay;
        [SerializeField] private float _reloadTime;
        [SerializeField] private float _spread;

    }
}