using Scripts.EntityComponents.Health;
using Scripts.EntityComponents.Removers;
using UnityEngine;

namespace Scripts.EntityComponents.HittingBodies
{
    public class DamagingHittingBody : HittingBody
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