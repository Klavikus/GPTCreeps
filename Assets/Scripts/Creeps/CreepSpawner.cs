using System.Collections;
using Data;
using UnityEngine;

namespace Creeps
{
    public class CreepSpawner : MonoBehaviour
    {
        private CreepSpawnConfig _spawnConfig;
        private Transform[] _waypoints;

        public void Initialize(CreepSpawnConfig spawnConfig, Transform[] waypoints)
        {
            _spawnConfig = spawnConfig;
            _waypoints = waypoints;

            StartCoroutine(SpawnCreeps());
        }

        private IEnumerator SpawnCreeps()
        {
            if (_spawnConfig == null || _waypoints == null)
                yield break;

            while (true)
            {
                Creep creepInstance =
                    Instantiate(_spawnConfig.CreepConfig.Prefab, transform.position, Quaternion.identity);
                creepInstance.Initialize(_spawnConfig.CreepConfig.Stats, _waypoints);

                yield return new WaitForSeconds(_spawnConfig.SpawnDelay);
            }
        }
    }
}