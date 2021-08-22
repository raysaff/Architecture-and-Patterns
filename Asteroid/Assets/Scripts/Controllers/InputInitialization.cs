internal sealed class InputInitialization : IInit
{
    private IUserInputAxis _inputHorizontal;
    private IUserInputAxis _inputVertical;
    private IUserInputDirection _sightDirection;

    public InputInitialization()
    {
        _inputHorizontal = new InputHorizontal();
        _inputVertical = new InputVertical();
        _sightDirection = new InputDirection();
    }

    public void Initialization()
    {
    }

    public (IUserInputAxis inputHorizontal, IUserInputAxis inputVertical, IUserInputDirection inputDirection) GetInput()
    {
        (IUserInputAxis inputHorizontal, IUserInputAxis inputVertical, IUserInputDirection inputDirection) result = (_inputHorizontal, _inputVertical, _sightDirection);
        return result;
    }
}
