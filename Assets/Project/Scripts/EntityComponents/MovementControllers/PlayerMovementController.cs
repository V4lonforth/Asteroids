using Scripts.Utils;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Scripts.EntityComponents.MovementControllers
{
    public class PlayerMovementController : MovementController
    {
        private static readonly int IsAccelerating = Animator.StringToHash("IsAccelerating");
        
        [SerializeField] private float maxSpeed;
        [SerializeField] private float acceleration;

        [SerializeField] private float rotationSpeed;

        private Animator _animator;

        private float _rotationVelocity;
        private bool _isAccelerating;

        protected new void Awake()
        {
            base.Awake();
            _animator = GetComponent<Animator>();
        }
        
        protected void Update()
        {
            Movement.Rotate(_rotationVelocity * Time.deltaTime);
            if (_isAccelerating)
                Movement.Velocity = Accelerate(GetAcceleration() * Time.deltaTime);
        }

        private Vector2 GetAcceleration()
        {
            return MathHelper.DegreeToVector2(Movement.Rotation) * acceleration;
        }
        
        private Vector2 Accelerate(Vector2 currentAcceleration)
        {
            return Vector2.ClampMagnitude(Movement.Velocity + currentAcceleration, maxSpeed);
        }
        
        private void OnRotate(InputValue input)
        {
            _rotationVelocity = input.Get<float>() * rotationSpeed;
        }
        private void OnAccelerate(InputValue input)
        {
            _isAccelerating = input.isPressed;
            _animator.SetBool(IsAccelerating, _isAccelerating);
        }
    }
}