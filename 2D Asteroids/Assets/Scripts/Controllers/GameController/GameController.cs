using UnityEngine;

namespace Assets.Scripts.Controllers.GameController
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private Data.Data _data;

        private MyControllers _controllers;

        private void Start()
        {
            _controllers = new MyControllers();
            new GameInitialization(_controllers, _data);
            _controllers.Initialization();
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            _controllers.Execute(deltaTime);
        }

        private void LateUpdate()
        {
            var deltaTime = Time.deltaTime;
            _controllers.LateExecute(deltaTime);
        }
    }
}
