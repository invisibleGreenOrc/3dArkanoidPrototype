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

        public void StopMovement()
        {
            _physicsBody.velocity = Vector3.zero;
            _accelerationDirection = Vector3.zero;
        }

        private void Awake()
        {
            _input = _moveInputReader as IMoveInputReader;
        }

        private void OnEnable()
        {
            _input.MoveInputChanged += OnMoveInputChanged;
        }

        private void Start()
        {
            _physicsBody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            Move();
        }

        private void OnDisable()
        {
            _input.MoveInputChanged -= OnMoveInputChanged;
        }

        private void OnMoveInputChanged(Vector2 direction)
        {
            _accelerationDirection = new Vector3(direction.x * transform.right.x, direction.y * transform.up.y, 0);
        }

        private void Move()
        {
            if (_accelerationDirection == Vector3.zero && _physicsBody.velocity != Vector3.zero)
            {
                var brakingDirection = -_physicsBody.velocity.normalized;
                _physicsBody.AddForce(_playerData.Acceleration * brakingDirection, ForceMode.Acceleration);
            }

            _physicsBody.AddForce(_playerData.Acceleration * _accelerationDirection, ForceMode.Acceleration);
        }
    }
}