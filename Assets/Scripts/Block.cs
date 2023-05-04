using System;
using UnityEngine;

namespace Arkanoid
{
    public class Block : MonoBehaviour
    {
        public event Action<Block> BlockDestroying;

        private void OnCollisionEnter(Collision collision)
        {
            BlockDestroying?.Invoke(this);
            Destroy(gameObject);
        }
    }
}