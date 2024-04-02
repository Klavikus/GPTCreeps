using Creeps;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "CreepConfig", menuName = "Creep/Config")]
    public class CreepConfig : ScriptableObject
    {
        [field: SerializeField] public Creep Prefab { get; private set; }
        [field: SerializeField] public CreepStats Stats { get; private set; }
    }
}