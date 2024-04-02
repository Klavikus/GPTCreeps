using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "CreepStats", menuName = "ScriptableObject/CreepStats")]
    public class CreepStats : ScriptableObject
    {
        public float health;
        public float attackDamage;
        public float moveSpeed;
        public Team team;
    }
}