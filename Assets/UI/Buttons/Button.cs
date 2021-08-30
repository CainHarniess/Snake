using UnityEngine;
using Assets.Game;
using Assets.UI;
using Assets;

public abstract class Button : MonoBehaviour, IButton
{
    protected StateMachine gameStateMachine;
    protected virtual void Awake()
    {
        gameStateMachine = GameObject.FindGameObjectWithTag(Tags.GameStateMachine).GetComponent<StateMachine>();
    }

    public abstract void OnButtonClick();
}