using Scripts.Managers;
using Scripts.Utils;
using UnityEngine;

namespace Scripts.EntityComponents.AITargeting
{
    /// <summary>
    /// Targets attack controller at player
    /// </summary>
    public class PlayerTargeting : Targeting
    {
        [SerializeField] private float spread;
        
        protected new void Awake()
        {
            base.Awake();
        }

        protected override float GetAttackControllerRotation()
        {
            return MathHelper.Vector2ToDegree(GameManager.Instance.Player.transform.position - attackControllerTransform.position) + Random.Range(-spread, spread);
        }
    }
}