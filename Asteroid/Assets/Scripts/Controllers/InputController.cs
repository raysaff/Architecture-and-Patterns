public class InputController : IExecute
{
    private readonly IUserInputAxis _horizontal;
    private readonly IUserInputAxis _vertical;
    private readonly IUserInputDirection _direction;

    public InputController((IUserInputAxis inputHorizontal, IUserInputAxis inputVertical, IUserInputDirection inputDirection) input)
    {
        _horizontal = input.inputHorizontal;
        _vertical = input.inputVertical;
        _direction = input.inputDirection;
    }

    public void Execute(float deltaTime)
    {
        _horizontal.GetAxis();
        _vertical.GetAxis();
        _direction.GetDirection();
    }
}