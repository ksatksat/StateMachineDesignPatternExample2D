using UnityEngine;

namespace StateMachine2d
{
    public class AppleChewedState : AppleBaseState
    {
        float destroyCountdown = 2.0f;
        public static readonly int chewedAppleIndex = 2;
        public override void EnterState(AppleStateManager apple)
        {
            apple.GetComponent<AppleStateManager>()
                .spriteRenderers[AppleWholeState.wholeAppleIndex].enabled = false;
            apple.GetComponent<AppleStateManager>().spriteRenderers[chewedAppleIndex].enabled = true;
        }
        public override void UpdateState(AppleStateManager apple)
        {
            if (destroyCountdown > 0)
            {
                destroyCountdown -= Time.deltaTime;
            }
            else
            {
                //Object.Destroy(apple.gameObject);
                apple.gameObject.SetActive(false);
            }
        }
        public override void OnCollisionState(AppleStateManager apple, Collision collision)
        {
            //here might be reaction of player if he tries eats chewed apple
        }
    }
}

