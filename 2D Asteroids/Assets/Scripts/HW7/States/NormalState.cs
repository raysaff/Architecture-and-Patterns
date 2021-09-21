using UnityEngine;

namespace Assets.Scripts.HW7.States
{
    [CreateAssetMenu(fileName = "States", menuName = "States/Normal", order = -1)]
    public class NormalState : State
    {
        private Transform _sprite;
        public override void Init()
        {
            _sprite = Character.transform.GetChild(0);
            _sprite.GetComponent<SpriteRenderer>().color = Color.white;
            Debug.Log("Normal State");
        }
    }
}
