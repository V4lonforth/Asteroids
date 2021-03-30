﻿using Scripts.Utils;
using UnityEngine;

namespace Scripts.EntityComponents.MovementControllers
{
    public class ForwardLaunchMovementController : MovementController
    {
        [SerializeField] private float speed;

        public override void Launch(Vector2 position, float rotation, Vector2 initialVelocity)
        {
            base.Launch(position, rotation, initialVelocity);
            Movement.Accelerate(MathHelper.DegreeToVector2(rotation) * speed);
        }
    }
}