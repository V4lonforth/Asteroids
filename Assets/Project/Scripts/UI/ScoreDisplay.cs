using Scripts.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UI
{
    public class ScoreDisplay : MonoBehaviour
    {
        [SerializeField] private Text scoreText;

        private void Awake()
        {
            var scoreManager = FindObjectOfType<ScoreManager>();
            
            scoreManager.OnScoreChange += UpdateText;
            UpdateText(scoreManager.Score);
        }

        private void UpdateText(int score)
        {
            scoreText.text = score.ToString();
        }
    }
}