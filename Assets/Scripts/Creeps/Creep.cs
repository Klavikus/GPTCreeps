using Data;
using UnityEngine;

namespace Creeps
{
    public class Creep : MonoBehaviour
    {
        [SerializeField] private CreepStats _stats;
        [SerializeField] private Transform[] _waypoints;
        [SerializeField] private LayerMask _enemyLayer;
        [SerializeField] public float _attackRange = 5f;
        
        public CreepConfig config;
        
        private Attacker attacker;
        private TargetPointer targetPointer;
        private Damageable damageable;
        
        private int _waypointIndex;

        public Team Team => _stats.Team;
        
        private void Update()
        {
            Move();
            DetectAndAttackEnemies();
        }

        public void Initialize(CreepStats stats, Transform[] waypoints)
        {
            _stats = stats;
            _waypoints = waypoints;

            attacker = GetComponent<Attacker>();
            targetPointer = GetComponent<TargetPointer>();
            damageable = GetComponent<Damageable>();

            // Применение конфигурации
            attacker.attackDamage = config.stats.attackDamage;
            attacker.attackRate = config.stats.attackRate;

            damageable.health = config.stats.health;

            targetPointer.moveSpeed = config.stats.moveSpeed;
            targetPointer.waypoints = ...; // Определите способ
            
            MoveToFirstPoint();
        }

        private void MoveToFirstPoint()
        {
            transform.position = _waypoints[_waypointIndex].transform.position;
        }

        private void Move()
        {
            if (_waypointIndex > _waypoints.Length - 1)
                return;

            transform.position = Vector3.MoveTowards(transform.position, _waypoints[_waypointIndex].transform.position,
                _stats.MoveSpeed * Time.deltaTime);

            if (transform.position == _waypoints[_waypointIndex].transform.position)
                _waypointIndex += 1;
        }

        void DetectAndAttackEnemies()
        {
            Collider[] hitEnemies = Physics.OverlapSphere(transform.position, _attackRange, _enemyLayer);

            foreach (var enemy in hitEnemies)
            {
                Damageable enemyDamageable = enemy.GetComponent<Damageable>();
                if (enemyDamageable != null)
                {
                    attacker.Attack(enemyDamageable);
                    break; // Предполагаем атаку только одного врага для упрощения
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