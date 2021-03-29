using UnityEngine;

namespace Scripts.EntityComponents.Movement
{
    public interface IMovement
    {
        Vector2 Position { get; }
        float Rotation { get; }
        
        void SetPosition(Vector2 position);
        void Move(Vector2 offset);
        void SetRotation(float rotation);
        void Rotate(float deltaAngle);
    }
}