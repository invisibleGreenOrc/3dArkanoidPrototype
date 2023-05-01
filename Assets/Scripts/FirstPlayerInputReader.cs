using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static Arcanoid.GameInput;

namespace Arcanoid
{
    [CreateAssetMenu(menuName = "FirstPlayerInputReader")]
    public class FirstPlayerInputReader : ScriptableObject, IFirstPlayerGameplayActions
    {
        private GameInput _gameInput;

        public event Action<Vector2> MoveEvent;

        public event Action ReleaseBallEvent;

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
            _gameInput.SecondPlayerGameplay.Disable();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            MoveEvent?.Invoke(context.ReadValue<Vector2>());
        }

        public void OnReleaseBall(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed)
            {
                ReleaseBallEvent?.Invoke();
            }
        }
    }
}