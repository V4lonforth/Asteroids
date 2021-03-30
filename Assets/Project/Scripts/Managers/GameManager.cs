using System;
using System.Collections.Generic;
using Scripts.EntityComponents.Removers;
using Scripts.Utils;
using UnityEngine;

namespace Scripts.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        public Rect ArenaArea => arenaArea;
        public Spawner Spawner { get; private set; }

        [SerializeField] private Rect arenaArea;

        private readonly List<Remover> _removers = new List<Remover>();
        private int _currentRound = 1;
        
        private void Awake()
        {
            Spawner = GetComponent<Spawner>();
            Spawner.OnEnemySpawn += AddEnemyListener;
        }

        private void Start()
        {
            StartGame();
        }

        private void StartGame()
        {
            Spawner.StartGame(arenaArea);
            Spawner.StartRound(_currentRound);
        }

        private void AddEnemyListener(GameObject enemyObject)
        {
            var remover = enemyObject.GetComponent<Remover>();
            if (remover == null) return;
            
            _removers.Add(remover);
            remover.OnRemove += RemoveEnemy;
        }

        private void RemoveEnemy(Remover remover)
        {
            _removers.Remove(remover);
            if (_removers.Count > 0 || Spawner.IsSpawning) return;

            _currentRound++;
            Spawner.StartRound(_currentRound);
        }
    }
}