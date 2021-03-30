using Scripts.EntityComponents.AttackControllers;
using UnityEngine;

namespace Scripts.EntityComponents.AITargeting
{
    /// <summary>
    /// Base abstract class for aiming attack controller
    /// </summary>
    public abstract class Targeting : MonoBehaviour
    {
        [SerializeField] protected Transform attackControllerTransform;
        private IAttackController _attackController;
        
        protected void Awake()
        {
            _attackController = attackControllerTransform.GetComponent<IAttackController>();
        }
        
        private void Update()
        {
            if (!_attackController.CanAttack) return;
            
            attackControllerTransform.rotation = Quaternion.Euler(0f, 0f, GetAttackControllerRotation());
            _attackController.Attack();
        }

        /// <summary>
        /// Calculates attack controller rotation angle
        /// </summary>
        /// <returns>The angle of attack controller</returns>
        protected abstract float GetAttackControllerRotation();
    }
}