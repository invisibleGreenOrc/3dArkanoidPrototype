using UnityEngine;

namespace Arkanoid
{
    public class InGameMenu : MonoBehaviour
    {
        [SerializeField]
        private Game _game;

        public void Close()
        {

        }

        public void ResumeGame()
        {
            _game.Resume();
            Close();
        }

        public void RestartLevel()
        {
            _game.RestartLevel();
        }

        public void Exit()
        {
            _game.Exit();
        }
    }
}
