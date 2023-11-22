using System;

namespace _Project._Scripts.HpSystem
{
    public class HpSystem
    {
        public Action Dead;
        public Action<float,float> HpChanged; 
        
        private bool _isDead = false;
        
        private float _maxHp = 100f;
        private float _currentHp = 100f;
        
        
        public void GetDamage(float damage)
        {
            if (_isDead) return;

            _currentHp -= damage;
            if (_currentHp <= 0)
            {
                _currentHp = 0;
                Dead?.Invoke();
            }
            HpChanged?.Invoke(_maxHp,_currentHp);
        }

        public void TakeHeal(float heal)
        {
            if (_isDead) return;

            _currentHp += heal;

            if (_currentHp >= _maxHp)
                _currentHp = _maxHp;
            
            HpChanged?.Invoke(_maxHp,_currentHp);
        }
    }
}