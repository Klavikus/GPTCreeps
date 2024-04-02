using Data;
using UnityEngine;

namespace Creeps
{
    public class Creep : MonoBehaviour
    {
        [SerializeField] private CreepStats _stats;
        [SerializeField] private Transform[] _waypoints;

        private int _waypointIndex;

        private void Update()
        {
            Move();
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
    }
}