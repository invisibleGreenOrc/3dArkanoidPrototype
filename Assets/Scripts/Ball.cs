using System;
using UnityEngine;

namespace Arcanoid
{
    public class Ball : MonoBehaviour
    {
        [SerializeField]
        private float _speed;

        public Vector3 Velocity { get; set; }

        public event Action LeftPlayground;

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
            transform.position += _speed * Time.deltaTime * Velocity;
        }

        private void Bounce(Vector3 collisionNormal)
        {
            Velocity = Vector3.Reflect(Velocity, collisionNormal);
        }
    }
}
