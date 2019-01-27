using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroductionState : GameState {
    public override void Enter(){
        SceneManager.LoadScene(1);
    }
    public override void UpdateState(float delta){
        if (Input.anyKey)
            GameManager.ChangeState(new PlayerJoinState());
    }
    public override void Exit(){
        SceneManager.LoadScene(0);
    }

    public void Play() {
        GameManager.ChangeState(GameManager.instance.states.playerJoinState);
    }
}
