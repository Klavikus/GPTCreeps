﻿using UnityEngine;

public class Creep : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _moveSpeed = 5f;

    private int _waypointIndex;

    private void Start()
    {
        MoveToFirstPoint();
    }

    private void Update()
    {
        Move();
    }

    public void SetWaypoints(Transform[] waypoints)
    {
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
            _moveSpeed * Time.deltaTime);

        if (transform.position == _waypoints[_waypointIndex].transform.position)
            _waypointIndex += 1;
    }
}