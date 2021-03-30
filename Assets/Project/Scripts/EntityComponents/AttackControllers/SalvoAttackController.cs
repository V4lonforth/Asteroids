using Scripts.EntityComponents.Weapons;
using UnityEngine;

namespace Scripts.EntityComponents.AttackControllers
{
    /// <summary>
    /// Attack controller that fires every weapon at the same time
    /// </summary>
    public class SalvoAttackController : MonoBehaviour, IAttackController
    {
        /// <summary>
        /// Can attack if not on cooldown
        /// </summary>
        public bool CanAttack => _remainingCooldown <= 0f;
        
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

        /// <summary>
        /// Attack with all weapons if able to
        /// </summary>
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