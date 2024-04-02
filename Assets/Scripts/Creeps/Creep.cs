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

        private int _waypointIndex;

        public Team Team => _stats.Team;
        
        private void Update()
        {
            Move();
            DetectEnemies();
        }

        public void Initialize(CreepStats stats, Transform[] waypoints)
        {
            _stats = stats;
            _waypoints = waypoints;

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

        private void DetectEnemies()
        {
            Collider[] hitEnemies = Physics.OverlapSphere(transform.position, _attackRange, _enemyLayer);

            foreach (Collider enemy in hitEnemies)
            {
                Creep enemyCreep = enemy.GetComponent<Creep>();

                if (enemyCreep != null && enemyCreep.Team != Team)
                {
                    Attack(enemyCreep);

                    break;
                }
            }
        }

        private void Attack(Creep targetCreep)
        {
            Debug.Log($"Attacking {targetCreep.name}");
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, _attackRange);
        }
    }
}