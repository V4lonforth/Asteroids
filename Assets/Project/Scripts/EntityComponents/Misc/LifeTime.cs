using System;
using Scripts.EntityComponents.Removers;
using UnityEngine;

namespace Scripts.EntityComponents.Misc
{
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
            GetComponent<Remover>().Remove();
        }
    }
}