using System;
using System.Collections;
using Scripts.EntityComponents.LifeCycleControllers;
using UnityEngine;

namespace Scripts.Managers
{
    /// <summary>
    /// Class that revives player
    /// </summary>
    public class ResurrectManager : MonoBehaviour
    {
        /// <summary>
        /// Notifies when amount of lives changes
        /// </summary>
        public Action<int> OnLivesChanged;

        [SerializeField] private int lives;
        [SerializeField] private float respawnTime;

        /// <summary>
        /// Current amount of resurrections left
        /// </summary>
        public int LivesLeft { get; private set; }

        private void Awake()
        {
            GameManager.Instance.OnGameStart += AddPlayerListener;
        }

        private void Start()
        {
            LivesLeft = lives;
            OnLivesChanged?.Invoke(LivesLeft);
        }

        private void AddPlayerListener()
        {
            GameManager.Instance.Player.GetComponent<LifeCycleController>().OnDestroy += CheckPlayerDeath;
        }

        private void CheckPlayerDeath(LifeCycleController playerLifeCycleController)
        {
            if (LivesLeft > 0)
            {
                LivesLeft--;
                OnLivesChanged?.Invoke(LivesLeft);
                StartCoroutine(Respawn(playerLifeCycleController));
            }
            else
            {
                GameManager.Instance.FinishGame();
            }
        }

        private IEnumerator Respawn(LifeCycleController playerLifeCycleController)
        {
            yield return new WaitForSeconds(respawnTime);
            playerLifeCycleController.Spawn();
        }
    }
}