using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine// : MonoBehaviour This was originally monobehavior. But we can't use "new" to make this if it is
{
    public PlayerState currentState { get; private set; }
    
    public void Initialize(PlayerState _startState)
    {
        currentState = _startState;
        currentState.Enter();
    }

    public void ChangeState(PlayerState _newState)
    {
        currentState.Exit();
        currentState = _newState;
        currentState.Enter();
    }

}
