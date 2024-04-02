using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "CreepSpawnConfig", menuName = "Creep/SpawnConfig")]
    public class CreepSpawnConfig : ScriptableObject
    {
        public CreepConfig creepConfig;
        public float spawnDelay;
    }
}