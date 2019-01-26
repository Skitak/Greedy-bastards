using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState : GameState
{
    private Timer timerEndGame;
    private GameObject endGameCanvas;
    public PlayState () {
        timerEndGame = new Timer(GameManager.instance.endGameTime, EndGame);
    }
    public override void Enter(){
        Debug.Log("Entering playing phase");
        timerEndGame.ResetPlay();
        GameManager.instance.GlobalLoot = 0;
        GameManager.ResetPlayers();
    }
    public override void Update(float delta){}
    public override void Exit(){
        Debug.Log("Exiting playing phase");
    }

    void EndGame(){
        GameManager.instance.endGameCanvas.SetActive(true);

    }
}
