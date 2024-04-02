using UnityEngine;

namespace Creeps
{
    public class Attacker : MonoBehaviour
    {
        private float _attackDamage;
        private float _attackDelay;
        private float _nextAttackTime;
        
        private float _rayDuration = 0.3f;

        public void Initialize(float attackDamage, float attackDelay)
        {
            _attackDamage = attackDamage;
            _attackDelay = attackDelay;
        }

        public void Attack(Creep target)
        {
            if (Time.time < _nextAttackTime || target == null)
                return;

            Debug.Log($"{name} attack damage: {_attackDamage} target: {target.name}!");
            Debug.DrawLine(transform.position + Vector3.up, target.transform.position + Vector3.up, Color.magenta,
                _rayDuration);

            target.TakeDamage(_attackDamage);

            _nextAttackTime = Time.time + _attackDelay;
        }
    }
}