using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayState : GameState
{
    
    public override void Enter(){
        Debug.Log("Entering playing phase");
    }
    public override void Update(float delta){}
    public override void Exit(){
        Debug.Log("Exiting playing phase");
    }
}
