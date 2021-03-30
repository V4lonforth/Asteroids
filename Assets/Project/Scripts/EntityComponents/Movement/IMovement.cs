using UnityEngine;

namespace Scripts.EntityComponents.Movement
{
    /// <summary>
    /// Class that encapsulates entity movement
    /// </summary>
    public interface IMovement
    {
        Vector2 Position { get; set; }
        Vector2 Velocity { get; set; }
        float Rotation { get; set; }
     
        void Move(Vector2 offset);
        void Rotate(float deltaAngle);
        void Accelerate(Vector2 acceleration);
    }
}