using Scripts.EntityComponents.Movement;
using UnityEngine;

namespace Scripts.EntityComponents.MovementControllers
{
    /// <summary>
    /// Controls how entity moves
    /// </summary>
    public class MovementController : MonoBehaviour
    {
        public IMovement Movement { get; private set; }

        protected void Awake()
        {
            Movement = GetComponent<IMovement>();
        }

        /// <summary>
        /// Set start movement parameters
        /// </summary>
        public virtual void Launch(Vector2 position, float rotation, Vector2 initialVelocity)
        {
            Movement.Position = position;
            Movement.Rotation = rotation;
            Movement.Velocity = initialVelocity;
        }
    }
}