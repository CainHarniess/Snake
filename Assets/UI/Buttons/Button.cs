using UnityEngine;
using Assets.Game;
using Assets.UI;

public abstract class Button : MonoBehaviour, IButton
{
    protected StateMachine gameStateMachine;
    protected virtual void Awake()
    {
        gameStateMachine = GameObject.FindGameObjectWithTag("GameStateMachine").GetComponent<StateMachine>();
    }

    public abstract void OnButtonClick();
}