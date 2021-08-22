using System;

public interface IUserInputAxis
{
    event Action<float> AxisOnChange;

    void GetAxis();
}
