using System;
using UnityEngine;

public class InputDirection : IUserInputDirection
{

    public event Action<float[]> DirectionOnChange = delegate (float[] f) { };

    public void GetDirection()
    {
        float[] mousePosition = new float[2] { Input.mousePosition.x, Input.mousePosition.y }; 
        DirectionOnChange.Invoke(mousePosition);
    }
}
