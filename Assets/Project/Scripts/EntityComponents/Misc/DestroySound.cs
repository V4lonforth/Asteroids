using Scripts.EntityComponents.LifeCycleControllers;
using UnityEngine;

namespace Scripts.EntityComponents.Misc
{
    /// <summary>
    /// Class that listens for entity destroy and plays sound
    /// </summary>
    public class DestroySound : MonoBehaviour
    {
        [SerializeField] private AudioClip destroySound;
        
        private void Awake()
        {
            GetComponent<LifeCycleController>().OnDestroy += PlaySound;
        }

        private void PlaySound(LifeCycleController lifeCycleController)
        {
            AudioSource.PlayClipAtPoint(destroySound, Vector3.zero);
        }
    }
}