using System;
using UnityEngine;

namespace Scripts.EntityComponents.Removers
{
    public abstract class Remover : MonoBehaviour
    {
        public Action<Remover> OnRemove { get; set; }
        
        public void Remove()
        {
            OnRemove?.Invoke(this);
            HandleRemove();
        }

        protected abstract void HandleRemove();
    }
}