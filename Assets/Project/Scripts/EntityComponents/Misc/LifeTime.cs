using Scripts.EntityComponents.LifeCycleControllers;
using UnityEngine;

namespace Scripts.EntityComponents.Misc
{
    /// <summary>
    /// Class that destroys itself if lives for too long
    /// </summary>
    public class LifeTime : MonoBehaviour
    {
        [SerializeField] private float timeToRemove;

        private float _remainingTimeToRemove;
        private bool _isRemoved;
        
        private void Start()
        {
            _remainingTimeToRemove = timeToRemove;
        }

        private void Update()
        {
            if (_isRemoved) return;

            _remainingTimeToRemove -= Time.deltaTime;
            if (_remainingTimeToRemove > 0f) return;
            
            _isRemoved = true;
            GetComponent<LifeCycleController>().Destroy();
        }
    }
}