using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlauseState : IGameState
{
    public SimpleStateEvent OnStateSwitch { get; set; }
    public GameManager gameManager { get; set; }

    public void End()
    {
        throw new System.NotImplementedException();
    }

    public void Run()
    {
        throw new System.NotImplementedException();
    }

    public void Start()
    {
        throw new System.NotImplementedException();
    }
}