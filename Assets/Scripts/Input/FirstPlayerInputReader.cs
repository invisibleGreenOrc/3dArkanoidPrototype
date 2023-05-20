using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static Arkanoid.GameInput;

namespace Arkanoid
{
    [CreateAssetMenu(menuName = "FirstPlayerInputReader")]
    public class FirstPlayerInputReader : ScriptableObject, IFirstPlayerGameplayActions, IMoveInputReader, IReleaseBallInputReader, IPauseGameInputReader
    {
        private GameInput _gameInput;

        public event Action ReleaseBallInputPerformed;

        public event Action PauseGameInputPerformed;

        public event Action<Vector2> MoveInputChanged;

        public void OnMove(InputAction.CallbackContext context)
        {
            MoveInputChanged?.Invoke(context.ReadValue<Vector2>());
        }

        public void OnReleaseBall(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                ReleaseBallInputPerformed?.Invoke();
            }
        }

        public void OnPauseGame(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                PauseGameInputPerformed?.Invoke();
            }
        }

        private void OnEnable()
        {
            if (_gameInput is null)
            {
                _gameInput = new GameInput();

                _gameInput.FirstPlayerGameplay.SetCallbacks(this);
            }

            _gameInput.FirstPlayerGameplay.Enable();
        }

        private void OnDisable()
        {
            _gameInput.FirstPlayerGameplay.Disable();
        }
    }
}