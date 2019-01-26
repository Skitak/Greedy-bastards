using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterPlayState : GameState
{
    
    public override void Enter(){
        GameManager.ChangeState(new PlayState());
    }
    public override void Update(float delta){}
    public override void Exit(){}
}
