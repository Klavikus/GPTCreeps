using UnityEngine;

namespace Creeps
{
    public class TargetPointer : MonoBehaviour
    {
        public Transform[] waypoints;
        private int waypointIndex = 0;
        public float moveSpeed = 5f;

        void Update()
        {
            if (waypointIndex < waypoints.Length)
            {
                Transform targetPoint = waypoints[waypointIndex];
                MoveTowards(targetPoint);

                if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
                {
                    waypointIndex++;
                }
            }
        }

        private void MoveTowards(Transform target)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
    }
}