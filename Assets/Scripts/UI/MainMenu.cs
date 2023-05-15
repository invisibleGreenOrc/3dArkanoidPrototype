using UnityEditor;
using UnityEngine;

namespace Arkanoid
{
    public class MainMenu : MonoBehaviour
    {
        private const string GameSceneName = "Game";
        
        [SerializeField]
        private SceneLoader _sceneLoader;

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