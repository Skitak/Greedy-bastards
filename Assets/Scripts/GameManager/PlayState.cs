using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState : GameState
{

    Timer endGameTimer;
    public float endGameTime;
    void Start () {
        endGameTimer = new Timer(endGameTime, EndGame);
    }
    public override void Enter(){
        endGameTimer.Play();
        GameManager.instance.GlobalLoot = 0;
    }
    public override void UpdateState(float delta){
        if (Input.GetButtonDown("Pause")){
            GameManager.ChangeState(GameManager.instance.states.pauseState);
        }

    }
    public override void Exit(){
        endGameTimer.Pause();
    }

    void EndGame() {
        endGameTimer.Reset();
        GameManager.ChangeState(GameManager.instance.states.endGameState);
    }
    public void Reset(){
        endGameTimer.Reset();
    }

}
