using UnityEngine;

namespace Creeps
{
    public class Attacker : MonoBehaviour
    {
        public float attackDamage = 10f;
        public float attackRate = 1f;
        private float nextAttackTime = 0f;

        public void Attack(Damageable target)
        {
            if (Time.time >= nextAttackTime)
            {
                if (target != null)
                {
                    target.TakeDamage(attackDamage);
                    nextAttackTime = Time.time + 1f / attackRate;
                }
            }
        }
    }
}