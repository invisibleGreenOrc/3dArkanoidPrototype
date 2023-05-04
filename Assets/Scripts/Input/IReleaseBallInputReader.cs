using System;

namespace Arkanoid
{
    public interface IReleaseBallInputReader
    {
        event Action ReleaseBallInputPerformed;
    }
}
