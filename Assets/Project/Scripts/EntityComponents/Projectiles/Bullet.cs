using Scripts.EntityComponents.Health;
using Scripts.EntityComponents.Removers;
using UnityEngine;

namespace Scripts.EntityComponents.Projectiles
{
    public class Bullet : Projectile
    {
        [SerializeField] private int damage;

        private bool _hasHit;
        
        protected override void Hit(HealthController healthController)
        {
            if (_hasHit) return;

            _hasHit = true;
            healthController.TakeDamage(damage);
            GetComponent<Remover>().Remove();
        }
    }
}