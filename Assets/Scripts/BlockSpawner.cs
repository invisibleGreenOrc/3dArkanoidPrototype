using System;
using UnityEngine;

namespace Arkanoid
{ 
    public class BlockSpawner : MonoBehaviour
    {
        [SerializeField]
        private ItemSpawnSettings _spawnSettings;

        public event Action<Block> BlockSpawned;

        private void Start()
        {
            Spawn();
        }

        private void Spawn()
        {
            var x = 0f;
            var y = 0f;

            for (var i = 0; i < _spawnSettings.ItemsInRow; i++)
            {
                x = _spawnSettings.StartPositionX + _spawnSettings.StepX * i;

                for (var j = 0; j < _spawnSettings.ItemsInColumn; j++)
                {
                    y = _spawnSettings.StartPositionY + _spawnSettings.StepY * j;

                    var position = new Vector3(x, y, 0f);
                    Block block = Instantiate(_spawnSettings.ItemPrefab, position, GetRandomRotation(), transform);

                    BlockSpawned?.Invoke(block);
                }
            }
        }

        private Quaternion GetRandomRotation()
        {
            return UnityEngine.Random.rotation;
        }
    }
}