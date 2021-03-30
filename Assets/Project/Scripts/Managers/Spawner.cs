using System;
using System.Collections.Generic;
using Scripts.EntityComponents.MovementControllers;
using Scripts.Utils;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Scripts.Managers
{
    public class Spawner : MonoBehaviour
    {
        private static readonly Vector2 SpawnPosition = Vector2.one * 1000f;

        public Action<GameObject> OnPlayerSpawn { get; set; }
        public Action<GameObject> OnEnemySpawn { get; set; }
        public bool IsSpawning { get; private set; }

        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private List<GameObject> initialEnemyPrefabs;

        private Rect _arenaArea;

        public void StartGame(Rect arenaArea)
        {
            _arenaArea = arenaArea;
            SpawnPlayer();
        }

        public void StartRound(int number)
        {
            IsSpawning = true;

            for (var i = 0; i < number; i++)
            {
                SpawnEnemy(initialEnemyPrefabs[Random.Range(0, initialEnemyPrefabs.Count)]);
            }

            IsSpawning = false;
        }

        private void SpawnPlayer()
        {
            var playerObject = Spawn(playerPrefab, Vector2.zero, 0f, Vector2.zero);
            OnPlayerSpawn?.Invoke(playerObject);
        }

        public void SpawnEnemy(GameObject prefab, Vector2 position, float rotation, Vector2 velocity)
        {
            OnEnemySpawn?.Invoke(Spawn(prefab, position, rotation, velocity));
        }

        private void SpawnEnemy(GameObject prefab)
        {
            var border = GetRandomBorder();
            SpawnEnemy(prefab, GetRandomBorderPosition(border), Random.Range(0f, 360f),
                MathHelper.DegreeToVector2(GetRandomDirection(border)));
        }

        private static GameObject Spawn(GameObject prefab, Vector2 position, float rotation, Vector2 velocity)
        {
            var spawnedObject = Instantiate(prefab, SpawnPosition, Quaternion.identity);
            spawnedObject.GetComponent<MovementController>().Spawn(position, rotation, velocity);
            return spawnedObject;
        }

        private static Vector2Int GetRandomBorder()
        {
            var direction = Random.Range(0, 2) * 2 - 1;
            return Random.Range(0, 2) == 0 ? new Vector2Int(direction, 0) : new Vector2Int(0, direction);
        }

        private float GetRandomDirection(Vector2Int border)
        {
            return MathHelper.Vector2ToDegree(border) + Random.Range(-90f, 90f);
        }

        private Vector2 GetRandomBorderPosition(Vector2Int border)
        {
            var number = Random.Range(-1f, 1f);
            return _arenaArea.center + border * _arenaArea.size / 2f +
                   new Vector2(border.y, border.x) * number * _arenaArea.size / 2f;
        }
    }
}