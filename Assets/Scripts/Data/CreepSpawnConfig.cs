using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "CreepSpawnConfig", menuName = "Creep/SpawnConfig")]
    public class CreepSpawnConfig : ScriptableObject
    {
        [field: SerializeField] public CreepConfig CreepConfig { get; private set; }
        [field: SerializeField] public float SpawnDelay { get; private set; }
    }
}