namespace Assets.Scripts.HW6.ChainOfResponsibility
{
    public interface IGameHandler
    {
        IGameHandler Handle();
        IGameHandler SetNext(IGameHandler nextHandler);
    }
}
