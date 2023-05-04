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

        private Vector2 _moveDirection;

        private void Start()
        {
            _input = _moveInputReader as IMoveInputReader;
            _input.MoveInputChanged += OnMoveInputChanged;
        }

        private void Update()
        {
            Move();
        }

        private void OnMoveInputChanged(Vector2 direction)
        {
            _moveDirection = direction;
        }

        private void Move()
        {
            if (_moveDirection == Vector2.zero)
            {
                return;
            }

            var newPosition = transform.position + _playerData.Speed * Time.deltaTime * new Vector3(_moveDirection.x * transform.right.x, _moveDirection.y * transform.up.y, 0);

            transform.position = new Vector3(Mathf.Clamp(newPosition.x, -_playerData.ClampX, _playerData.ClampX),
                                             Mathf.Clamp(newPosition.y, -_playerData.ClampY, _playerData.ClampY),
                                             newPosition.z);
        }
    }
}