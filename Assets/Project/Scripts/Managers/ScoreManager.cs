using System;
using Scripts.EntityComponents.LifeCycleControllers;
using Scripts.EntityComponents.Misc;
using UnityEngine;

namespace Scripts.Managers
{
    /// <summary>
    /// Class that handles current player score
    /// </summary>
    public class ScoreManager : MonoBehaviour
    {
        /// <summary>
        /// Notifies when score changes 
        /// </summary>
        public Action<int> OnScoreChange { get; set; }
        public int Score { get; private set; }
        
        private void Awake()
        {
            GetComponent<Spawner>().OnEnemySpawn += AddEnemyListener;
        }

        private void AddEnemyListener(GameObject enemy)
        {
            var lifeCycleController = enemy.GetComponent<LifeCycleController>();
            
            if (lifeCycleController.GetComponent<ScoreReward>() == null) return;
            
            lifeCycleController.OnDestroy += AddScore;
        }

        private void AddScore(LifeCycleController lifeCycleController)
        {
            lifeCycleController.OnDestroy -= AddScore;
            if (GameManager.Instance.IsFinished) return;

            Score += lifeCycleController.GetComponent<ScoreReward>().reward;
            OnScoreChange?.Invoke(Score);
        }
    }
}