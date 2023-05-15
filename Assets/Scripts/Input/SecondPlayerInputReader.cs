using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static Arkanoid.GameInput;

namespace Arkanoid
{
    [CreateAssetMenu(menuName = "SecondPlayerInputReader")]
    public class SecondPlayerInputReader : ScriptableObject, ISecondPlayerGameplayActions, IMoveInputReader
    {
        private GameInput _gameInput;

        public event Action<Vector2> MoveInputChanged;

        public void OnMove(InputAction.CallbackContext context)
        {
            MoveInputChanged?.Invoke(context.ReadValue<Vector2>());
        }

        private void OnEnable()
        {
            if (_gameInput is null)
            {
                _gameInput = new GameInput();

                _gameInput.SecondPlayerGameplay.SetCallbacks(this);
            }

            _gameInput.SecondPlayerGameplay.Enable();
        }

        private void OnDisable()
        {
            _gameInput.SecondPlayerGameplay.Disable();
        }
    }
}