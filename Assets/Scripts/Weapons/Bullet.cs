using UnityEngine;

public class Bullet : MonoBehaviour {
    [HideInInspector]
    public GameObject owner;
    private Vector2 velocity;
    private Rigidbody2D rigid;
    private Timer onScreenTime;

    private BaseCharacter baseCharacter;
    private void Start() {
        rigid = this.GetComponent<Rigidbody2D>();
        onScreenTime = new Timer(5f);
        onScreenTime.OnTimerEnd += registerToBulletPool;
        registerToBulletPool();
    }

    private void Update() {
        rigid.velocity = this.velocity;
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject == this.owner || other.gameObject.tag == "Bullet") 
            return;
        if (other.gameObject.tag == "Player") //hit
        {
            other.gameObject.GetComponent<BaseCharacter>().hit();
        }

        registerToBulletPool();
    }

    public void fire(Vector2 velocity, float onScreenTime){
        this.velocity = velocity;
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