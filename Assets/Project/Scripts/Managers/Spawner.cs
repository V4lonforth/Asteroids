using System;
using System.Collections.Generic;
using Scripts.EntityComponents.MovementControllers;
using Scripts.EntityComponents.Removers;
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
        [SerializeField] private List<GameObject> duringRoundEnemyPrefabs;

        [SerializeField] private float minTimeToSpawnEnemy;
        [SerializeField] private float maxTimeToSpawnEnemy;
        
        private Rect _arenaArea;
        
        private float _remainingTimeToSpawnEnemy;
        private int _enemiesToSpawn;

        private void Update()
        {
            if (!IsSpawning) return;
            if (_enemiesToSpawn <= 0)
            {
                IsSpawning = false;
                return;
            }
            
            _remainingTimeToSpawnEnemy -= Time.deltaTime;
            if (_remainingTimeToSpawnEnemy > 0) return;
            
            SpawnEnemy(duringRoundEnemyPrefabs[Random.Range(0, duringRoundEnemyPrefabs.Count)],
                GetRandomBorderPosition(GetRandomBorder()), 0f, Vector2.zero);
            _enemiesToSpawn--;
            _remainingTimeToSpawnEnemy = Random.Range(minTimeToSpawnEnemy, maxTimeToSpawnEnemy);
        }

        public void StartGame(Rect arenaArea)
        {
            _arenaArea = arenaArea;
            SpawnPlayer();
        }

        public void StartRound(int number)
        {
            IsSpawning = true;
            
            _enemiesToSpawn = number;
            _remainingTimeToSpawnEnemy = Random.Range(minTimeToSpawnEnemy, maxTimeToSpawnEnemy);

            for (var i = 0; i < number; i++)
            {
                SpawnEnemy(initialEnemyPrefabs[Random.Range(0, initialEnemyPrefabs.Count)]);
            }
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
            spawnedObject.GetComponent<LifeCycleController>().Spawn();
            spawnedObject.GetComponent<MovementController>().Launch(position, rotation, velocity);
            return spawnedObject;
        }

        private Vector2Int GetRandomBorder()
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