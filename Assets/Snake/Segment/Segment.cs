using UnityEngine;

namespace Assets.Snake
{
    public class Segment : MonoBehaviour
    {
        protected SnakeLength snakeLengthManager;

        protected virtual void Awake()
        {
            snakeLengthManager = GetComponentInParent<SnakeLength>();
        }
    }
}