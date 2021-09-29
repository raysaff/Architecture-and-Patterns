using UnityEngine;

namespace Assets.Scripts.HW7.States
{
    public class Character : MonoBehaviour
    {
        [SerializeField]
        private State _normalState;
    
        [SerializeField] 
        private State _firstState;
        [SerializeField] 
        private State _secondState;
        [SerializeField] 
        private State _thirdState;

        private State _currentState;
    
    
        void Start()
        {
            SetState(_normalState);
        }
    
        void Update()
        {
            if (Input.GetKey(KeyCode.Keypad1))
            {
                SetState(_firstState);
            }
            if (Input.GetKey(KeyCode.Keypad2))
            {
                SetState(_secondState);
            }
            if (Input.GetKey(KeyCode.Keypad3))
            {
                SetState(_thirdState);
            }

            if (Input.GetKey(KeyCode.Space))
            {
                SetState(_normalState);
            }
        }

        public void SetState(State state)
        {
            _currentState = Instantiate(state);
            _currentState.Character = this;
            _currentState.Init();
        }
    }
}
