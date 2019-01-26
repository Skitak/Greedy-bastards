using UnityEngine;

public class Bullet : MonoBehaviour {
    [HideInInspector]
    public GameObject owner;
    private Vector3 velocity;
    private Rigidbody rigid;
    private Timer onScreenTime;
    private void Start() {
        rigid = this.GetComponent<Rigidbody>();
        onScreenTime = new Timer(5f);
        onScreenTime.OnTimerEnd += registerToBulletPool;
        registerToBulletPool();
    }

    private void Update() {
        rigid.velocity = this.velocity;
    }
    private void OnCollisionEnter2D(Collision2D other) {

        registerToBulletPool();
    }

    public void fire(Vector2 velocity, float onScreenTime){
        this.velocity = new Vector3(velocity.x, 0, velocity.y);
        rigid.velocity = velocity;
        this.onScreenTime.EndTime = onScreenTime;
        this.onScreenTime.ResetPlay();
    }

    private void registerToBulletPool(){
        onScreenTime.Pause();
        this.gameObject.SetActive(false);
        BulletPool.registerBullet(this);
    }
}