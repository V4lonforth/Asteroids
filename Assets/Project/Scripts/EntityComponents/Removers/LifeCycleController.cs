using System;
using UnityEngine;

namespace Scripts.EntityComponents.Removers
{
    public abstract class LifeCycleController : MonoBehaviour
    {
        public Action<LifeCycleController> OnSpawn { get; set; }
        public Action<LifeCycleController> OnDestroy { get; set; }

        public void Spawn()
        {
            OnSpawn?.Invoke(this);
            HandleSpawn();
        }
        
        public void Destroy()
        {
            OnDestroy?.Invoke(this);
            HandleDestroy();
        }

        protected abstract void HandleSpawn();
        protected abstract void HandleDestroy();
    }
}