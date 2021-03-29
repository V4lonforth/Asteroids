using Scripts.Managers;
using UnityEngine;

namespace Scripts.EntityComponents.Movement
{
    public class ArenaBoundMovement : MonoBehaviour, IMovement
    {
        public Vector2 Position { get; private set; }
        public Vector2 Velocity { get; private set; }
        public float Rotation { get; private set; }
        
        private Rigidbody2D _rigidbody2D;
        
        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void SetPosition(Vector2 position)
        {
            Position = position;
            _rigidbody2D.position = Position;
        }
        
        public void SetRotation(float rotation)
        {
            Rotation = rotation;
            _rigidbody2D.rotation = Rotation;
        }

        public void Move(Vector2 offset)
        {
            Position += offset;
            _rigidbody2D.MovePosition(Position);
            CheckBound();
        }

        public void Rotate(float deltaAngle)
        {
            Rotation -= deltaAngle;
            _rigidbody2D.MoveRotation(Rotation);
        }

        public void SetVelocity(Vector2 velocity)
        {
            Velocity = velocity;
        }

        public void Accelerate(Vector2 acceleration)
        {
            Velocity += acceleration;
        }

        private void Update()
        {
            if (Velocity != Vector2.zero)
            {
                Move(Velocity * Time.deltaTime);
            }
        }

        private void FixedUpdate()
        {
            CheckBound();
        }

        private void CheckBound()
        {
            var arenaArea = GameManager.Instance.ArenaArea;
            var position = Position;
            
            if (position.x < arenaArea.xMin && Velocity.x <= 0f) 
                position.x += arenaArea.width;
            if (position.x > arenaArea.xMax && Velocity.x >= 0f) 
                position.x -= arenaArea.width;

            if (position.y < arenaArea.yMin && Velocity.y <= 0f) 
                position.y += arenaArea.height;
            else if (position.y > arenaArea.yMax && Velocity.y >= 0f)
                position.y -= arenaArea.height;

            if (position != Position)
                SetPosition(position);
        }
    }
}