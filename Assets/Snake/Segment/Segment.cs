using UnityEngine;

namespace Assets.Snake
{
    public class Segment : MonoBehaviour
    {
        [SerializeField] private GameObject preceedingSegment;

        public GameObject PreceedingSegment
        {
            get => preceedingSegment;
            set
            {
                if (preceedingSegment = null)
                {
                    preceedingSegment = value;
                }
            }
        }
    }
}