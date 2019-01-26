using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayState : GameState
{
   
    public Text finalTimerText;
    Timer endGameTimer;
    public float endGameTime;
    
    void Start () 
    {
        endGameTimer = new Timer(endGameTime, EndGame);
        endGameTimer.OnTimerUpdate += UpdateTimerText;
    }

    public override void Enter()
    {
        endGameTimer.Play();
        GameManager.instance.GlobalLoot = 0;
    }

    public override void UpdateState(float delta)
    {
        if (Input.GetButtonDown("Pause"))
        {
            GameManager.ChangeState(GameManager.instance.states.pauseState);
        }

    }
    public override void Exit()
    {
        endGameTimer.Pause();
    }

    void EndGame() 
    {
        endGameTimer.Reset();
        GameManager.ChangeState(GameManager.instance.states.endGameState);
    }
    public void Reset(){
        endGameTimer.Reset();
    }

    public void UpdateTimerText ()
    {

        finalTimerText.text = "Time left : " + (int) (endGameTimer.GetPercentageLeft() * 100) + " %";
    }

}
