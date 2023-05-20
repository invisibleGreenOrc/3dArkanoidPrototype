using UnityEngine;

namespace Arkanoid
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField]
        private MenuData _menuData;

        [SerializeField]
        private Canvas _rootCanvas;

        private InGameMenu _inGameMenuPrefab;

        private InGameMenu _inGameMenu;

        public Game Game { get; set; }

        public void ShowInGameMenu()
        {
            Game.Pause();
            _inGameMenu.ResumeGameButton.onClick.AddListener(Game.Resume);
            _inGameMenu.ResumeGameButton.onClick.AddListener(CloseInGameMenu);
            _inGameMenu.RestartLevelButton.onClick.AddListener(Game.RestartLevel);
            _inGameMenu.ExitButton.onClick.AddListener(Game.Exit);

            _inGameMenu.gameObject.SetActive(true);
        }

        public void CloseInGameMenu()
        {
            _inGameMenu.ResumeGameButton.onClick.RemoveListener(Game.Resume);
            _inGameMenu.ResumeGameButton.onClick.RemoveListener(CloseInGameMenu);
            _inGameMenu.RestartLevelButton.onClick.RemoveListener(Game.RestartLevel);
            _inGameMenu.ExitButton.onClick.RemoveListener(Game.Exit);

            _inGameMenu.gameObject.SetActive(false);
        }

        private void Start()
        {
            _inGameMenuPrefab = _menuData.InGameMenu;

            _inGameMenu = Instantiate(_inGameMenuPrefab, _rootCanvas.transform);
            _inGameMenu.gameObject.SetActive(false);
        }
    }
}
