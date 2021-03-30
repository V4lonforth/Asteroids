using Scripts.EntityComponents.Removers;
using UnityEngine;

namespace Scripts.EntityComponents.Misc
{
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