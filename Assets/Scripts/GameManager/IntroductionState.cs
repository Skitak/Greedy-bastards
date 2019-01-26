using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroductionState : GameState {
    
    string introScene = "Introduction Scene";
    string gameScene = "Game Scene";
    public override void Enter(){
        SceneManager.LoadScene(introScene);
    }
    public override void UpdateState(float delta){
        if (Input.anyKey)
            GameManager.ChangeState(new PlayerJoinState());
    }
    public override void Exit(){
        SceneManager.LoadScene(gameScene);
    }
}
