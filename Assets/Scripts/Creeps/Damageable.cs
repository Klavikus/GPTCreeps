using UnityEngine;

namespace Creeps
{
    public class Damageable : MonoBehaviour
    {
        public float health = 100f;

        public void TakeDamage(float amount)
        {
            health -= amount;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}