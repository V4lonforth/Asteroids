using System.Collections.Generic;
using Scripts.EntityComponents.Movement;
using Scripts.EntityComponents.MovementControllers;
using Scripts.EntityComponents.Removers;
using Scripts.Utils;
using UnityEngine;

namespace Scripts.EntityComponents.Misc
{
    public class WreckController : MonoBehaviour
    {
        [SerializeField] private List<GameObject> fragmentPrefabs;
        [SerializeField] private int fragmentAmount;

        [SerializeField] private float minInitialSpeed;
        [SerializeField] private float maxInitialSpeed;

        [SerializeField] private float wreckTimeSkip;

        private void Awake()
        {
            GetComponent<LifeCycleController>().OnDestroy += Wreck;
        }

        private void Wreck(LifeCycleController lifeCycleController)
        {
            var movement = lifeCycleController.GetComponent<IMovement>();

            for (var i = 0; i < fragmentAmount; i++)
            {
                var velocity =
                    MathHelper.DegreeToVector2(Random.Range(0f, 360f)) *
                    Random.Range(minInitialSpeed, maxInitialSpeed);
                var position = movement.Position + velocity * wreckTimeSkip;

                var fragment = Instantiate(fragmentPrefabs[Random.Range(0, fragmentPrefabs.Count)], position,
                    Quaternion.identity);

                fragment.GetComponent<LifeCycleController>().Spawn();
                fragment.GetComponent<MovementController>()
                    .Launch(position, Random.Range(0f, 360f), velocity);
            }
        }
    }
}