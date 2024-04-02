using Creeps;
using Data;
using UnityEngine;

namespace Infrastructure
{
    public class GameInitializer : MonoBehaviour
    {
        [SerializeField] private CreepSpawner _redTeamSpawner;
        [SerializeField] private CreepSpawner _blueTeamSpawner;

        [SerializeField] private CreepSpawnConfig _redTeamSpawnConfig;
        [SerializeField] private CreepSpawnConfig _blueTeamSpawnConfig;

        [SerializeField] private Transform[] _redTeamWaypoints;
        [SerializeField] private Transform[] _blueTeamWaypoints;

        private void Awake()
        {
            _redTeamSpawner.Initialize(_redTeamSpawnConfig, _redTeamWaypoints);
            _blueTeamSpawner.Initialize(_blueTeamSpawnConfig, _blueTeamWaypoints);
        }
    }
}