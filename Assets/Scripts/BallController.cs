using UnityEngine;

namespace Arcanoid
{
    public class BallController : MonoBehaviour
    {
        [SerializeField]
        private float _speed;

        private Vector3 _velocity;

        private void Awake()
        {
            _velocity = _speed * new Vector3 (0.1f, 0.2f, 1f);
        }

        private void Update()
        {
            Move();
        }

        private void OnCollisionEnter(Collision collision)
        {
            Bounce(collision.GetContact(0).normal);
        }

        private void Move()
        {
            transform.position += Time.deltaTime * _velocity;
        }

        private void Bounce(Vector3 collisionNormal)
        {
            _velocity = Vector3.Reflect(_velocity, collisionNormal);
        }
    }
}
