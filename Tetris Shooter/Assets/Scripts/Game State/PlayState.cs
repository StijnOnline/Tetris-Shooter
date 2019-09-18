using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState : IGameState
{
    public SimpleStateEvent OnStateSwitch { get; set; }
    public GameManager gameManager { get; set; }

    public void End()
    {
    }

    public void Run()
    {
        gameManager.players[0].ProcessInput(PlayerInput.GetInput(0));
        gameManager.players[1].ProcessInput(PlayerInput.GetInput(1));
        if (gameManager.Attract != null) { gameManager.Attract(new Vector2(0, 0), GameManager.middleForce); }


        gameManager.UI.UpdatePlayerUI(gameManager.players[0].score, gameManager.players[0].energy, gameManager.players[1].score, gameManager.players[1].energy);
    }

    public void Start()
    {
        //BlockPool.Initialize(gameManager);

        //gameManager.players[0].NewBlock();
        //gameManager.players[1].NewBlock();
    }
}
