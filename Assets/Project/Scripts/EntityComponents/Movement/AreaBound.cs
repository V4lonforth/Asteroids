using Scripts.Managers;
using UnityEngine;

namespace Scripts.EntityComponents.Movement
{
    /// <summary>
    /// Class that ensures entity doesn't leave the arena
    /// </summary>
    public class AreaBound : MonoBehaviour
    {
        private IMovement _movement;

        private void Awake()
        {
            _movement = GetComponent<IMovement>();
        }

        private void Update()
        {
            CheckBound();
        }

        private void CheckBound()
        {
            var arenaArea = GameManager.Instance.ArenaArea;
            var position = _movement.Position;
            var velocity = _movement.Velocity;
                
            if (position.x < arenaArea.xMin && velocity.x <= 0f)
                position.x += arenaArea.width;
            if (position.x > arenaArea.xMax && velocity.x >= 0f)
                position.x -= arenaArea.width;

            if (position.y < arenaArea.yMin && velocity.y <= 0f)
                position.y += arenaArea.height;
            else if (position.y > arenaArea.yMax && velocity.y >= 0f)
                position.y -= arenaArea.height;

            if (position != _movement.Position)
                _movement.Position = position;
        }
    }
}