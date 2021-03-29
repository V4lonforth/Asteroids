﻿using Scripts.EntityComponents.Weapons;
using UnityEngine;

namespace Scripts.EntityComponents.AttackControllers
{
    public class SalvoAttackController : MonoBehaviour, IAttackController
    {
        [SerializeField] private float cooldown;
        
        private IWeapon[] _weapons;

        private float _remainingCooldown;
        
        private void Awake()
        {
            _weapons = GetComponentsInChildren<IWeapon>();
        }

        private void Update()
        {
            if (_remainingCooldown > 0f)
            {
                _remainingCooldown -= Time.deltaTime;
            }
        }

        public void Attack()
        {
            if (_remainingCooldown > 0f) return;

            _remainingCooldown = cooldown;
            
            foreach (var weapon in _weapons)
            {
                weapon.Fire();
            }
        }
    }
}