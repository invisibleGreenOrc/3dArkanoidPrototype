using System;
using UnityEditor;
using UnityEngine;

namespace Arcanoid
{
    public class Game : MonoBehaviour
    {
        [SerializeField]
        private Ball _ballPrefab;
        
        private Ball _ball;

        [SerializeField]
        private FirstPlayerController _mainPlayer;

        [SerializeField]
        private int _health = 3;

        private Vector3 _offset = new(0f, 0f, 2f);

        private Vector3 _ballStartVelocity = new(0.1f, 0.2f, 1f);

        [SerializeField]
        private CubeSpawner _cubeSpawner;

        private void Start()
        {
            _ball = Instantiate(_ballPrefab, _mainPlayer.transform.position + _offset, Quaternion.identity);
            MoveBallToStartPosition();

            _ball.LeftPlayground += OnBallLeftPlayground;
            _mainPlayer.ReleaseBall += OnReleaseBall;

            _cubeSpawner.CubeSpawned += OnCubeSpawned;
        }

        private void OnCubeSpawned(Cube cube)
        {
            cube.CubeDestroying += OnCubeDestroying;
        }

        private void OnCubeDestroying(Cube cube)
        {
            cube.CubeDestroying -= OnCubeDestroying;

            _ball.ChangeSpeed(0.5f);
        }

        private void OnReleaseBall()
        {
            _ball.transform.SetParent(null);
            _ball.Velocity = _ballStartVelocity;
        }

        private void OnBallLeftPlayground()
        {
            MoveBallToStartPosition();
            _ball.SetSpeedToStartValue();
            DecreaseHealth();

            Debug.Log($"Health left: {_health}");
        }

        private void MoveBallToStartPosition()
        {
            _ball.transform.position = _mainPlayer.transform.position + _offset;
            _ball.transform.SetParent(_mainPlayer.transform, true);
            _ball.Velocity = Vector3.zero;
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
