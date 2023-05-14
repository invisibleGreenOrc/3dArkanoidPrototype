using TMPro;
using UnityEngine;

namespace Arkanoid
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _healthAmountText;

        [SerializeField]
        private Game _game;

        private void OnEnable()
        {
            _game.HealthAmountChanged += OnHealthAmountChanged;
        }

        private void Start()
        {
            _healthAmountText.text = _game.Health.ToString();
        }

        private void OnDisable()
        {
            _game.HealthAmountChanged -= OnHealthAmountChanged;
        }

        private void OnHealthAmountChanged()
        {
            _healthAmountText.text = _game.Health.ToString();
        }
    }
}
