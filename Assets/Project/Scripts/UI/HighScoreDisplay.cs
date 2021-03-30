using Scripts.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UI
{
    public class HighScoreDisplay : MonoBehaviour
    {
        [SerializeField] private Text highScoreText;

        private void Awake()
        {
            var highScoreManager = FindObjectOfType<HighScoreManager>();
            
            highScoreManager.OnHighScoreChange += UpdateText;
        }

        private void UpdateText(int score)
        {
            highScoreText.text = score.ToString();
        }
    }
}