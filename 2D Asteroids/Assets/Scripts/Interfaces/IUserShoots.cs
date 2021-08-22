using System;


public interface IUserShoots 
{
    event Action<float[]> TakeShoot;
    void GetShoot();
}
