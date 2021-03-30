using Scripts.EntityComponents.LifeCycleControllers;
using UnityEngine;

namespace Scripts.EntityComponents.Movement
{
    /// <summary>
    /// Uses rigidbody to move
    /// </summary>
    public class RigidbodyMovement : MonoBehaviour, IMovement
    {
        public Vector2 Position
        {
            get => _rigidbody2D.position;
            set => _rigidbody2D.position = value;
        }

        public float Rotation
        {
            get => _rotation;
            set
            {
                _rotation = value;
                _rigidbody2D.rotation = value;
            }
        }

        public Vector2 Velocity 
        {
            get => _rigidbody2D.velocity;
            set => _rigidbody2D.velocity = value;
        }

        private float _rotation;

        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            GetComponent<LifeCycleController>().OnSpawn += Spawn;
        }
        
        private void Spawn(LifeCycleController lifeCycleController)
        {
            Velocity = Vector2.zero;
        }

        public void Move(Vector2 offset)
        {
            _rigidbody2D.MovePosition(Position + offset);
        }

        public void Rotate(float deltaAngle)
        {
            _rotation = Rotation - deltaAngle;
            _rigidbody2D.MoveRotation(_rotation);
        }

        public void Accelerate(Vector2 acceleration)
        {
            Velocity += acceleration;
        }
    }
}