using System.Collections;
using UnityEngine;

public class CreepSpawner : MonoBehaviour
{
    [SerializeField] private Creep _creepPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _spawnDelay = 20f;
    [SerializeField] private Transform[] _waypoints;

    private void Start()
    {
        StartCoroutine(SpawnCreepRoutine());
    }

    private IEnumerator SpawnCreepRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnDelay);

            SpawnCreep();
        }
    }

    private void SpawnCreep()
    {
        Creep creep = Instantiate(_creepPrefab, _spawnPoint.position, _spawnPoint.rotation);
        creep.SetWaypoints(_waypoints);
    }
}