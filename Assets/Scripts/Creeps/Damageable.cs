using UnityEngine;

namespace Creeps
{
    public class Damageable : MonoBehaviour
    {
        private float _maxHealth;
        private float _currentHealth;

        public void Initialize(float maxHealth)
        {
            _maxHealth = maxHealth;
            _currentHealth = _maxHealth;
        }

        public void TakeDamage(float amount)
        {
            _currentHealth -= amount;

            _currentHealth = Mathf.Max(0, _currentHealth);
            
            Debug.Log($"{name} damaged: {amount}, current health: {_currentHealth}");

            if (_currentHealth == 0)
            {
                Debug.Log($"{name} killed!");
                Destroy(gameObject);
            }
        }
    }
}