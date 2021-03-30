using System;
using System.Collections;
using Scripts.EntityComponents.Removers;
using UnityEngine;

namespace Scripts.Managers
{
    public class ResurrectManager : MonoBehaviour
    {
        public Action<int> OnLivesChanged;
        
        [SerializeField] private int lives;
        [SerializeField] private float respawnTime;

        public int LivesLeft { get; private set; }
        
        private void Start()
        {
            GameManager.Instance.Spawner.OnPlayerSpawn += AddPlayerListener;
            
            LivesLeft = lives;
            OnLivesChanged?.Invoke(LivesLeft);
        }

        private void AddPlayerListener(GameObject player)
        {
            player.GetComponent<LifeCycleController>().OnDestroy += CheckPlayerDeath;
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