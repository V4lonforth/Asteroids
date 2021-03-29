using Scripts.EntityComponents.MovementControllers;
using UnityEngine;

namespace Scripts.EntityComponents.Weapons
{
    public class ProjectileLauncher : MonoBehaviour, IWeapon
    {
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private Transform projectileOrigin;
        
        public void Fire()
        {
            var projectileObject = Instantiate(projectilePrefab);
            
            projectileObject.transform.position = transform.position;
            projectileObject.transform.rotation = transform.rotation;

            var projectileMovement = projectileObject.GetComponent<MovementController>();
            if (projectileMovement != null)
                projectileMovement.Spawn(projectileOrigin.position, projectileOrigin.rotation.eulerAngles.z);
        }
    }
}