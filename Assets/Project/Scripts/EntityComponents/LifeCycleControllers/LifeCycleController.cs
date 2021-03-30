using System;
using UnityEngine;

namespace Scripts.EntityComponents.LifeCycleControllers
{
    /// <summary>
    /// Base class controlling entity life cycle
    /// Handles how entity is spawned and destroyed
    /// </summary>
    public abstract class LifeCycleController : MonoBehaviour
    {
        /// <summary>
        /// Notifies listeners when entity is spawned
        /// </summary>
        public Action<LifeCycleController> OnSpawn { get; set; }
        /// <summary>
        /// Notifies listeners when entity is destroyed
        /// </summary>
        public Action<LifeCycleController> OnDestroy { get; set; }

        /// <summary>
        /// Handles entity setup
        /// </summary>
        public void Spawn()
        {
            OnSpawn?.Invoke(this);
            HandleSpawn();
        }
        
        /// <summary>
        /// Handles entity destroy
        /// </summary>
        public void Destroy()
        {
            OnDestroy?.Invoke(this);
            HandleDestroy();
        }

        protected abstract void HandleSpawn();
        protected abstract void HandleDestroy();
    }
}