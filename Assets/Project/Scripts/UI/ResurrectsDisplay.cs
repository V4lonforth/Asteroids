using Scripts.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UI
{
    /// <summary>
    /// Class that displays resurrections left
    /// </summary>
    public class ResurrectsDisplay : MonoBehaviour
    {
        [SerializeField] private Text livesText;

        private void Awake()
        {
            var resurrectManager = FindObjectOfType<ResurrectManager>();
            
            resurrectManager.OnLivesChanged += UpdateText;
        }

        private void UpdateText(int lives)
        {
            livesText.text = lives.ToString();
        }
    }
}