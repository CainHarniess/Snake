using UnityEngine;

namespace Assets.Snake
{
    public class HeadCollisionHandler : MonoBehaviour
    {
        private SnakeLength snakeLength;

        private void Awake()
        {
            snakeLength = GameObject.FindGameObjectWithTag(Tags.SnakeManager).GetComponentInParent<SnakeLength>();
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(Tags.Edible)) snakeLength.IncreaseSnakeLength();
        }
    }
}