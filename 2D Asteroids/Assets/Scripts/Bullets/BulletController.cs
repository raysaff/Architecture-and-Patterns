using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Bullets
{
    public class BulletController : MonoBehaviour
    {
        private float _lifeTime = 3.0f;

        private void OnEnable()
        {
            StartCoroutine("LifeRoutine");
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
}
