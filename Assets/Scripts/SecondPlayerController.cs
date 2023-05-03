using UnityEngine;

namespace Arcanoid
{
    public class SecondPlayerController : MonoBehaviour
    {
        [SerializeField]
        private SecondPlayerInputReader _inputReader;

        [SerializeField]
        private float _speed;

        private Vector2 _moveDirection;

        private void Start()
        {
            _inputReader.MoveEvent += HandleMove;
        }

        private void Update()
        {
            Move();
        }

        private void HandleMove(Vector2 direction)
        {
            _moveDirection = direction;
        }

        private void Move()
        {
            if (_moveDirection == Vector2.zero)
            {
                return;
            }

            var newPosition = transform.position + _speed * Time.deltaTime * new Vector3(_moveDirection.x * transform.right.x, _moveDirection.y, 0);

            transform.position = new Vector3(Mathf.Clamp(newPosition.x, -4, 4), Mathf.Clamp(newPosition.y, -4.5f, 4.5f), newPosition.z);
        }
    }
}
