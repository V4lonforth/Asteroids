﻿using Scripts.EntityComponents.MovementControllers;
using UnityEngine;

namespace Scripts.EntityComponents.Weapons
{
    public class ProjectileLauncher : MonoBehaviour, IWeapon
    {
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private Transform projectileOrigin;

        [SerializeField] private AudioClip fireSound;
        [SerializeField] private AudioSource audioSource;
        
        private MovementController _parentMovementController;
        
        private void Awake()
        {
            _parentMovementController = GetComponentInParent<MovementController>();
        }

        public void Fire()
        {
            var projectileObject = Instantiate(projectilePrefab);
            
            projectileObject.transform.position = transform.position;
            projectileObject.transform.rotation = transform.rotation;

            var projectileMovement = projectileObject.GetComponent<MovementController>();
            projectileMovement.Launch(projectileOrigin.position, projectileOrigin.rotation.eulerAngles.z, _parentMovementController.Movement.Velocity);
            
            audioSource.PlayOneShot(fireSound);
        }
    }
}