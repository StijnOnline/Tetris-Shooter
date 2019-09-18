using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuState : IGameState
{
    public SimpleStateEvent OnStateSwitch { get; set; }
    public GameManager gameManager { get; set; }

    public void End()
    { 

    }

    public void Run()
    {        
        if (StartButton.isClicked)
        {
            OnStateSwitch(this,new PlayState(),"MainGame");          
        }
    }

    public void Start()
    {
    }
}