using UnityEditor;
using UnityEngine;

namespace Arkanoid
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField]
        private SceneLoader _sceneLoader;

        private const string GameSceneName = "Game";

        public void StartNewGame()
        {
            _sceneLoader.LoadScene(GameSceneName);
        }

        public void Exit()
        {
            EditorApplication.isPaused = true;
        }
    }
}