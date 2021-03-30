using Scripts.EntityComponents.Weapons;
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

        public bool CanAttack => _remainingCooldown <= 0f;

        public void Attack()
        {
            if (!CanAttack) return;

            _remainingCooldown = cooldown;
            
            foreach (var weapon in _weapons)
            {
                weapon.Fire();
            }
        }
    }
}