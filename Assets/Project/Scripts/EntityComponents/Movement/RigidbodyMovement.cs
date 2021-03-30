using UnityEngine;

namespace Scripts.EntityComponents.Movement
{
    public class RigidbodyMovement : MonoBehaviour, IMovement
    {
        [SerializeField] private float drag;

        public Vector2 Position
        {
            get => _position;
            set
            {
                _position = value;
                _rigidbody2D.position = value;
            }
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

        public Vector2 Velocity { get; set; }

        private Vector2 _position;
        private float _rotation;

        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void Move(Vector2 offset)
        {
            _position += offset;
            _rigidbody2D.MovePosition(Position);
        }

        public void Rotate(float deltaAngle)
        {
            Rotation -= deltaAngle;
            _rigidbody2D.MoveRotation(Rotation);
        }

        public void Accelerate(Vector2 acceleration)
        {
            Velocity += acceleration;
        }

        private void Update()
        {
            if (Velocity == Vector2.zero) return;

            Velocity = drag >= 1f ? Vector2.zero : Velocity - Velocity * (drag * Time.deltaTime);
            Move(Velocity * Time.deltaTime);
        }
    }
}