using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class EnemyDecorator : EnemyController
    {
        private Rigidbody2D _rb;
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            var speed = _rb.velocity.magnitude;

            var _interpolant = Mathf.InverseLerp(15f, -15f, speed);
            var _color = Mathf.Lerp(0f, 255, _interpolant);

            _spriteRenderer.color = new Color(255, _color, _color);
        }

    }
}
