using UnityEditor;
using UnityEngine;

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

        private void Start()
        {
            _releaseBallInput = _releaseBallInputReader as IReleaseBallInputReader;

            _releaseBallInput.ReleaseBallInputPerformed += OnReleaseBall;

            _health = _gameData.StartHealth;

            _cubeSpawner.BlockSpawned += OnCubeSpawned;

            _ball = Instantiate(_gameData.BallPrefab);
            _ball.Init(_gameData.BallStartSpeed, _gameData.BallMaxSpeed);
            MoveBallToStartPosition();

            _ball.LeftPlayground += OnBallLeftPlayground;
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

            Debug.Log($"Health left: {_health}");
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

            if (_health == 0)
            {
                EditorApplication.isPaused = true;
            }
        }
    }
}