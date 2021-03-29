using Scripts.EntityComponents.Removers;
using UnityEngine;

namespace Scripts.EntityComponents.Projectiles
{
    public class Bullet : Projectile
    {
        [SerializeField] private int damage;
        
        protected override void Hit(Health.HealthController healthController)
        {
            healthController.TakeDamage(damage);
            GetComponent<Remover>().Remove();
        }
    }
}