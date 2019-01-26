using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateHolder : MonoBehaviour
{
    public EndGameState endGameState;
    public EnterPlayState enterPlayState;
    public IntroductionState introductionState;
    public PauseState pauseState;
    public PlayerJoinState playerJoinState;
    public PlayState playState;

    void Start (){
        endGameState = this.GetComponent<EndGameState>();
        enterPlayState = this.GetComponent<EnterPlayState>();
        introductionState = this.GetComponent<IntroductionState>();
        pauseState = this.GetComponent<PauseState>();
        playerJoinState = this.GetComponent<PlayerJoinState>();
        playState = this.GetComponent<PlayState>();
    } 
}
