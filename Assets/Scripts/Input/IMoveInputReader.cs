using System;
using UnityEngine;

namespace Arkanoid
{
    public interface IMoveInputReader
    {
        event Action<Vector2> MoveInputChanged;
    }
}