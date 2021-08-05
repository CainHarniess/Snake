using System.Collections.Generic;
using UnityEngine;

namespace Assets.ReRevisedSnake
{
    public class SnakeLength : MonoBehaviour
    {
        [SerializeField] private List<SegmentMovement> snakeList;
        [SerializeField] private GameObject snakeBodySegmentPrefab;
        
        private SnakeMovement snakeMovement;

        private GameObject PreTailGameObject { get => snakeList[snakeList.Count - 2].gameObject; }
        private BodySegmentMovement PreTailSegmentMovement { get => PreTailGameObject.GetComponent<BodySegmentMovement>(); }
        private GameObject TailGameObject { get => snakeList[snakeList.Count - 1].gameObject; }

        private void Awake()
        {
            snakeList = new List<SegmentMovement>(GetComponentsInChildren<SegmentMovement>());
            snakeMovement = GetComponentInParent<SnakeMovement>();
        }  

        public void IncreaseSnakeLength()
        {
            TailSegmentMovement tailSegmentMovement = TailGameObject.GetComponent<TailSegmentMovement>();
            
            BodySegmentMovement newSegmentMovement = Instantiate(snakeBodySegmentPrefab,
                                                                 PreTailSegmentMovement.CurrentGridTilePosition,
                                                                 PreTailGameObject.transform.rotation,
                                                                 transform
                                                                ).GetComponent<BodySegmentMovement>();

            AddNewSegmentToList(newSegmentMovement, snakeMovement.SegmentMovements);
            AddNewSegmentToList(newSegmentMovement, snakeList);
        }

        private void AddNewSegmentToList(BodySegmentMovement segmentMovementToAdd, List<SegmentMovement> listToAddTo)
        {
            TailSegmentMovement tailSegmentMovement = listToAddTo[listToAddTo.Count - 1].gameObject.GetComponent<TailSegmentMovement>();

            segmentMovementToAdd.PreceedingSegmentMovement = listToAddTo[listToAddTo.Count - 2];

            listToAddTo[listToAddTo.Count - 1] = segmentMovementToAdd;
            tailSegmentMovement.PreceedingSegmentMovement = segmentMovementToAdd;
            listToAddTo.Add(tailSegmentMovement);
        }
    }
}