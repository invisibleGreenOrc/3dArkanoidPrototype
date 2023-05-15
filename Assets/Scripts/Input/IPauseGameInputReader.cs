using System;

namespace Arkanoid
{
    public interface IPauseGameInputReader
    {
        event Action PauseGameInputPerformed;
    }
}