using System;

public interface IUserInputDirection 
{
    event Action<float[]> DirectionOnChange;
    void GetDirection();
}
