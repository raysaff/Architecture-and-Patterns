using System;

public interface IEnemy 
{
    event Action<string> OnTriggerEnterChange;
}
