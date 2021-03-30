using Scripts.EntityComponents.LifeCycleControllers;
using Scripts.Utils;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Scripts.EntityComponents.MovementControllers
{
    /// <summary>
    /// Uses Input System to move
    /// </summary>
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
            GetComponent<LifeCycleController>().OnSpawn += Spawn;
        }

        private void Spawn(LifeCycleController lifeCycleController)
        {
            _rotationVelocity = 0f;
            _isAccelerating = false;
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
        
        /// <summary>
        /// Called by Input System 
        /// </summary>
        private void OnRotate(InputValue input)
        {
            _rotationVelocity = input.Get<float>() * rotationSpeed;
        }
        /// <summary>
        /// Called by Input System 
        /// </summary>
        private void OnAccelerate(InputValue input)
        {
            _isAccelerating = input.isPressed;
            _animator.SetBool(IsAccelerating, _isAccelerating);
        }
    }
}