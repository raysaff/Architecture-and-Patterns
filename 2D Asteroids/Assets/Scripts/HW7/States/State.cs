using UnityEngine;

namespace Assets.Scripts.HW7.States
{
    public abstract class State : ScriptableObject
    {
        public Character Character;
    
        public virtual void Init() {}

    }
}
