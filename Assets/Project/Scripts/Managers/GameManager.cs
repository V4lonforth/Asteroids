using System;
using System.Collections.Generic;
using Scripts.EntityComponents.LifeCycleControllers;
using Scripts.Utils;
using UnityEngine;

namespace Scripts.Managers
{
    /// <summary>
    /// Main class that controls round progression
    /// </summary>
    public class GameManager : Singleton<GameManager>
    {
        /// <summary>
        /// Allowed area
        /// </summary>
        public Rect ArenaArea => arenaArea;
        /// <summary>
        /// Spawns entities
        /// </summary>
        public Spawner Spawner { get; private set; }
        /// <summary>
        /// Is game finished
        /// </summary>
        public bool IsFinished { get; private set; }

        /// <summary>
        /// Notifies on game start
        /// </summary>
        public Action OnGameStart { get; set; }
        /// <summary>
        /// Notifies on game finish
        /// </summary>
        public Action OnGameFinish { get; set; }
        
        /// <summary>
        /// Notifies on round start
        /// </summary>
        public Action OnRoundStart { get; set; }
        /// <summary>
        /// Notifies on round finish
        /// </summary>
        public Action OnRoundFinish { get; set; }

        [SerializeField] private Rect arenaArea;

        public GameObject Player { get; private set; }
        
        private readonly List<LifeCycleController> _lifeCycleControllers = new List<LifeCycleController>();
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
            IsFinished = true;
            
            OnGameFinish?.Invoke();
        }
        
        private void AddEnemyListener(GameObject enemyObject)
        {
            var lifeCycleController = enemyObject.GetComponent<LifeCycleController>();
            if (lifeCycleController == null) return;
            
            _lifeCycleControllers.Add(lifeCycleController);
            lifeCycleController.OnDestroy += RemoveEnemy;
        }

        private void RemoveEnemy(LifeCycleController lifeCycleController)
        {
            _lifeCycleControllers.Remove(lifeCycleController);
            if (_lifeCycleControllers.Count > 0 || Spawner.IsSpawning) return;

            FinishRound();
        }
    }
}