using UnityEngine;

namespace Arkanoid
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField]
        private PlayerData _playerData;

        [SerializeField]
        private ScriptableObject _moveInputReader;

        private IMoveInputReader _input;

        private Vector3 _accelerationDirection;

        private Rigidbody _physicsBody;

        private void Start()
        {
            _input = _moveInputReader as IMoveInputReader;
            _input.MoveInputChanged += OnMoveInputChanged;
            _physicsBody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            Move();
        }

        private void OnMoveInputChanged(Vector2 direction)
        {
            _accelerationDirection = new Vector3(direction.x * transform.right.x, direction.y * transform.up.y, 0);
        }

        private void Move()
        {
            if (_accelerationDirection == Vector3.zero)
            {
                var brakingDirection = -_physicsBody.velocity.normalized;
                _physicsBody.AddForce(_playerData.Acceleration * brakingDirection, ForceMode.Acceleration);
            }

            _physicsBody.AddForce(_playerData.Acceleration * _accelerationDirection, ForceMode.Acceleration);
        }

        private void OnDestroy()
        {
            _input.MoveInputChanged -= OnMoveInputChanged;
        }
    }
}