internal sealed class InputInitialization : IInit
{
    private IUserInputAxis _inputHorizontal;
    private IUserInputAxis _inputVertical;
    private IUserInputDirection _sightDirection;
    private IUserShoots _inputShoot;

    public InputInitialization()
    {
        _inputHorizontal = new InputHorizontal();
        _inputVertical = new InputVertical();
        _sightDirection = new InputDirection();
        _inputShoot = new InputShoot();
    }

    public void Initialization()
    {
    }

    public (IUserInputAxis inputHorizontal, IUserInputAxis inputVertical) GetInputAxis()
    {
        (IUserInputAxis inputHorizontal, IUserInputAxis inputVertical) result = (_inputHorizontal, _inputVertical);
        return result;
    }

    public IUserInputDirection GetInputDirection()
    {
        IUserInputDirection inputDirection = _sightDirection;
        return inputDirection;
    }

    public IUserShoots GetShoot()
    {
        IUserShoots inputShoot = _inputShoot;
        return inputShoot;
    }
        
}
