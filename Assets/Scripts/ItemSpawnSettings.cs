using UnityEngine;

namespace Arkanoid
{
    [CreateAssetMenu(menuName = "ItemSpawnSettings")]
    public class ItemSpawnSettings : ScriptableObject
    {
        [field: SerializeField]
        public Block ItemPrefab { get; set; }

        [field: SerializeField]
        public float StartPositionX { get; set; }

        [field: SerializeField]
        public float StartPositionY { get; set; }

        [field: SerializeField]
        public float ItemsInRow { get; set; }

        [field: SerializeField]
        public float ItemsInColumn { get; set; }

        [field: SerializeField]
        public float StepX { get; set; }

        [field: SerializeField]
        public float StepY { get; set; }
    }
}