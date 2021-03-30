using Scripts.EntityComponents.Removers;
using UnityEngine;

namespace Scripts.EntityComponents.Movement
{
    public class TransformMovement : MonoBehaviour, IMovement
    {
        [SerializeField] private float drag;
        
        public Vector2 Position
        {
            get => transform.position;
            set => transform.position = value;
        }
        public Vector2 Velocity { get; set; }

        public float Rotation
        {
            get => transform.rotation.eulerAngles.z;
            set => transform.rotation = Quaternion.Euler(0f, 0f, value);
        }

        private void Awake()
        {
            GetComponent<LifeCycleController>().OnSpawn += Spawn;
        }
        
        private void Spawn(LifeCycleController lifeCycleController)
        {
            Velocity = Vector2.zero;
        }
        
        public void Move(Vector2 offset)
        {
            Position += offset;
        }

        public void Rotate(float deltaAngle)
        {
            Rotation += deltaAngle;
        }

        public void Accelerate(Vector2 acceleration)
        {
            Velocity += acceleration;
        }

        private void Update()
        {
            if (Velocity == Vector2.zero) return;
            
            Velocity = drag >= 1f ? Vector2.zero : Velocity - Velocity * (drag * Time.deltaTime);
            Move(Velocity * Time.deltaTime);
        }
    }
}