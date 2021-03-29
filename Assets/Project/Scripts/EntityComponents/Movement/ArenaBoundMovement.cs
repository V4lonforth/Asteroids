using Scripts.Managers;
using UnityEngine;

namespace Scripts.EntityComponents.Movement
{
    public class ArenaBoundMovement : MonoBehaviour, IMovement
    {
        public Vector2 Position { get; private set; }
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
            var boundPosition = CheckBound(Position);
            
            if (boundPosition == Position)
                _rigidbody2D.MovePosition(Position);
            else
                SetPosition(boundPosition);
        }

        public void Rotate(float deltaAngle)
        {
            Rotation -= deltaAngle;
            _rigidbody2D.MoveRotation(Rotation);
        }

        private static Vector2 CheckBound(Vector2 position)
        {
            var arenaArea = GameManager.Instance.ArenaArea;

            if (position.x < arenaArea.xMin) 
                position.x += arenaArea.width;
            else if (position.x > arenaArea.xMax) 
                position.x -= arenaArea.width;

            if (position.y < arenaArea.yMin) 
                position.y += arenaArea.height;
            else if (position.y > arenaArea.yMax) 
                position.y -= arenaArea.height;

            return position;
        }
    }
}