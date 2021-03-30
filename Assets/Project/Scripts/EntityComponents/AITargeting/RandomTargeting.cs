using UnityEngine;

namespace Scripts.EntityComponents.AITargeting
{
    public class RandomTargeting : Targeting
    {
        protected override float GetAttackControllerRotation()
        {
            return Random.Range(0f, 360f);
        }
    }
}