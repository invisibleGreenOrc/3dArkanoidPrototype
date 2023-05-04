using System;
using UnityEngine;

namespace Arkanoid
{ 
    public class CubeSpawner : MonoBehaviour
    {
        [SerializeField]
        private Cube _cubePrefab;

        public event Action<Cube> CubeSpawned;

        private void Start()
        {
            Spawn();
        }

        private void Spawn()
        {
            var x = 0f;
            var y = 0f;

            for (var i = 0; i < 10; i++)
            {
                x = -4 + 0.8f * i;

                for (var j = 0; j < 10; j++)
                {
                    y = -4 + 0.8f * j;

                    var position = new Vector3(x, y, 0f);
                    Cube cube = Instantiate(_cubePrefab, position, Quaternion.identity, transform);

                    CubeSpawned?.Invoke(cube);
                }
            }
        }
    }
}
