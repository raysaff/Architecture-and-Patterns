using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour, IEnemy
{
    private float _lifeTime = 2.0f;
    private Rigidbody2D _rb;
    public event Action<string> OnTriggerEnterChange;
    [SerializeField]
    private EnemyData _enemyData;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnTriggerEnterChange?.Invoke(collision.gameObject.tag);
        Deactivate();
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }


    private void OnEnable()
    {
        StartCoroutine("LifeRoutine");
        _rb.mass = _enemyData._mass;
        _rb.AddForce(Random.insideUnitCircle*_enemyData._speed);
    }

    private void OnDisable()
    {
        StopCoroutine("LifeRoutine");
    }

    private IEnumerator LifeRoutine()
    {
        yield return new WaitForSecondsRealtime(_lifeTime);

        Deactivate();
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
