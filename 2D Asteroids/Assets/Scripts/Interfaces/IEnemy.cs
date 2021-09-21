using System;

namespace Assets.Scripts.Interfaces
{
    public interface IEnemy 
    {
        event Action<string> OnTriggerEnterChange;
    }
}
