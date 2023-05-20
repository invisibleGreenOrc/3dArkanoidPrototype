using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Arkanoid
{
    public class Game : MonoBehaviour
    {
        private const string MenuSceneName = "Menu";

        [SerializeField]
        private GameData _gameData;
        
        private Ball _ball;

        [SerializeField]
        private ScriptableObject _releaseBallInputReader;

        private IReleaseBallInputReader _releaseBallInput;

        [SerializeField]
        private ScriptableObject _pauseGameInputReader;

        private IPauseGameInputReader _pauseGameInput;

        [SerializeField]
        private PlayerMover _firstPlayerTransform;

        [SerializeField]
        private PlayerMover _secondPlayerTransform;

        private int _health;

        [SerializeField]
        private BlockSpawner _cubeSpawner;

        private SceneLoader _sceneLoader;

        private MenuController _menuController;

        public event Action HealthAmountChanged;

        public int Health => _health;

        public void Pause()
        {
            _firstPlayerTransform.enabled = false;
            _firstPlayerTransform.StopMovement();
            _secondPlayerTransform.enabled = false;
            _secondPlayerTransform.StopMovement();

            _ball.enabled = false;
        }

        public void Resume()
        {
            _firstPlayerTransform.enabled = true;
            _secondPlayerTransform.enabled = true;
            _ball.enabled = true;
        }

        public void RestartLevel()
        {
            _sceneLoader.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void Exit()
        {
            _sceneLoader.LoadScene(MenuSceneName);
        }

        private void OnEnable()
        {
            _releaseBallInput = _releaseBallInputReader as IReleaseBallInputReader;
            _releaseBallInput.ReleaseBallInputPerformed += OnReleaseBall;

            _pauseGameInput = _pauseGameInputReader as IPauseGameInputReader;
            _pauseGameInput.PauseGameInputPerformed += OnPauseGame;

            _health = _gameData.StartHealth;

            _cubeSpawner.BlockSpawned += OnCubeSpawned;
        }

        private void Start()
        {
            _ball = Instantiate(_gameData.BallPrefab);
            _ball.Init(_gameData.BallStartSpeed, _gameData.BallMaxSpeed);
            MoveBallToStartPosition();

            _ball.LeftPlayground += OnBallLeftPlayground;

            _sceneLoader = GetComponent<SceneLoader>();
            _menuController = GetComponent<MenuController>();
            _menuController.Game = this;
        }

        private void OnDisable()
        {
            _releaseBallInput.ReleaseBallInputPerformed -= OnReleaseBall;
            _pauseGameInput.PauseGameInputPerformed -= OnPauseGame;
        }

        private void OnCubeSpawned(Block cube)
        {
            cube.BlockDestroying += OnCubeDestroying;
        }

        private void OnCubeDestroying(Block cube)
        {
            cube.BlockDestroying -= OnCubeDestroying;

            _ball.ChangeSpeed(_gameData.BallSpeedIncreaseStep);
        }

        private void OnReleaseBall()
        {
            _ball.transform.SetParent(null);
            _ball.StartMoving();
        }

        private void OnPauseGame()
        {
            _menuController.ShowInGameMenu();
        }

        private void OnBallLeftPlayground()
        {
            MoveBallToStartPosition();
            
            DecreaseHealth();
        }

        private void MoveBallToStartPosition()
        {
            _ball.transform.position = _firstPlayerTransform.transform.position + _gameData.BallSpawnPositionOffset;
            _ball.transform.SetParent(_firstPlayerTransform.transform, true);
            
            _ball.StopMoving();
            _ball.SetSpeedToStartValue();
        }

        private void DecreaseHealth()
        {
            _health--;
            HealthAmountChanged?.Invoke();

            if (_health == 0)
            {
                Exit();
            }
        }
    }
}