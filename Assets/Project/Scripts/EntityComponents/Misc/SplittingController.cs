using System.Collections.Generic;
using Scripts.EntityComponents.Movement;
using Scripts.EntityComponents.Removers;
using Scripts.Managers;
using Scripts.Utils;
using UnityEngine;

namespace Scripts.EntityComponents.Misc
{
    public class SplittingController : MonoBehaviour
    {
        [SerializeField] private List<GameObject> splitPrefabs;
        [SerializeField] private int splitCount;

        private void Awake()
        {
            GetComponent<Remover>().OnRemove += Split;
        }

        private void Split(Remover remover)
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