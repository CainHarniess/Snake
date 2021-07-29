using UnityEngine;
using UnityEngine.Events;

namespace Assets.Edibles

{
    public class Edible : MonoBehaviour
    {
        [SerializeField] private int scoreValue;
        [SerializeField] private UnityEvent OnEaten;

        public int ScoreValue { get => scoreValue; }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("SnakeHead"))
            {
                OnEaten.Invoke();
            }
        }
    }
}