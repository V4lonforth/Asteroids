using UnityEngine;
using UnityEngine.InputSystem;

namespace Scripts.EntityComponents.AttackControllers
{
    /// <summary>
    /// Class for handling player attack input
    /// </summary>
    public class PlayerAttackInputHandler : MonoBehaviour
    {
        private bool _isAttacking;
        private IAttackController _attackController;

        private void Awake()
        {
            _attackController = GetComponent<IAttackController>();
        }

        private void Update()
        {
            if (_isAttacking)
                _attackController.Attack();
        }

        /// <summary>
        /// Called by Input System when attack button pressed
        /// </summary>
        public void OnAttack(InputValue input)
        {
            _isAttacking = input.isPressed;
        }
    }
}