using UnityEngine;

namespace Arcanoid
{
    public class FirstPlayerController : MonoBehaviour
    {
        [SerializeField]
        private FirstPlayerInputReader _inputReader;

        [SerializeField]
        private float _speed;

        private Vector2 _moveDirection;

        private void Start()
        {
            _inputReader.MoveEvent += HandleMove;
            _inputReader.ReleaseBallEvent += HandleReleaseBall;
        }

        private void Update()
        {
            Move();
        }

        private void HandleMove(Vector2 direction)
        {
            _moveDirection = direction;
        }

        private void HandleReleaseBall()
        {
            
        }

        private void Move()
        {
            if (_moveDirection == Vector2.zero)
            {
                return;
            }

            transform.position += _speed * Time.deltaTime * new Vector3(_moveDirection.x, _moveDirection.y, 0);
        }
    }
}
