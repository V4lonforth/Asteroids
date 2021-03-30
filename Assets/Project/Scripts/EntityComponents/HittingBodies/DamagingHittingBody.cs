using Scripts.EntityComponents.Health;
using Scripts.EntityComponents.LifeCycleControllers;
using UnityEngine;

namespace Scripts.EntityComponents.HittingBodies
{
    /// <summary>
    /// Class that damages hit entities and destroys itself
    /// </summary>
    public class DamagingHittingBody : HittingBody
    {
        [SerializeField] private int damage;

        private bool _hasHit;
        
        protected override void Hit(HealthController healthController)
        {
            if (_hasHit) return;

            _hasHit = true;
            healthController.TakeDamage(damage);
            GetComponent<LifeCycleController>().Destroy();
        }
    }
}