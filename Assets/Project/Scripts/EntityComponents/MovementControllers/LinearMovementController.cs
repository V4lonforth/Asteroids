using Scripts.Utils;
using UnityEngine;

namespace Scripts.EntityComponents.MovementControllers
{
    public class LinearMovementController : MovementController
    {
        [SerializeField] private float speed;

        public override void Spawn(Vector2 position, float rotation)
        {
            base.Spawn(position, rotation);
            Velocity = MathHelper.DegreeToVector2(rotation) * speed;
        }
    }
}