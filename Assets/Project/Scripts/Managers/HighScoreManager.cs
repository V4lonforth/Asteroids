using System;
using UnityEngine;

namespace Scripts.Managers
{
    public class HighScoreManager : MonoBehaviour
    {
        public Action<int> OnHighScoreChange { get; set; }
        
        [SerializeField] private ScoreManager scoreManager;

        private int _highScore;

        private const string HighScoreName = "HighScore";
        
        private void Awake()
        {
            GameManager.Instance.OnGameFinish += CheckHighScore;
        }

        private void Start()
        {
            _highScore = GetHighScore();
            OnHighScoreChange?.Invoke(_highScore);
        }

        private void CheckHighScore()
        {
            if (scoreManager.Score <= _highScore) return;
            
            _highScore = scoreManager.Score;
            SaveHighScore(_highScore);
            OnHighScoreChange?.Invoke(_highScore);
        }

        private int GetHighScore()
        {
            return PlayerPrefs.HasKey(HighScoreName) ? PlayerPrefs.GetInt(HighScoreName) : 0;
        }

        private void SaveHighScore(int highScore)
        {
            PlayerPrefs.SetInt(HighScoreName, highScore);
        }
    }
}