using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameState : GameState
{
    // Start is called before the first frame update
    public GameObject endGameCanvas;
    public override void Enter(){
        endGameCanvas.SetActive(true);
        GameManager.instance.enemyManager.StopSpawning();
    }
    public override void UpdateState(float delta){ }
    public override void Exit(){
        Debug.Log("Exiting end game");
         endGameCanvas.SetActive(false);
    }
}
