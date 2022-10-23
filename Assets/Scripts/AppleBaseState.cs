using UnityEngine;

namespace StateMachine2d
{
    /// <summary>
    /// This example made by xat, taken from great tutorial:
    /// https://www.youtube.com/watch?v=Vt8aZDPzRjI
    /// </summary>
    public abstract class AppleBaseState
    {
        public abstract void EnterState(AppleStateManager apple);
        public abstract void UpdateState(AppleStateManager apple);
        public abstract void OnCollisionState(AppleStateManager apple, Collision collision);
    }
}

