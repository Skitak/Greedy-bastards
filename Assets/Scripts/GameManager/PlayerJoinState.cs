using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJoinState : GameState
{
    string[] controllers = {
        "keyboard", "controller 1", "controller 2", "controller 3", "controller 4",
    };
    string playInput = "Play";
    ArrayList controllerUsed = new ArrayList();
    public override void Enter(){
    }
    public override void UpdateState(float delta){
        foreach (string controller in controllers) {
            if (Input.GetButtonDown(playInput + " " + controller)){
                if (!controllerUsed.Contains(controller))
                    PlayerEnteredGame(controller);
                else {
                    StartGame();
                }
            }
        }
    }
    public override void Exit(){
        Debug.Log("Exiting joining phase");
    }

    void StartGame() {
        GameManager.ChangeState(GameManager.instance.states.enterPlayState);
    }

    void PlayerEnteredGame(string controller) {
        Debug.Log("Spawning a new player");
        controllerUsed.Add(controller);
        GameManager.FirstSpawnPlayer(controller);
    }
}
