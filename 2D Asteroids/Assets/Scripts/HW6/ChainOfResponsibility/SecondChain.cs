using System.Collections;
using Assets.Scripts.BuilderExtensions;
using UnityEngine;

namespace Assets.Scripts.HW6.ChainOfResponsibility
{
    public class SecondChain : GameHandler
    {
        [SerializeField]
        private Transform _ship;
        private Transform _satellite;
        private float _currentScale;
        private float _minimum = 0.0f;

        private void Awake()
        {
            _satellite = new GameObject("Sphere").AddSprite(Resources.Load<Sprite>("Sprites/enemy_sprite")).transform;
            _satellite.localScale = new Vector3(_minimum, _minimum, _minimum);
            _satellite.position = _ship.position;
            _currentScale = _minimum;
        }

        private IEnumerator StartMoving()
        {
            while (_currentScale <= 10.0f)
            {
                _satellite.localScale = new Vector3(_currentScale, _currentScale, _currentScale);
                _currentScale += 0.1f;
                yield return null;
            }
            base.Handle();
        }

        public override IGameHandler Handle()
        {
            StartCoroutine(StartMoving());
            return this;
        }
    }
}
