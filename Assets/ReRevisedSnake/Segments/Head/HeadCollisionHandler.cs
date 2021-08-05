using UnityEngine;

namespace Assets.ReRevisedSnake
{
    public class HeadCollisionHandler : MonoBehaviour
    {
        private SnakeLength snakeLength;

        private void Awake()
        {
            snakeLength = GetComponentInParent<SnakeLength>();
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Trigger!");
            if (other.gameObject.CompareTag("Edible"))
            {
                snakeLength.IncreaseSnakeLength();
            }
        }
    }
}