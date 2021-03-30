using Scripts.EntityComponents.Movement;
using UnityEngine;

namespace Scripts.EntityComponents.MovementControllers
{
    public class MovementController : MonoBehaviour
    {
        public IMovement Movement { get; private set; }

        protected void Awake()
        {
            Movement = GetComponent<IMovement>();
        }

        public virtual void Spawn(Vector2 position, float rotation, Vector2 initialVelocity)
        {
            Movement.Position = position;
            Movement.Rotation = rotation;
            Movement.Velocity = initialVelocity;
        }
    }
}