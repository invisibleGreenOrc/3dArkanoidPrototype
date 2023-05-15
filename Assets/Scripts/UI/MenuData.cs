using UnityEngine;

namespace Arkanoid
{
    [CreateAssetMenu(menuName = "MenuData")]
    public class MenuData : ScriptableObject
    {
        [field: SerializeField]
        public MainMenu MainMenu { get; set; }

        [field: SerializeField]
        public InGameMenu InGameMenu { get; set; }
    }
}