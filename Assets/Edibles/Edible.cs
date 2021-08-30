using UnityEngine;
using UnityEngine.Events;

namespace Assets.Edibles

{
    public abstract class Edible : MonoBehaviour
    {
        [SerializeField] protected int scoreValue;
        [SerializeField] protected UnityEvent OnEaten;
        public int ScoreValue { get => scoreValue; }

        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("SnakeHead"))
            {
                OnEaten.Invoke();
            }
        }
    }
}