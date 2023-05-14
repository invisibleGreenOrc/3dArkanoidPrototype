using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Arkanoid
{
    public class Game : MonoBehaviour
    {
        [SerializeField]
        private GameData _gameData;
        
        private Ball _ball;

        [SerializeField]
        private ScriptableObject _releaseBallInputReader;

        private IReleaseBallInputReader _releaseBallInput;

        [SerializeField]
        private Transform _mainPlayerTransform;

        private int _health;

        [SerializeField]
        private BlockSpawner _cubeSpawner;

        private SceneLoader _sceneLoader;

        public event Action HealthAmountChanged;

        public int Health => _health;

        public void Pause()
        {

        }

        public void Resume()
        {

        }

        public void RestartLevel()
        {
            _sceneLoader.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void Exit()
        {
            EditorApplication.isPaused = true;
        }

        private void OnEnable()
        {
            _releaseBallInput = _releaseBallInputReader as IReleaseBallInputReader;
            _releaseBallInput.ReleaseBallInputPerformed += OnReleaseBall;

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
        }

        private void OnDestroy()
        {
            _releaseBallInput.ReleaseBallInputPerformed -= OnReleaseBall;
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

        private void OnBallLeftPlayground()
        {
            MoveBallToStartPosition();
            
            DecreaseHealth();
        }

        private void MoveBallToStartPosition()
        {
            _ball.transform.position = _mainPlayerTransform.position + _gameData.BallSpawnPositionOffset;
            _ball.transform.SetParent(_mainPlayerTransform, true);
            
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