using UnityEngine;
using System.Collections.Generic;

namespace StateMachine2d
{
    public class AppleStateManager : MonoBehaviour
    {
        AppleBaseState currentState;
        public AppleGrowingState GrowingState = new AppleGrowingState();
        public AppleChewedState ChewedState = new AppleChewedState();
        public AppleRottenState RottenState = new AppleRottenState();
        public AppleWholeState WholeState = new AppleWholeState();
        public List<SpriteRenderer> spriteRenderers = new List<SpriteRenderer>();
        void Start()
        {
            currentState = GrowingState;
            currentState.EnterState(this);
        }
        void OnCollisionEnter(Collision collision)
        {
            currentState.OnCollisionState(this, collision);
        }
        void Update()
        {
            currentState.UpdateState(this);
        }
        public void SwitchState(AppleBaseState state)
        {
            currentState = state;
            state.EnterState(this);
        }
    }
}

