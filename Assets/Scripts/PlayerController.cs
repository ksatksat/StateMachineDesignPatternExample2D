using UnityEngine;
using UnityEngine.SceneManagement;

namespace StateMachine2d
{
    public class PlayerController : MonoBehaviour
    {
        float horizontal, health = 100f, damageOrHealing = 10f;
        public float speed = .2f;
        void Update()
        {
            horizontal = Input.GetAxis("Horizontal");
            transform.position += Vector3.right * horizontal * speed * Time.deltaTime;
            if (health <= 0f)
            {
                gameObject.GetComponent<BoxCollider>().enabled = false;
                Debug.Log("You wasted!");
            }
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
                Debug.Log("Quit!");
            }
        }
        public void detractHealth()
        {
            health -= damageOrHealing;
        }
        public void addHealth()
        {
            health += damageOrHealing;
        }
    }
}

