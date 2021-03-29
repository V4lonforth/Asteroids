using Scripts.EntityComponents.Movement;
using UnityEngine;

namespace Scripts.EntityComponents.MovementControllers
{
    public abstract class MovementController : MonoBehaviour
    {
        protected Vector2 Velocity;
        
        protected IMovement Movement;

        protected void Awake()
        {
            Movement = GetComponent<IMovement>();
        }

        protected void Update()
        {
            Movement.Move(Velocity * Time.deltaTime);
        }

        public virtual void Spawn(Vector2 position, float rotation)
        {
            Movement.SetPosition(position);
            Movement.SetRotation(rotation);
        }
    }
}