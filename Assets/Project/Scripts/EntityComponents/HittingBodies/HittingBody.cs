using Scripts.EntityComponents.Health;
using UnityEngine;

namespace Scripts.EntityComponents.HittingBodies
{
    /// <summary>
    /// Base class for handling entity contact with other entities
    /// </summary>
    public abstract class HittingBody : MonoBehaviour
    {
        [SerializeField] private LayerMask targetLayerMask;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (targetLayerMask != (targetLayerMask | (1 << other.gameObject.layer))) return;
            
            var health = other.GetComponent<HealthController>();
            Hit(health);
        }

        /// <summary>
        /// Handles contact
        /// </summary>
        /// <param name="healthController"></param>
        protected abstract void Hit(HealthController healthController);
    }
}