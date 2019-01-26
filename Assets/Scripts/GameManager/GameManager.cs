using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public bool startWithIntroductionScene = false;
    public float endGameTime;
    public GameObject characterPrefab;
    public GameObject[] characterInitialSpawn;
    private GameState currentState;
    public static GameManager instance;
    public GameObject endGameCanvas;
    [HideInInspector]
    public GameObject[] players = new GameObject[4];
    private int globalLoot = 0;
    private Dictionary<string, int> controllerToPlayerIndex = new Dictionary<string, int>();
    private int numberOfPlayers = 0;

    void Start() {
        if (instance != null)
            return;
        DontDestroyOnLoad(this.gameObject);
        instance = this;
        if (startWithIntroductionScene)
            currentState = new IntroductionState();        
        else
            currentState = new PlayerJoinState();      
        currentState.Enter();  
    }
    void Update(){
        currentState.Update(Time.deltaTime);
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
        endGameCanvas.SetActive(false);
        ChangeState(new EnterPlayState());
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
        for (int i = 0; i < 5; ++i) {
            if (instance.players[i] != null)
                instance.players[i].GetComponent<Character>().Reset();
        }
    }
}
