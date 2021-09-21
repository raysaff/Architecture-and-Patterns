using System;

namespace Assets.Scripts.Interfaces
{
    public interface IUserInputDirection 
    {
        event Action<float[]> DirectionOnChange;
        void GetDirection();
    }
}
