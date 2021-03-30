using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.UI
{
    /// <summary>
    /// Class that controls scenes
    /// </summary>
    public class GameMenu : MonoBehaviour
    {
        public void StartGameScene()
        {
            SceneManager.LoadScene("GameScene");
        }
        
        public void RestartScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void Quit()
        {     
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}