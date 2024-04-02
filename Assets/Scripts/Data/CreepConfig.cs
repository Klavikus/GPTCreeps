using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "CreepConfig", menuName = "Creep/Config")]
    public class CreepConfig : ScriptableObject
    {
        public GameObject creepPrefab;
        public CreepStats stats;
    }
}