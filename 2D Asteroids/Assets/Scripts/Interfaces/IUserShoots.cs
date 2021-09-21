using System;

namespace Assets.Scripts.Interfaces
{
    public interface IUserShoots 
    {
        event Action<float[]> TakeShoot;
        void GetShoot();
    }
}
