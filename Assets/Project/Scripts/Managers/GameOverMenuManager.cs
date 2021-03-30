using UnityEngine;

namespace Scripts.Managers
{
    /// <summary>
    /// Class that shows game over menu
    /// </summary>
    public class GameOverMenuManager : MonoBehaviour
    {
        [SerializeField] private GameObject menu;
        
        private void Awake()
        {
            menu.SetActive(false);
            GameManager.Instance.OnGameFinish += ShowMenu;
        }

        private void ShowMenu()
        {
            menu.SetActive(true);
        }
    }
}