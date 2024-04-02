using Data;
using UnityEngine;

namespace Creeps
{
    public class Creep : MonoBehaviour
    {
        [SerializeField] private CreepStats _stats;
        [SerializeField] private Transform[] _waypoints;

        private int _waypointIndex;

        public LayerMask enemyLayer; // Используйте LayerMask для определения слоя врагов
        public float attackRange = 5f; // Радиус обнаружения врага
        
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

        void Update()
        {
            Move();
            DetectEnemies();
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
            // Простейшее обнаружение врага в пределах диапазона
            Collider[] hitEnemies = Physics.OverlapSphere(transform.position, attackRange, enemyLayer);

            foreach (var enemy in hitEnemies)
            {
                // Проверяем, соответствует ли team врага
                Creep enemyCreep = enemy.GetComponent<Creep>();
                if (enemyCreep != null && enemyCreep.stats.team != this.stats.team)
                {
                    Attack(enemyCreep);
                    break; // Предполагаем атаку только одного врага для упрощения
                }
            }
        }

        private void Attack(Creep targetCreep)
        {
            // Здесь логика атаки или урон врагу
            Debug.Log($"Attacking {targetCreep.name}");
            // Например, можно вызвать метод получения урона у врага
        }

        // Вспомогательная функция для отображения области обнаружения врагов в редакторе
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, attackRange);
        }
    }
}