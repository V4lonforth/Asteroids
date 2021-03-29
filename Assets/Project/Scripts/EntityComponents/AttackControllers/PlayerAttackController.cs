using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Scripts.EntityComponents.AttackControllers
{
    public class PlayerAttackController : MonoBehaviour
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

        public void OnAttack(InputValue input)
        {
            _isAttacking = input.isPressed;
        }
    }
}