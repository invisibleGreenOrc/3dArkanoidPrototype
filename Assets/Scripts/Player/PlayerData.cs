﻿using UnityEngine;

namespace Arkanoid
{
    [CreateAssetMenu(menuName = "PlayerData")]
    public class PlayerData : ScriptableObject
    {
        [field: SerializeField]
        public float Acceleration { get; set; }

        [field: SerializeField]
        public float ClampX { get; set; }

        [field: SerializeField]
        public float ClampY { get; set; }
    }
}