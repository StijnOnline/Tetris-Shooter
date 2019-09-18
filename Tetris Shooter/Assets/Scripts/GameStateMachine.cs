//gebaseerd op Aaron's FSM voorbeeld


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public delegate void SimpleStateEvent(IGameState fromstate,IGameState state, string sceneName);
public class GameStateMachine
{
    private IGameState beginState;
    private IGameState currentState;
    private GameManager gameManager;
    public GameStateMachine(GameManager _gameManager, IGameState _beginState)
    {
        gameManager = _gameManager;
        beginState = _beginState;
        SwitchState(beginState,beginState);
    }

    public void Update()
    {
        //Debug.Log(currentState);
        if (currentState != null)
        {
            currentState.Run();
        }
    }

    public void SwitchState(IGameState _fromState, IGameState _State, string _sceneName = null)
    {
        Debug.Log(_fromState);
        //clean up
        if (currentState != null)
        {
            currentState.OnStateSwitch -= SwitchState;
            currentState.End();
        }

        if (_sceneName != null)
        {
            SceneManager.LoadScene(_sceneName);
        }
        _State.gameManager = gameManager;
        //initialize
        _State.Start();
        _State.OnStateSwitch += SwitchState;

        //store current
        currentState = _State;
    }
}
