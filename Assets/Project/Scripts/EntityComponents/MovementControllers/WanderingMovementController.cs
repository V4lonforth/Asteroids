using Scripts.Utils;
using UnityEngine;

namespace Scripts.EntityComponents.MovementControllers
{
    public class WanderingMovementController : MovementController
    {
        [SerializeField] private float minTimeToChangeDirection;
        [SerializeField] private float maxTimeToChangeDirection;

        [SerializeField] private float minSpeed;
        [SerializeField] private float maxSpeed;

        private float _remainingTimeToChangeDirection;
        
        public override void Launch(Vector2 position, float rotation, Vector2 initialVelocity)
        {
            base.Launch(position, rotation, initialVelocity);

            _remainingTimeToChangeDirection = GetRandomTime();
            Movement.Velocity = GetRandomVelocity();
        }

        private void Update()
        {
            _remainingTimeToChangeDirection -= Time.deltaTime;
            if (!(_remainingTimeToChangeDirection <= 0f)) return;
            
            _remainingTimeToChangeDirection += GetRandomTime();
            Movement.Velocity = GetRandomVelocity();
        }

        private Vector2 GetRandomVelocity()
        {
            return MathHelper.DegreeToVector2(Random.Range(0f, 360f)) * Random.Range(minSpeed, maxSpeed);
        }

        private float GetRandomTime()
        {
            return Random.Range(minTimeToChangeDirection, maxTimeToChangeDirection);
        }
    }
}