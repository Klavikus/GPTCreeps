using Data;
using UnityEngine;

namespace Creeps
{
    public class Creep : MonoBehaviour
    {
        [SerializeField] private LayerMask _enemyLayer;
        [SerializeField] private float _attackRange = 5f;

        [SerializeField] private Attacker _attacker;
        [SerializeField] private TargetPointer _targetPointer;
        [SerializeField] private Damageable _damageable;

        private int _waypointIndex;

        public Team Team { get; private set; }

        private void Update()
        {
            DetectAndAttackEnemies();
        }

        public void Initialize(CreepStats stats, Transform[] waypoints)
        {
            Team = stats.Team;
            
            _attacker.Initialize(stats.AttackDamage, stats.AttackDelay);
            _damageable.Initialize(stats.MaxHealth);
            _targetPointer.Initialize(stats.MoveSpeed, waypoints);
        }

        private void DetectAndAttackEnemies()
        {
            Collider[] hitEnemies = Physics.OverlapSphere(transform.position, _attackRange, _enemyLayer);

            foreach (var enemy in hitEnemies)
            {
                if (enemy.TryGetComponent(out Damageable damageable))
                {
                    _attacker.Attack(damageable);

                    break;
                }
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _attackRange);
        }
    }
}