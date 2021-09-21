namespace Assets.Scripts.Interfaces
{
    public interface ILateExecutes : IControllers
    {
        void LateExecute(float deltaTime);
    }
}
