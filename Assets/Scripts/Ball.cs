using System;
using UnityEngine;

namespace Arkanoid
{
    public class Ball : MonoBehaviour
    {
        private float _startSpeed;
        
        private float _speed;

        private float _maxSpeed;

        private Vector3 _moveDirection;

        public event Action LeftPlayground;

        public void Init(float startSpeed, float maxSpeed)
        {
            _startSpeed = startSpeed;
            _maxSpeed = maxSpeed;

            SetSpeedToStartValue();
        }

        public void ChangeSpeed(float deltaSpeed)
        {
            _speed = Mathf.Clamp(_speed + deltaSpeed, 0, _maxSpeed);
        }

        public void SetSpeedToStartValue()
        {
            _speed = _startSpeed;
        }

        public void StartMoving()
        {
            _moveDirection = transform.forward;
        }

        public void StopMoving()
        {
            _moveDirection = Vector3.zero;
        }

        private void Update()
        {
            Move();
        }

        private void OnCollisionEnter(Collision collision)
        {
            Bounce(collision.GetContact(0).normal);
        }

        private void OnTriggerEnter(Collider other)
        {
            LeftPlayground?.Invoke();
        }

        private void Move()
        {
            if (_moveDirection == Vector3.zero)
            {
                return;
            }

            transform.position += _speed * Time.deltaTime * _moveDirection;
        }

        private void Bounce(Vector3 collisionNormal)
        {
            _moveDirection = Vector3.Reflect(_moveDirection, collisionNormal);
        }
    }
}
