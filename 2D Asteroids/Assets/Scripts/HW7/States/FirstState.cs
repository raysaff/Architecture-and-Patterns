using UnityEngine;

namespace Assets.Scripts.HW7.States
{
    [CreateAssetMenu(fileName = "States", menuName = "States/First")]
    public class FirstState : State
    {
        private Transform _sprite;
        public override void Init()
        {
            _sprite = Character.transform.GetChild(0);
            _sprite.GetComponent<SpriteRenderer>().color = Color.green;
            Debug.Log("First State");
        }
    }
}
