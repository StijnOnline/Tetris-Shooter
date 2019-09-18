using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {


    public static float blockSpeed = 1;
    public static float middleForce = 1;

    //TODO: set rotate speed in animator
    //public float middleRotateSpeed = 1;

    //DISCUSS: other way without player references?
    public Player[] players = new Player[2];

    public UI UI;

    public delegate void AttractDelegate(Vector3 target, float force);
    public AttractDelegate Attract;

    public System.Action UpdateGame;


    public GameStateMachine gameStateMachine;

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
        gameStateMachine = new GameStateMachine(this,new MenuState());
    }

    private void OnDestroy()
    {
        Attract = null;
    }

    private void Update()
    {
        gameStateMachine.Update();
    }

    public void AddScore(float x, int score)
    {
        if (x < 0)
        {
            players[0].AddScore(30);
        }
        else
        {
            players[1].AddScore(30);
        }
    }


}
