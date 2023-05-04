using UnityEngine;

namespace Arkanoid
{
    [CreateAssetMenu(menuName = "GameData")]
    public class GameData : ScriptableObject
    {
        [field: SerializeField]
        public float BallStartSpeed { get; set; }

        [field: SerializeField]
        public float BallSpeedIncreaseStep { get; set; }

        [field: SerializeField]
        public float BallMaxSpeed { get; set; }

        [field: SerializeField]
        public Vector3 BallSpawnPositionOffset { get; set; }

        [field: SerializeField]
        public Ball BallPrefab { get; set; }

        [field: SerializeField]
        public int StartHealth { get; set; }
    }
}
