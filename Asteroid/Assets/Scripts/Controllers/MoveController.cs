using UnityEngine;

public sealed class MoveController : IExecute
{
    private readonly Transform _unit;
    private readonly IUnit _unitData;

    private float _horizontal;
    private float _vertical;

    private Vector3 _move;
    private Vector3 _mousePosition;

    private IUserInputAxis _horizontalInput;
    private IUserInputAxis _verticalInput;

    private IUserInputDirection _directionInput;

    public MoveController((IUserInputAxis inputHorizontal, IUserInputAxis inputVertical, IUserInputDirection inputDirection) input,
        Transform unit, IUnit unitData)
    {
        _unit = unit;
        _unitData = unitData;
        _horizontalInput = input.inputHorizontal;
        _verticalInput = input.inputVertical;
        _directionInput = input.inputDirection;
        _horizontalInput.AxisOnChange += HorizontalOnAxisOnChange;
        _verticalInput.AxisOnChange += VerticalOnAxisOnChange;
        _directionInput.DirectionOnChange += DirectionChanging;
    }

    private void VerticalOnAxisOnChange(float value)
    {
        _vertical = value;
    }

    private void HorizontalOnAxisOnChange(float value)
    {
        _horizontal = value;
    }

    private void DirectionChanging(float[] value)
    {
        _mousePosition.Set(value[0], value[1], 0.0f);
    }

    public void Execute(float deltaTime)
    {
        var speed = deltaTime * _unitData.Speed;
        _move = new Vector3(_horizontal, _vertical, 0.0f);
        _unit.GetComponent<Rigidbody>().AddForce(_move * speed, ForceMode.Acceleration);
        _unit.rotation = Quaternion.LookRotation(Camera.main.ScreenToWorldPoint(_mousePosition), Vector3.forward);
    }

}

