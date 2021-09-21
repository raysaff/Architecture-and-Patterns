using UnityEngine;

namespace Assets.Scripts.HW7.States
{
    [CreateAssetMenu(fileName = "States", menuName = "States/Second")]
    public class SecondState : State
    {
        private Transform _sprite;
        public override void Init()
        {
            _sprite = Character.transform.GetChild(0);
            _sprite.GetComponent<SpriteRenderer>().color = Color.red;
            Debug.Log("Second State");
        }
    }
}
