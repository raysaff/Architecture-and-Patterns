public class InputController : IExecute
{
    private readonly IUserInputAxis _horizontal;
    private readonly IUserInputAxis _vertical;
    private readonly IUserInputDirection _direction;
    private readonly IUserShoots _shoot;

    public InputController((IUserInputAxis inputHorizontal, IUserInputAxis inputVertical) input, IUserInputDirection inputDirection, IUserShoots shoot)
    {
        _horizontal = input.inputHorizontal;
        _vertical = input.inputVertical;
        _direction = inputDirection;
        _shoot = shoot;
    }

    public void Execute(float deltaTime)
    {
        _horizontal.GetAxis();
        _vertical.GetAxis();
        _direction.GetDirection();
        _shoot.GetShoot();
    }
}