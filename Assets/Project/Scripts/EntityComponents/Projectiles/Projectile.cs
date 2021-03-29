using Scripts.EntityComponents.Health;
using UnityEngine;

namespace Scripts.EntityComponents.Projectiles
{
    public abstract class Projectile : MonoBehaviour
    {
        [SerializeField] private LayerMask targetLayerMask;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (targetLayerMask != (targetLayerMask | (1 << other.gameObject.layer))) return;
            
            var health = other.GetComponent<HealthController>();
            Hit(health);
        }

        protected abstract void Hit(HealthController healthController);
    }
}