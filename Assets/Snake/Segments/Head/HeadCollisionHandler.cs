using UnityEngine;

namespace Assets.Snake
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
            if (other.gameObject.CompareTag("Edible")) snakeLength.IncreaseSnakeLength();
        }
    }
}