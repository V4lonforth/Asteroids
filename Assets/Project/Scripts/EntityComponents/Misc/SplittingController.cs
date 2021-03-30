using System.Collections.Generic;
using Scripts.EntityComponents.LifeCycleControllers;
using Scripts.EntityComponents.Movement;
using Scripts.Managers;
using Scripts.Utils;
using UnityEngine;

namespace Scripts.EntityComponents.Misc
{
    /// <summary>
    /// Class that spawns new enemies when the enemy is killed
    /// </summary>
    public class SplittingController : MonoBehaviour
    {
        [SerializeField] private List<GameObject> splitPrefabs;
        [SerializeField] private int splitCount;

        private void Awake()
        {
            GetComponent<LifeCycleController>().OnDestroy += Split;
        }

        private void Split(LifeCycleController lifeCycleController)
        {
            var spawner = GameManager.Instance.Spawner;
            var movement = GetComponent<IMovement>();
            for (var i = 0; i < splitCount; i++)
            {
                spawner.SpawnEnemy(splitPrefabs[Random.Range(0, splitPrefabs.Count)], movement.Position, Random.Range(0f, 360f), MathHelper.DegreeToVector2(Random.Range(0f, 360f)));
            }
        }
    }
}