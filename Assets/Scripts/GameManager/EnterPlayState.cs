﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterPlayState : GameState
{
    
    public override void Enter(){
        GameManager.ResetPlayers();
        GameManager.instance.enemyManager.StartSpawning();
    }
    public override void UpdateState(float delta){
        GameManager.ChangeState(GameManager.instance.states.playState);
    }
    public override void Exit(){
    }
}
