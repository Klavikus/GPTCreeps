using Creeps;
using Data;
using UnityEngine;

namespace Infrastructure
{
    public class GameInitializer : MonoBehaviour
    {
        [SerializeField] private CreepConfig _redTeamConfig;
        [SerializeField] private CreepConfig _blueTeamConfig;
        [SerializeField] private Transform[] _redTeamWaypoints;
        [SerializeField] private Transform[] _blueTeamWaypoints;

        private void Awake()
        {
            InstantiateAndInitializeCreep(_redTeamConfig.Prefab, _redTeamConfig.Stats, _redTeamWaypoints);
            InstantiateAndInitializeCreep(_blueTeamConfig.Prefab, _blueTeamConfig.Stats,  _blueTeamWaypoints);
        }

        private void InstantiateAndInitializeCreep(Creep prefab, CreepStats stats, Transform[] waypoints)
        {
            Creep creepInstance = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            creepInstance.Initialize(stats, waypoints);
        }
    }
}