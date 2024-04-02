using Creeps;
using Data;
using UnityEngine;

namespace Infrastructure
{
    public class GameInitializer : MonoBehaviour
    {
        [SerializeField] private Creep _prefab;
        [SerializeField] private CreepStats _redTeamStats;
        [SerializeField] private CreepStats _blueTeamStats;
        [SerializeField] private Transform[] _redTeamWaypoints;
        [SerializeField] private Transform[] _blueTeamWaypoints;

        private void Awake()
        {
            InstantiateAndInitializeCreep(_prefab, _redTeamStats, _redTeamWaypoints);
            InstantiateAndInitializeCreep(_prefab, _blueTeamStats, _blueTeamWaypoints);
        }

        private void InstantiateAndInitializeCreep(Creep prefab, CreepStats stats, Transform[] waypoints)
        {
            Creep creepInstance = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            creepInstance.Initialize(stats, waypoints);
        }
    }
}