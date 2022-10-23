using UnityEngine;

namespace StateMachine2d
{
    public class AppleRottenState : AppleBaseState
    {
        float disableCountdown = 10f;
        public static readonly int rottenAppleIndex = 3;
        public override void EnterState(AppleStateManager apple)
        {
            apple.GetComponent<AppleStateManager>()
                .spriteRenderers[AppleGrowingState.growingAppleIndex].enabled = false; 
            apple.GetComponent<AppleStateManager>()
                .spriteRenderers[AppleWholeState.wholeAppleIndex].enabled = false;
            apple.GetComponent<AppleStateManager>()
                .spriteRenderers[AppleChewedState.chewedAppleIndex].enabled = false;
            apple.GetComponent<AppleStateManager>().spriteRenderers[rottenAppleIndex].enabled = true;
        }
        public override void UpdateState(AppleStateManager apple)
        {
            if (disableCountdown > 0f)
            {
                disableCountdown -= Time.deltaTime;
            }
            else
            {
                apple.gameObject.SetActive(false);
            }
        }
        public override void OnCollisionState(AppleStateManager apple, Collision collision)
        {
            GameObject other = collision.gameObject;
            if (other.CompareTag("Player"))
            {
                apple.GetComponent<AppleStateManager>()
                    .spriteRenderers[rottenAppleIndex].enabled = false;
                apple.GetComponent<AppleStateManager>()
                    .spriteRenderers[AppleChewedState.chewedAppleIndex].enabled = true;
                other.GetComponent<PlayerController>().detractHealth();
                apple.SwitchState(apple.ChewedState);
            }
        }
    }
}

