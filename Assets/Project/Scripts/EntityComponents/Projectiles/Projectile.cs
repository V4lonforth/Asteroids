using Scripts.EntityComponents.Health;
using UnityEngine;

namespace Scripts.EntityComponents.Projectiles
{
    public abstract class Projectile : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            var health = other.GetComponent<HealthController>();
            Hit(health);
        }

        protected abstract void Hit(HealthController healthController);
    }
}