using UnityEngine;

namespace StateMachine2d
{
    public class AppleWholeState : AppleBaseState
    {
        float rottenCountdown = 10f;
        bool isItTimeToBeRotten = false;
        public static readonly int wholeAppleIndex = 1;
        public override void EnterState(AppleStateManager apple)
        {
            apple.GetComponent<Rigidbody>().useGravity = true;
            apple.GetComponent<AppleStateManager>()
                .spriteRenderers[AppleGrowingState.growingAppleIndex].enabled = false;
            apple.GetComponent<AppleStateManager>().spriteRenderers[wholeAppleIndex].enabled = true;
        }
        public override void UpdateState(AppleStateManager apple)
        {
            if (rottenCountdown >= 0f)
            {
                rottenCountdown -= Time.deltaTime;
            }
            else
            {
                isItTimeToBeRotten = true;
            }
            if (isItTimeToBeRotten)
            {
                apple.SwitchState(apple.RottenState);
                isItTimeToBeRotten = false;
            }
        }
        public override void OnCollisionState(AppleStateManager apple, Collision collision)
        {
            GameObject other = collision.gameObject;
            if (other.CompareTag("Player"))
            {
                other.GetComponent<PlayerController>().addHealth();
                apple.SwitchState(apple.ChewedState);
            }
        }
    }
}

