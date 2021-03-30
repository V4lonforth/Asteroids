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
            var remover = enemy.GetComponent<Remover>();
            
            if (remover.GetComponent<ScoreReward>() == null) return;
            
            remover.OnRemove += AddScore;
        }

        private void AddScore(Remover remover)
        {
            remover.OnRemove -= AddScore;
            if (GameManager.Instance.Finished) return;

            Score += remover.GetComponent<ScoreReward>().reward;
            OnScoreChange?.Invoke(Score);
        }
    }
}