using UnityEngine;

namespace Creeps
{
    public class Attacker : MonoBehaviour
    {
        private float _attackDamage;
        private float _attackDelay;
        private float _nextAttackTime;

        public void Initialize(float attackDamage, float attackDelay)
        {
            _attackDamage = attackDamage;
            _attackDelay = attackDelay;
        }

        public void Attack(Damageable target)
        {
            if (Time.time < _nextAttackTime || target == null)
                return;

            Debug.Log($"Try {name} attack damage: {_attackDamage} target: {target.name}!");

            target.TakeDamage(_attackDamage);
            
            _nextAttackTime = Time.time + _attackDelay;
        }
    }
}