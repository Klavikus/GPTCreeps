using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "CreepStats", menuName = "ScriptableObject/CreepStats")]
    public class CreepStats : ScriptableObject
    {
        [field: SerializeField] public float Health { get; private set; }
        [field: SerializeField] public float AttackDamage { get; private set; }
        [field: SerializeField] public float MoveSpeed { get; private set; }
        [field: SerializeField] public Team Team { get; private set; }
    }
}