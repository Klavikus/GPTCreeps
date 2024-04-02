using UnityEngine;

namespace Creeps
{
    public class TargetPointer : MonoBehaviour
    {
        private Transform[] _waypoints;
        private int _waypointIndex;
        private float _moveSpeed;

        private void Update()
        {
            if (_waypointIndex >= _waypoints.Length)
                return;

            Transform targetPoint = _waypoints[_waypointIndex];
            MoveTowards(targetPoint);

            if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
                _waypointIndex++;
        }

        public void Initialize(float moveSpeed, Transform[] waypoints)
        {
            _moveSpeed = moveSpeed;
            _waypoints = waypoints;

            transform.position = _waypoints[_waypointIndex].transform.position;
        }

        private void MoveTowards(Transform target)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, _moveSpeed * Time.deltaTime);
        }
    }
}