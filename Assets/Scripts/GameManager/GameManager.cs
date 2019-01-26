using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public bool startWithIntroductionScene = false;
    public GameObject characterPrefab;
    public GameObject[] characterInitialSpawn;
    private GameState currentState;
    public static GameManager instance;
    [HideInInspector]
    public GameObject[] players = new GameObject[4];
    public GameStateHolder states;
    public bool isGamePaused = false;
    private int globalLoot = 0;
    private Dictionary<string, int> controllerToPlayerIndex = new Dictionary<string, int>();
    private int numberOfPlayers = 0;

    void Start() {
        if (instance != null)
            return;
        DontDestroyOnLoad(this.gameObject);
        instance = this;
        if (startWithIntroductionScene)
            currentState = states.introductionState;        
        else
            currentState = states.playerJoinState;      
        currentState.Enter();
    }
    void Update(){
        currentState.UpdateState(Time.deltaTime);
    }

    public static void ChangeState (GameState newState) {
        instance.currentState.Exit();
        newState.Enter();
        instance.currentState = newState;
    }

    public static void PlayerDied(string controller){}
    public static void FirstSpawnPlayer(string controller){
        instance.controllerToPlayerIndex[controller] = instance.numberOfPlayers; 
        Vector3 spawnPosition = instance.characterInitialSpawn[++instance.numberOfPlayers].transform.localPosition;
        instance.players[instance.numberOfPlayers - 1] = Instantiate(instance.characterPrefab, spawnPosition, Quaternion.identity) as GameObject;
        instance.players[instance.numberOfPlayers - 1].GetComponent<CharaController>().SetController(controller);
    }

    public void PlayAgain() {
        Debug.Log("Reset game");
        states.playState.Reset();
        ChangeState(instance.states.enterPlayState);
    }

    public static int GetPlayerNumberFromController(string controller){
        return instance.controllerToPlayerIndex[controller] + 1;
    }

    public int GlobalLoot {
        get{ return globalLoot;}
        set {
            globalLoot = value;
            // Change UI here
        }
    }

    public static void ResetPlayers(){
        for (int i = 0; i < 4; ++i) {
            if (instance.players[i] != null)
                instance.players[i].GetComponent<Character>().Reset();
        }
    }
}
