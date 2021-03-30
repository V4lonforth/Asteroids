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
        public bool Finished { get; private set; }

        public Action OnGameStart { get; set; }
        public Action OnGameFinish { get; set; }
        
        public Action OnRoundStart { get; set; }
        public Action OnRoundFinish { get; set; }

        [SerializeField] private Rect arenaArea;

        public GameObject Player { get; private set; }
        
        private readonly List<LifeCycleController> _removers = new List<LifeCycleController>();
        private int _currentRound;
        
        private void Awake()
        {
            Spawner = GetComponent<Spawner>();
            Spawner.OnEnemySpawn += AddEnemyListener;
            Spawner.OnPlayerSpawn += p => Player = p;
        }

        private void Start()
        {
            StartGame();
        }

        private void StartGame()
        {
            Spawner.StartGame(arenaArea);
            OnGameStart?.Invoke();
         
            StartRound();
        }

        private void StartRound()
        {
            _currentRound++;
            Spawner.StartRound(_currentRound);
            OnRoundStart?.Invoke();
        }

        private void FinishRound()
        {
            OnRoundFinish?.Invoke();
            
            StartRound();
        }

        public void FinishGame()
        {
            Finished = true;
            
            OnGameFinish?.Invoke();
        }
        
        private void AddEnemyListener(GameObject enemyObject)
        {
            var remover = enemyObject.GetComponent<LifeCycleController>();
            if (remover == null) return;
            
            _removers.Add(remover);
            remover.OnDestroy += RemoveEnemy;
        }

        private void RemoveEnemy(LifeCycleController lifeCycleController)
        {
            _removers.Remove(lifeCycleController);
            if (_removers.Count > 0 || Spawner.IsSpawning) return;

            FinishRound();
        }
    }
}