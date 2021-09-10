using System.Collections;
using UnityEngine;

public sealed class FirstChain : GameHandler
{
    [SerializeField]
    private Transform _ship;
    private Transform _satellite;
    private float _currentScale;
    private float _maximum = 10.0f;

    private void Awake()
    {
        _satellite = GameObject.CreatePrimitive(PrimitiveType.Sphere).transform;
        _satellite.localScale = new Vector3(_maximum, _maximum, _maximum);
        _satellite.position = _ship.position;
         _currentScale = _maximum;
    }

    private IEnumerator StartMoving()
    {
        while (_currentScale>=0.0f)
        {
            _satellite.localScale = new Vector3(_currentScale, _currentScale, _currentScale);
            _currentScale -= 0.1f;
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

