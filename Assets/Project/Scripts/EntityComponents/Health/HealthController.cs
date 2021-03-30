using Scripts.EntityComponents.Removers;
using UnityEngine;

namespace Scripts.EntityComponents.Health
{
    public class HealthController : MonoBehaviour
    {
        [SerializeField] private int maxHealth = 1;

        private int _currentHealth;

        private void Awake()
        {
            GetComponent<LifeCycleController>().OnSpawn += Spawn;
        }

        private void Spawn(LifeCycleController lifeCycleController)
        {
            _currentHealth = maxHealth;
        }

        public void TakeDamage(int damage)
        {
            _currentHealth -= damage;

            if (_currentHealth > 0) return;
            
            _currentHealth = 0;
            Die();
        }

        private void Die()
        {
            GetComponent<LifeCycleController>().Destroy();
        }
    }
}