using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {
    private Vector3 cameraVelocity = Vector3.zero;
    private Camera cam;
    public float smoothingTime = .5f;

    public float cameraMinSize = 5f;
    public float cameraMaxSize = 10f;
    public float cameraBorderSize = 3f;
    private void Start() {
        cam = GetComponentInChildren<Camera>();
    }
    void Update(){
        Vector3 playerCenterPosition = GetPlayerCenterPosition();
        Vector3 furtherPlayerFromCenter = GetFurtherPlayerFromCenter(playerCenterPosition);
        this.transform.position = Vector3.SmoothDamp(transform.position, playerCenterPosition,ref cameraVelocity, smoothingTime);
        cam.orthographicSize = Mathf.Max(Mathf.Min((furtherPlayerFromCenter - playerCenterPosition).magnitude, cameraMaxSize), cameraMinSize) + cameraBorderSize;

    }

    Vector3 GetPlayerCenterPosition() {
        Vector3 centerOfGravity = Vector3.zero;
        for (int i = 0; i < GameManager.GetNumberOfPlayers(); ++i){
            centerOfGravity += GameManager.instance.players[i].transform.position;
        }
        centerOfGravity /= Mathf.Max(GameManager.GetNumberOfPlayers(), 1);
        centerOfGravity.y = 0;
        return centerOfGravity;
    }

    Vector3 GetFurtherPlayerFromCenter(Vector3 center) {
        Vector3 furtherPlayerPos = center;
        for (int i = 0; i < GameManager.GetNumberOfPlayers(); ++i){
            Vector3 playerPos = GameManager.instance.players[i].transform.position;
            if ((furtherPlayerPos - center).magnitude < (playerPos - center).magnitude )
                furtherPlayerPos = playerPos;
        }
        furtherPlayerPos.y = 0;
        return furtherPlayerPos;
    }
}
