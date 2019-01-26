using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : GameState
{
    public GameObject pauseCanvas;
    public override void Enter(){
        pauseCanvas.SetActive(true);
        PauseGame();
    }
    public override void UpdateState(float delta){
        if (Input.GetButtonDown("Pause"))
            GameManager.ChangeState(GameManager.instance.states.playState);
    }
    public override void Exit(){
        pauseCanvas.SetActive(false);
        PlayGame();
    }

    private void PauseGame() {
        TimerManager.isPlaying = false;
        GameManager.instance.isGamePaused = true;
    }

    private void PlayGame() {
        TimerManager.isPlaying = true;
        GameManager.instance.isGamePaused = false;

    }


}
