using UnityEngine;

namespace StateMachine2d
{
    public class AppleGrowingState : AppleBaseState
    {
        Vector3 startingAppleSize = new Vector3(0.1f, 0.1f, 0.1f);
        Vector3 growingAppleScalar = new Vector3(0.1f, 0.1f, 0.1f);
        public static readonly int growingAppleIndex = 0;
        public override void EnterState(AppleStateManager apple)
        {
            apple.transform.localScale = startingAppleSize;
            apple.GetComponent<AppleStateManager>().spriteRenderers[growingAppleIndex].enabled = true;
        }
        public override void UpdateState(AppleStateManager apple)
        {
            if (apple.transform.localScale.x < 1f)
            {
                apple.transform.localScale += growingAppleScalar * Time.deltaTime;
            }
            else
            {
                apple.SwitchState(apple.WholeState);
            }
        }
        public override void OnCollisionState(AppleStateManager apple, Collision collision)
        {
            //here might be reaction of player if he eats green unripe apple
        }
    }
}

