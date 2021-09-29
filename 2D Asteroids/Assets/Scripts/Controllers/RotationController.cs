using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
    public class RotationController : ILateExecutes
    {
        private readonly Transform _unit;

        private Vector3 _mousePosition;
        private float _normal = 90;
        private IUserInputDirection _directionInput;

        public RotationController(IUserInputDirection inputDirection, Transform unit)
        {
            _unit = unit;
            _directionInput = inputDirection;
            _directionInput.DirectionOnChange += DirectionChanging;
        }

        private void DirectionChanging(float[] value)
        {
            _mousePosition.Set(value[0], value[1],0);
        }

        public void LateExecute(float deltaTime)
        {
            Vector3 moveDirection = Camera.main.ScreenToWorldPoint(_mousePosition) - _unit.position;
            float angle = Mathf.Atan2(moveDirection.x, moveDirection.y) * Mathf.Rad2Deg;
            _unit.rotation = Quaternion.Euler(angle-_normal, _normal, _normal);
        }
    }
}
