using UnityEngine;

namespace Scripts.EntityComponents.MovementControllers
{
    public class RandomSpeedLaunchMovementController : MovementController
    {
        [SerializeField] private float minSpeed;
        [SerializeField] private float maxSpeed;

        public override void Launch(Vector2 position, float rotation, Vector2 direction)
        {
            base.Launch(position, rotation, Vector2.zero);
            Movement.Accelerate(direction * Random.Range(minSpeed, maxSpeed));
        }
    }
}