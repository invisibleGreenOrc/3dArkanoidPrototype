using System;
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

        private Vector3 _offset = new(0f, 0f, 2f);

        private Vector3 _ballStartVelocity = new(0.1f, 0.2f, 1f);

        private void Start()
        {
            _ball = Instantiate(_ballPrefab, _mainPlayer.transform.position + _offset, Quaternion.identity);
            _ball.Velocity = _ballStartVelocity;

            _ball.LeftPlayground += OnBallLeftPlayground;
        }

        private void OnBallLeftPlayground()
        {
            ResetBallPosition();
        }

        private void ResetBallPosition()
        {
            _ball.transform.position = _mainPlayer.transform.position + _offset;
            _ball.Velocity = _ballStartVelocity;
        }
    }
}
