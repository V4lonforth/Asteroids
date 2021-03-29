using Scripts.Utils;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Scripts.EntityComponents.MovementControllers
{
    public class PlayerMovementController : MovementController
    {
        [SerializeField] private float maxSpeed;
        [SerializeField] private float acceleration;
        [SerializeField] private float drag;

        [SerializeField] private float rotationSpeed;

        private float _rotationVelocity;
        private bool _isAccelerating;

        protected void Update()
        {
            Movement.Rotate(_rotationVelocity * Time.deltaTime);
            Movement.SetVelocity(Accelerate(GetAcceleration() * Time.deltaTime));
        }

        private Vector2 GetAcceleration()
        {
            return _isAccelerating
                ? MathHelper.DegreeToVector2(Movement.Rotation) * acceleration
                : -Movement.Velocity * drag;
        }
        
        private Vector2 Accelerate(Vector2 currentAcceleration)
        {
            return Vector2.ClampMagnitude(Movement.Velocity + currentAcceleration, maxSpeed);
        }
        
        public void OnRotate(InputValue input)
        {
            _rotationVelocity = input.Get<float>() * rotationSpeed;
        }
        public void OnAccelerate(InputValue input)
        {
            _isAccelerating = input.isPressed;
        }
    }
}