using System;
using Scripts.EntityComponents.Misc;
using Scripts.EntityComponents.Removers;
using UnityEngine;

namespace Scripts.Managers
{
    public class ScoreManager : MonoBehaviour
    {
        public Action<int> OnScoreChange { get; set; }
        public int Score { get; private set; }
        
        private void Awake()
        {
            GetComponent<Spawner>().OnEnemySpawn += AddEnemyListener;
        }

        private void AddEnemyListener(GameObject enemy)
        {
            var remover = enemy.GetComponent<LifeCycleController>();
            
            if (remover.GetComponent<ScoreReward>() == null) return;
            
            remover.OnDestroy += AddScore;
        }

        private void AddScore(LifeCycleController lifeCycleController)
        {
            lifeCycleController.OnDestroy -= AddScore;
            if (GameManager.Instance.Finished) return;

            Score += lifeCycleController.GetComponent<ScoreReward>().reward;
            OnScoreChange?.Invoke(Score);
        }
    }
}