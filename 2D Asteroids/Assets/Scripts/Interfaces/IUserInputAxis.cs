using System;

namespace Assets.Scripts.Interfaces
{
    public interface IUserInputAxis
    {
        event Action<float> AxisOnChange;

        void GetAxis();
    }
}
