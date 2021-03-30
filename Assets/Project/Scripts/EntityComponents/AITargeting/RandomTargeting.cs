using UnityEngine;

namespace Scripts.EntityComponents.AITargeting
{
    /// <summary>
    /// Aims attack control in random directions
    /// </summary>
    public class RandomTargeting : Targeting
    {
        protected override float GetAttackControllerRotation()
        {
            return Random.Range(0f, 360f);
        }
    }
}