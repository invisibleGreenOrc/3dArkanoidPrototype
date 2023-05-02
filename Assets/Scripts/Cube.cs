using System;
using UnityEngine;

namespace Arcanoid
{
    public class Cube : MonoBehaviour
    {
        public event Action<Cube> CubeDestroying;

        private void OnCollisionEnter(Collision collision)
        {
            CubeDestroying?.Invoke(this);
            Destroy(gameObject);
        }
    }
}