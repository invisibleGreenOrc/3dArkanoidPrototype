using UnityEngine;
using UnityEngine.UI;

namespace Arkanoid
{
    public class InGameMenu : MonoBehaviour
    {
        //[SerializeField]
        //private Game _game;

        [field: SerializeField]
        public Button ResumeGameButton { get; set; }

        [field: SerializeField]
        public Button RestartLevelButton { get; set; }

        [field: SerializeField]
        public Button ExitButton { get; set; }

        //public void Close()
        //{
        //    gameObject.SetActive(false);
        //}

        //public void ResumeGame()
        //{
        //    _game.Resume();
        //    Close();
        //}

        //public void RestartLevel()
        //{
        //    _game.RestartLevel();
        //}

        //public void Exit()
        //{
        //    _game.Exit();
        //}
    }
}
