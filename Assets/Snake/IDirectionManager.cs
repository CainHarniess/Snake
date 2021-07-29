using UnityEngine;

namespace Assets.Snake
{
    public interface IDirectionManager
    {
        public Vector3 MovementDirection { get; }
    }
}