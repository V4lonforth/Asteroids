using UnityEngine;

namespace Scripts.EntityComponents.Movement
{
    public interface IMovement
    {
        Vector2 Position { get; }
        Vector2 Velocity { get; }
        float Rotation { get; }
        
        void SetPosition(Vector2 position);
        void Move(Vector2 offset);
        void SetRotation(float rotation);
        void Rotate(float deltaAngle);
        void SetVelocity(Vector2 velocity);
        void Accelerate(Vector2 acceleration);
    }
}