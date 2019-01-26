using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState : GameState
{
    private Timer timerEndGame;
    public PlayState () {
        timerEndGame = new Timer(GameManager.instance.endGameTime, EndGame);
    }
    public override void Enter(){
        Debug.Log("Entering playing phase");
        timerEndGame.ResetPlay();
        GameManager.instance.GlobalLoot = 0;
        GameManager.ResetPlayers();
    }
    public override void Update(float delta){
        if (Input.GetKeyDown("Pause")){
            //
        }
    }
    public override void Exit(){
        Debug.Log("Exiting playing phase");
    }

    void EndGame(){
        GameManager.ChangeState(new EndGameState());
    }
}
