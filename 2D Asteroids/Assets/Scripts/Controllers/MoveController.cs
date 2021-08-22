using UnityEngine;

public sealed class MoveController : IExecute
{
    private readonly Transform _unit;
    private readonly IUnit _unitData;

    private readonly Rigidbody2D _unitRb;

    private float _horizontal;
    private float _vertical;

    private Vector2 _move;

    private IUserInputAxis _horizontalInput;
    private IUserInputAxis _verticalInput;

    public MoveController((IUserInputAxis inputHorizontal, IUserInputAxis inputVertical) input,
        Transform unit, IUnit unitData)
    {
        _unit = unit;
        _unitData = unitData;
        _horizontalInput = input.inputHorizontal;
        _verticalInput = input.inputVertical;
        _horizontalInput.AxisOnChange += HorizontalOnAxisOnChange;
        _verticalInput.AxisOnChange += VerticalOnAxisOnChange;
        _unitRb = _unit.GetComponent<Rigidbody2D>();
    }

    private void VerticalOnAxisOnChange(float value)
    {
        _vertical = value;
    }

    private void HorizontalOnAxisOnChange(float value)
    {
        _horizontal = value;
    }

    public void Execute(float deltaTime)
    {
        var velocity = _unitRb.velocity;
        velocity.x = Mathf.Clamp(velocity.x, -15, 15);
        velocity.y = Mathf.Clamp(velocity.y, -15, 15);
        _unitRb.velocity = velocity;

        var speed = deltaTime * _unitData.Speed;
        _move = new Vector2(_horizontal, _vertical);
        _unitRb.mass = _unitData.Mass;
        _unitRb.AddForce(_move * speed);

    }

}

