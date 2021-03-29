using Scripts.Utils;
using UnityEngine;

namespace Scripts.Managers
{
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private Rect arenaArea;

        public Rect ArenaArea => arenaArea;
    }
}